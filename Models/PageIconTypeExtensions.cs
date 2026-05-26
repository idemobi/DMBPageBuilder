#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageIconTypeExtensions.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides conversion helpers for favicon MIME types.
    /// </summary>
    public static class PageIconTypeExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets the MIME type for a favicon file type.
        /// </summary>
        /// <param name="type">The favicon file type.</param>
        /// <returns>The MIME type value.</returns>
        public static string GetMimeType(this PageIconType type)
        {
            return type switch
            {
                PageIconType.None => string.Empty,
                PageIconType.Png => "image/png",
                PageIconType.Svg => "image/svg+xml",
                PageIconType.Ico => "image/x-icon",
                _ => string.Empty
            };
        }

        #endregion
    }
}