#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    internal static class HtmlUrlAttributeValidator
    {
        #region Static methods

        internal static void Validate(string attributeName, string value, HtmlUrlAttributeDataPolicy dataPolicy = HtmlUrlAttributeDataPolicy.None)
        {
            if (!IsUrlAttribute(attributeName) || string.IsNullOrEmpty(value))
            {
                return;
            }

            if (string.Equals(attributeName, "srcset", StringComparison.OrdinalIgnoreCase))
            {
                ValidateSrcSet(value, dataPolicy);
                return;
            }

            ValidateSingleUrl(attributeName, value, dataPolicy);
        }

        private static int GetSchemeEndIndex(string value)
        {
            int colonIndex = value.IndexOf(':');
            if (colonIndex < 0)
            {
                return -1;
            }

            int slashIndex = value.IndexOf('/');
            int questionIndex = value.IndexOf('?');
            int hashIndex = value.IndexOf('#');
            int firstPathIndex = new[] { slashIndex, questionIndex, hashIndex }
                .Where(index => index >= 0)
                .DefaultIfEmpty(int.MaxValue)
                .Min();

            return colonIndex < firstPathIndex ? colonIndex : -1;
        }

        private static bool HasUnsafeWhitespaceOrControl(string value)
        {
            return value.Any(character => char.IsWhiteSpace(character) || char.IsControl(character));
        }

        private static bool IsAllowedDataUrl(string value, HtmlUrlAttributeDataPolicy dataPolicy)
        {
            if (dataPolicy == HtmlUrlAttributeDataPolicy.None || !value.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            string mediaType = value[5..];
            int commaIndex = mediaType.IndexOf(',');
            if (commaIndex >= 0)
            {
                mediaType = mediaType[..commaIndex];
            }

            int parameterIndex = mediaType.IndexOf(';');
            if (parameterIndex >= 0)
            {
                mediaType = mediaType[..parameterIndex];
            }

            mediaType = mediaType.Trim();
            if (mediaType.Equals("image/svg+xml", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return (dataPolicy.HasFlag(HtmlUrlAttributeDataPolicy.Image) && mediaType.StartsWith("image/", StringComparison.OrdinalIgnoreCase)) ||
                   (dataPolicy.HasFlag(HtmlUrlAttributeDataPolicy.Audio) && mediaType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase)) ||
                   (dataPolicy.HasFlag(HtmlUrlAttributeDataPolicy.Video) && mediaType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsAllowedScheme(string attributeName, string scheme)
        {
            if (string.Equals(scheme, "http", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(scheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return string.Equals(attributeName, "href", StringComparison.OrdinalIgnoreCase) &&
                   (string.Equals(scheme, "mailto", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(scheme, "tel", StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsUrlAttribute(string attributeName)
        {
            return string.Equals(attributeName, "href", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(attributeName, "src", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(attributeName, "srcset", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(attributeName, "action", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(attributeName, "formaction", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(attributeName, "poster", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(attributeName, "cite", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(attributeName, "data", StringComparison.OrdinalIgnoreCase);
        }

        private static void ValidateSingleUrl(string attributeName, string value, HtmlUrlAttributeDataPolicy dataPolicy)
        {
            string trimmedValue = value.Trim();
            if (trimmedValue.Length != value.Length || HasUnsafeWhitespaceOrControl(trimmedValue))
            {
                throw new ArgumentException($"URL attribute '{attributeName}' contains unsafe whitespace or control characters.", nameof(value));
            }

            int schemeEndIndex = GetSchemeEndIndex(trimmedValue);
            if (schemeEndIndex < 0)
            {
                return;
            }

            string scheme = trimmedValue[..schemeEndIndex];
            if (string.Equals(scheme, "data", StringComparison.OrdinalIgnoreCase) && IsAllowedDataUrl(trimmedValue, dataPolicy))
            {
                return;
            }

            if (!IsAllowedScheme(attributeName, scheme))
            {
                throw new ArgumentException($"URL attribute '{attributeName}' uses an unsafe URL scheme.", nameof(value));
            }
        }

        private static void ValidateSrcSet(string value, HtmlUrlAttributeDataPolicy dataPolicy)
        {
            foreach (string candidate in value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                string url = candidate.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? string.Empty;
                ValidateSingleUrl("srcset", url, dataPolicy);
            }
        }

        #endregion
    }
}
