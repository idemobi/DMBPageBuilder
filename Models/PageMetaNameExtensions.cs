#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageMetaNameExtensions.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides conversion helpers for metadata name values.
    /// </summary>
    public static class PageMetaNameExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets the HTML meta name attribute value for a metadata name.
        /// </summary>
        /// <param name="name">The metadata name value.</param>
        /// <returns>The HTML meta name attribute value.</returns>
        public static string GetValue(this PageMetaName name)
        {
            return name switch
            {
                PageMetaName.Viewport => "viewport",
                PageMetaName.Description => "description",
                PageMetaName.Keywords => "keywords",
                PageMetaName.Robots => "robots",
                PageMetaName.RevisitAfter => "revisit-after",
                PageMetaName.Author => "author",
                PageMetaName.ThemeColor => "theme-color",
                PageMetaName.TwitterCard => "twitter:card",
                PageMetaName.TwitterTitle => "twitter:title",
                PageMetaName.TwitterDescription => "twitter:description",
                PageMetaName.TwitterImage => "twitter:image",
                PageMetaName.TwitterSite => "twitter:site",
                PageMetaName.TwitterCreator => "twitter:creator",
                _ => string.Empty
            };
        }

        #endregion
    }
}