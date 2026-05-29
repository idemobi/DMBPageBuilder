#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Describes one link resource that <see cref="PageBuilder" /> renders as a <c>link</c> tag in the document head.
    /// </summary>
    /// <remarks>
    ///     Link definitions are stored in <see cref="PageInformation.Links" /> and are deduplicated by <see cref="Href" />.
    ///     They are used for stylesheets, icons, canonical URLs, manifests, preloads, and prefetches.
    /// </remarks>
    public sealed class PageLinkDefinition
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the optional resource destination rendered in the <c>as</c> attribute.
        /// </summary>
        public string? As { get; set; }

        /// <summary>
        ///     Gets or sets the crossorigin policy rendered on the link tag.
        /// </summary>
        public PageCrossOrigin CrossOrigin { get; set; } = PageCrossOrigin.None;

        /// <summary>
        ///     Gets or sets the target URL rendered in the <c>href</c> attribute.
        /// </summary>
        public string Href { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the optional subresource integrity hash rendered on the link tag.
        /// </summary>
        public string? Integrity { get; set; }

        /// <summary>
        ///     Gets or sets the ordering value used when link tags are rendered.
        /// </summary>
        public int Order { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the relationship type rendered in the <c>rel</c> attribute.
        /// </summary>
        public PageLinkRel Rel { get; set; }

        /// <summary>
        ///     Gets or sets the optional icon or resource size descriptor.
        /// </summary>
        public string? Sizes { get; set; }

        /// <summary>
        ///     Gets or sets the optional MIME type rendered in the <c>type</c> attribute.
        /// </summary>
        public string? Type { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Sets the crossorigin policy for the link tag.
        /// </summary>
        /// <param name="crossOrigin">The crossorigin policy to render.</param>
        /// <returns>The current <see cref="PageLinkDefinition" /> for chaining.</returns>
        public PageLinkDefinition SetCrossOrigin(PageCrossOrigin crossOrigin)
        {
            CrossOrigin = crossOrigin;
            return this;
        }

        /// <summary>
        ///     Sets the optional subresource integrity hash for the link tag.
        /// </summary>
        /// <param name="integrity">The integrity hash, or <see langword="null" /> to omit the attribute.</param>
        /// <returns>The current <see cref="PageLinkDefinition" /> for chaining.</returns>
        public PageLinkDefinition SetIntegrity(string? integrity)
        {
            Integrity = integrity;
            return this;
        }

        /// <summary>
        ///     Sets the ordering value used when link tags are rendered.
        /// </summary>
        /// <param name="order">The ordering position. Lower values render earlier in the head.</param>
        /// <returns>The current <see cref="PageLinkDefinition" /> for chaining.</returns>
        public PageLinkDefinition SetOrder(int order)
        {
            Order = order;
            return this;
        }

        #endregion
    }
}