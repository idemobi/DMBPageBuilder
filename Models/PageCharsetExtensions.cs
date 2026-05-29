#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides conversion helpers for page charset values.
    /// </summary>
    public static class PageCharsetExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets the HTML charset token for a page charset value.
        /// </summary>
        /// <param name="charset">The page charset value.</param>
        /// <returns>The HTML charset token.</returns>
        public static string GetValue(this PageCharset charset)
        {
            return charset switch
            {
                PageCharset.Utf8 => "utf-8",
                _ => "utf-8"
            };
        }

        #endregion
    }
}