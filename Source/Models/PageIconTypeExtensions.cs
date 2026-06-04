#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

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