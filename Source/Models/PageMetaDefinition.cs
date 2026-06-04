#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Describes one HTML metadata entry rendered by <see cref="PageBuilder" /> as a <c>meta</c> tag.
    /// </summary>
    /// <remarks>
    ///     Use the static factory methods to create the supported metadata shapes. The <see cref="Kind" /> property
    ///     determines whether the rendered tag uses <c>charset</c>, <c>name</c>, <c>property</c>, or
    ///     <c>http-equiv</c>.
    /// </remarks>
    public sealed class PageMetaDefinition
    {
        #region Static methods

        /// <summary>
        ///     Creates a charset metadata definition.
        /// </summary>
        /// <param name="charset">The charset value to render.</param>
        /// <returns>A metadata definition configured for a <c>meta charset</c> tag.</returns>
        public static PageMetaDefinition Charset(PageCharset charset)
        {
            return new PageMetaDefinition
            {
                Kind = PageMetaKind.Charset,
                _Charset = charset.GetValue()
            };
        }

        /// <summary>
        ///     Creates an HTTP-equivalent metadata definition.
        /// </summary>
        /// <param name="httpEquiv">The <c>http-equiv</c> attribute value.</param>
        /// <param name="content">The metadata content value.</param>
        /// <returns>A metadata definition configured for an HTTP-equivalent <c>meta</c> tag.</returns>
        public static PageMetaDefinition HttpEquivMeta(string httpEquiv, string content)
        {
            return new PageMetaDefinition
            {
                Kind = PageMetaKind.HttpEquiv,
                Name = httpEquiv,
                Content = content
            };
        }

        /// <summary>
        ///     Creates a name-based metadata definition.
        /// </summary>
        /// <param name="name">The <c>name</c> attribute value.</param>
        /// <param name="content">The metadata content value.</param>
        /// <returns>A metadata definition configured for a name-based <c>meta</c> tag.</returns>
        public static PageMetaDefinition NameMeta(string name, string content)
        {
            return new PageMetaDefinition
            {
                Kind = PageMetaKind.Name,
                Name = name,
                Content = content
            };
        }

        /// <summary>
        ///     Creates a name-based metadata definition from a known <see cref="PageMetaName" /> value.
        /// </summary>
        /// <param name="name">The known metadata name.</param>
        /// <param name="content">The metadata content value.</param>
        /// <returns>A metadata definition configured for a name-based <c>meta</c> tag.</returns>
        public static PageMetaDefinition NameMeta(PageMetaName name, string content)
        {
            return NameMeta(name.GetValue(), content);
        }

        /// <summary>
        ///     Creates a property-based metadata definition.
        /// </summary>
        /// <param name="property">The <c>property</c> attribute value.</param>
        /// <param name="content">The metadata content value.</param>
        /// <returns>A metadata definition configured for a property-based <c>meta</c> tag.</returns>
        public static PageMetaDefinition PropertyMeta(string property, string content)
        {
            return new PageMetaDefinition
            {
                Kind = PageMetaKind.Property,
                Name = property,
                Content = content
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the charset value rendered when <see cref="Kind" /> is <see cref="PageMetaKind.Charset" />.
        /// </summary>
        public string? _Charset { get; set; }

        /// <summary>
        ///     Gets or sets the content attribute value for name, property, and HTTP-equivalent metadata.
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        ///     Gets or sets the metadata shape rendered by <see cref="PageBuilder" />.
        /// </summary>
        public PageMetaKind Kind { get; set; }

        /// <summary>
        ///     Gets or sets the name, property, or HTTP-equivalent key depending on <see cref="Kind" />.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///     Gets or sets the ordering value used when metadata tags are rendered.
        /// </summary>
        public int Order { get; set; } = 0;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Sets the ordering value used when metadata tags are rendered.
        /// </summary>
        /// <param name="order">The ordering position. Lower values render earlier in the head.</param>
        /// <returns>The current <see cref="PageMetaDefinition" /> for chaining.</returns>
        public PageMetaDefinition SetOrder(int order)
        {
            Order = order;
            return this;
        }

        #endregion
    }
}