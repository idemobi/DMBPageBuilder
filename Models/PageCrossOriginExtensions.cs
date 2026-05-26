#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageCrossOriginExtensions.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

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