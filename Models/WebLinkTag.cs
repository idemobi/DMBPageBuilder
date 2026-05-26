#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj WebLinkTag.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBServerHelper;

#endregion

namespace DMBPageBuilder
{
    [Serializable]
    /// <summary>
    /// Represents a legacy helper that renders one HTML <c>link</c> asset tag.
    /// </summary>
    public class WebLinkTag
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the crossorigin policy.
        /// </summary>
        public string Crossorigin { set; get; }

        /// <summary>
        ///     Gets or sets the target URL rendered in the <c>href</c> attribute.
        /// </summary>
        public string Href { set; get; }

        /// <summary>
        ///     Gets or sets the subresource integrity hash.
        /// </summary>
        public string Integrity { set; get; }

        /// <summary>
        ///     Gets or sets the relationship rendered in the <c>rel</c> attribute.
        /// </summary>
        public string Rel { set; get; }

        /// <summary>
        ///     Gets or sets the icon size rendered in the <c>sizes</c> attribute.
        /// </summary>
        public string Size { set; get; }

        /// <summary>
        ///     Gets or sets the MIME type rendered in the <c>type</c> attribute.
        /// </summary>
        public string Type { set; get; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Renders the configured stylesheet or link asset as a <c>link</c> tag.
        /// </summary>
        /// <returns>The HTML markup for the configured link asset.</returns>
        public string Html()
        {
            var tag = "<link ";
            if (!string.IsNullOrEmpty(Rel))
            {
                tag += $"rel=\"{Rel}\" ";
            }

            if (!string.IsNullOrEmpty(Type))
            {
                tag += $"type=\"{Type}\" ";
            }

            if (ServerHelperConfiguration.Config.AddLaunchToken)
            {
                if (Href.Contains("?") == false && Href.StartsWith("/") == true)
                {
                    if (!string.IsNullOrEmpty(Href))
                    {
                        tag += $"href=\"{Href}?v={ServerHelperConfiguration.Config.LaunchToken}\" ";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Href))
                    {
                        tag += $"href=\"{Href}\" ";
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Href))
                {
                    tag += $"href=\"{Href}\" ";
                }
            }

            if (!string.IsNullOrEmpty(Crossorigin))
            {
                tag += $"crossorigin=\"{Crossorigin}\" ";
            }

            if (!string.IsNullOrEmpty(Integrity))
            {
                tag += $"integrity=\"{Integrity}\" ";
            }

            if (!string.IsNullOrEmpty(Size))
            {
                tag += $"sizes=\"{Size}\" ";
            }

            tag += ">";

            return tag;
        }

        #endregion
    }
}