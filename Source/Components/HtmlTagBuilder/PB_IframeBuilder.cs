#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>iframe</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_IframeBuilder : HtmlTagBuilder<PB_IframeBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_IframeBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_IframeBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "iframe";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_IframeBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>allow</c> attribute.
        /// </summary>
        /// <param name="allow">The value to assign to the HTML <c>allow</c> attribute.</param>
        /// <returns>The current <see cref="PB_IframeBuilder" /> instance for chaining.</returns>
        public PB_IframeBuilder SetAllow(string allow) => SetAttribute("allow", allow);

        /// <summary>
        ///     Sets the HTML <c>height</c> attribute.
        /// </summary>
        /// <param name="height">The value to assign to the HTML <c>height</c> attribute.</param>
        /// <returns>The current <see cref="PB_IframeBuilder" /> instance for chaining.</returns>
        public PB_IframeBuilder SetHeight(string height) => SetAttribute("height", height);

        /// <summary>
        ///     Sets the HTML <c>loading</c> attribute.
        /// </summary>
        /// <param name="loading">The value to assign to the HTML <c>loading</c> attribute.</param>
        /// <returns>The current <see cref="PB_IframeBuilder" /> instance for chaining.</returns>
        public PB_IframeBuilder SetLoading(string loading) => SetAttribute("loading", loading);

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_IframeBuilder" /> instance for chaining.</returns>
        public new PB_IframeBuilder SetName(string name) => SetAttribute("name", name);

        /// <summary>
        ///     Sets the HTML <c>src</c> attribute.
        /// </summary>
        /// <param name="src">The value to assign to the HTML <c>src</c> attribute.</param>
        /// <returns>The current <see cref="PB_IframeBuilder" /> instance for chaining.</returns>
        public PB_IframeBuilder SetSrc(string src) => SetAttribute("src", src);

        /// <summary>
        ///     Sets the HTML <c>width</c> attribute.
        /// </summary>
        /// <param name="width">The value to assign to the HTML <c>width</c> attribute.</param>
        /// <returns>The current <see cref="PB_IframeBuilder" /> instance for chaining.</returns>
        public PB_IframeBuilder SetWidth(string width) => SetAttribute("width", width);

        #endregion
    }
}