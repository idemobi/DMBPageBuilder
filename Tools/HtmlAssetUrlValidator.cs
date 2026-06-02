#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    internal static class HtmlAssetUrlValidator
    {
        #region Static methods

        internal static void ValidateRequiredUrl(string attributeName, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Asset URL cannot be null or empty.", nameof(value));
            }

            HtmlUrlAttributeValidator.Validate(attributeName, value);
        }

        #endregion
    }
}
