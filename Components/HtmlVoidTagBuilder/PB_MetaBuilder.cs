#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>meta</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_MetaBuilder : HtmlVoidTagBuilder<PB_MetaBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_MetaBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_MetaBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "meta";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_MetaBuilder CreateInstance()
        {
            return new PB_MetaBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>charset</c> attribute.
        /// </summary>
        /// <param name="charset">The value to assign to the HTML <c>charset</c> attribute.</param>
        /// <returns>The current <see cref="PB_MetaBuilder" /> instance for chaining.</returns>
        public PB_MetaBuilder SetCharset(string charset)
        {
            return SetAttribute("charset", charset);
        }

        /// <summary>
        ///     Sets the HTML <c>content</c> attribute.
        /// </summary>
        /// <param name="content">The value to assign to the HTML <c>content</c> attribute.</param>
        /// <returns>The current <see cref="PB_MetaBuilder" /> instance for chaining.</returns>
        public PB_MetaBuilder SetContent(string content)
        {
            return SetAttribute("content", content);
        }

        /// <summary>
        ///     Sets the http equiv value.
        /// </summary>
        /// <param name="httpEquiv">The value to assign to the HTML <c>httpEquiv</c> attribute.</param>
        /// <returns>The current <see cref="PB_MetaBuilder" /> instance for chaining.</returns>
        public PB_MetaBuilder SetHttpEquiv(string httpEquiv)
        {
            return SetAttribute("http-equiv", httpEquiv);
        }

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_MetaBuilder" /> instance for chaining.</returns>
        public new PB_MetaBuilder SetName(string name)
        {
            return SetAttribute("name", name);
        }

        #endregion
    }
}