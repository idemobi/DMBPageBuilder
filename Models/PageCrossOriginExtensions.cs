#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides conversion helpers for page crossorigin policies.
    /// </summary>
    public static class PageCrossOriginExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets the HTML crossorigin attribute value for a page policy.
        /// </summary>
        /// <param name="crossOrigin">The page crossorigin policy.</param>
        /// <returns>The HTML crossorigin attribute value.</returns>
        public static string GetValue(this PageCrossOrigin crossOrigin)
        {
            return crossOrigin switch
            {
                PageCrossOrigin.Anonymous => "anonymous",
                PageCrossOrigin.UseCredentials => "use-credentials",
                _ => string.Empty
            };
        }

        #endregion
    }
}