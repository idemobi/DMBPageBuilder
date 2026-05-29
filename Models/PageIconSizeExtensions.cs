#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides conversion helpers for favicon size values.
    /// </summary>
    public static class PageIconSizeExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets the HTML icon size token for a favicon size.
        /// </summary>
        /// <param name="size">The favicon size value.</param>
        /// <returns>The HTML icon size token.</returns>
        public static string GetValue(this PageIconSize size)
        {
            return size switch
            {
                PageIconSize.None => string.Empty,
                PageIconSize.S16 => "16x16",
                PageIconSize.S32 => "32x32",
                PageIconSize.S48 => "48x48",
                PageIconSize.S64 => "64x64",
                PageIconSize.S96 => "96x96",
                PageIconSize.S180 => "180x180",
                PageIconSize.S192 => "192x192",
                PageIconSize.S512 => "512x512",
                _ => string.Empty
            };
        }

        #endregion
    }
}