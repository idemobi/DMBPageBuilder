#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System;

namespace DMBPageBuilder
{
    internal static class HtmlStyleDeclarationValidator
    {
        #region Static methods

        internal static void ValidatePropertyName(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("Style key cannot be null or empty.", nameof(propertyName));
            }

            foreach (char character in propertyName)
            {
                if (char.IsWhiteSpace(character) || char.IsControl(character))
                {
                    throw new ArgumentException($"Style key '{propertyName}' contains an invalid character.", nameof(propertyName));
                }

                switch (character)
                {
                    case ':':
                    case ';':
                    case '{':
                    case '}':
                    case '<':
                    case '>':
                    case '/':
                    case '\\':
                    case '"':
                    case '\'':
                    case '`':
                        throw new ArgumentException($"Style key '{propertyName}' contains an invalid character.", nameof(propertyName));
                }
            }
        }

        internal static void ValidatePropertyValue(string propertyName, string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            for (int index = 0; index < value.Length; index++)
            {
                char character = value[index];
                if (char.IsControl(character))
                {
                    throw new ArgumentException($"Style value for '{propertyName}' contains an invalid character.", nameof(value));
                }

                if (IsInsideUrlFunction(value, index))
                {
                    continue;
                }

                switch (character)
                {
                    case ';':
                    case '{':
                    case '}':
                    case '<':
                    case '>':
                        throw new ArgumentException($"Style value for '{propertyName}' contains an invalid character.", nameof(value));
                }
            }

            if (value.Contains("@import", StringComparison.OrdinalIgnoreCase) ||
                value.Contains("expression(", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Style value for '{propertyName}' contains an unsafe CSS expression.", nameof(value));
            }

            ValidateUrlFunctions(propertyName, value);
        }

        private static int FindClosingParenthesis(string value, int startIndex)
        {
            bool quoteIsOpen = false;
            char quote = '\0';
            for (int index = startIndex; index < value.Length; index++)
            {
                char character = value[index];
                if (quoteIsOpen)
                {
                    if (character == quote)
                    {
                        quoteIsOpen = false;
                    }

                    continue;
                }

                if (character is '"' or '\'')
                {
                    quoteIsOpen = true;
                    quote = character;
                    continue;
                }

                if (character == ')')
                {
                    return index;
                }
            }

            return -1;
        }

        private static string NormalizeCssUrl(string rawUrl)
        {
            string url = rawUrl.Trim();
            if (url.Length >= 2 &&
                ((url[0] == '"' && url[^1] == '"') ||
                 (url[0] == '\'' && url[^1] == '\'')))
            {
                url = url[1..^1].Trim();
            }

            return url;
        }

        private static bool IsInsideUrlFunction(string value, int characterIndex)
        {
            int searchIndex = 0;
            while (searchIndex < value.Length)
            {
                int urlIndex = value.IndexOf("url(", searchIndex, StringComparison.OrdinalIgnoreCase);
                if (urlIndex < 0)
                {
                    return false;
                }

                int urlStartIndex = urlIndex + 4;
                int urlEndIndex = FindClosingParenthesis(value, urlStartIndex);
                if (urlEndIndex < 0)
                {
                    return false;
                }

                if (characterIndex > urlStartIndex && characterIndex < urlEndIndex)
                {
                    return true;
                }

                searchIndex = urlEndIndex + 1;
            }

            return false;
        }

        private static void ValidateUrlFunctions(string propertyName, string value)
        {
            int searchIndex = 0;
            while (searchIndex < value.Length)
            {
                int urlIndex = value.IndexOf("url(", searchIndex, StringComparison.OrdinalIgnoreCase);
                if (urlIndex < 0)
                {
                    return;
                }

                int urlStartIndex = urlIndex + 4;
                int urlEndIndex = FindClosingParenthesis(value, urlStartIndex);
                if (urlEndIndex < 0)
                {
                    throw new ArgumentException($"Style value for '{propertyName}' contains an invalid URL function.", nameof(value));
                }

                string url = NormalizeCssUrl(value[urlStartIndex..urlEndIndex]);
                HtmlUrlAttributeValidator.Validate("src", url, HtmlUrlAttributeDataPolicy.Image);
                searchIndex = urlEndIndex + 1;
            }
        }

        #endregion
    }
}
