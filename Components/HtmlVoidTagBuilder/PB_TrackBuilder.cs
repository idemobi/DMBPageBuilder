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
    ///     Builds an HTML <c>track</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_TrackBuilder : HtmlVoidTagBuilder<PB_TrackBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_TrackBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_TrackBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "track";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_TrackBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>default</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_TrackBuilder" /> instance for chaining.</returns>
        public PB_TrackBuilder SetDefault(bool value = true) => value ? SetAttribute("default", "default") : SetAttribute("default", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>kind</c> attribute.
        /// </summary>
        /// <param name="kind">The value to assign to the HTML <c>kind</c> attribute.</param>
        /// <returns>The current <see cref="PB_TrackBuilder" /> instance for chaining.</returns>
        public PB_TrackBuilder SetKind(string kind) => SetAttribute("kind", kind);

        /// <summary>
        ///     Sets the HTML <c>label</c> attribute.
        /// </summary>
        /// <param name="label">The value to assign to the HTML <c>label</c> attribute.</param>
        /// <returns>The current <see cref="PB_TrackBuilder" /> instance for chaining.</returns>
        public PB_TrackBuilder SetLabel(string label) => SetAttribute("label", label);

        /// <summary>
        ///     Sets the HTML <c>src</c> attribute.
        /// </summary>
        /// <param name="src">The value to assign to the HTML <c>src</c> attribute.</param>
        /// <returns>The current <see cref="PB_TrackBuilder" /> instance for chaining.</returns>
        public PB_TrackBuilder SetSrc(string src) => SetAttribute("src", src);

        /// <summary>
        ///     Sets the HTML <c>srclang</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_TrackBuilder" /> instance for chaining.</returns>
        public PB_TrackBuilder SetSrclang(string value) => SetAttribute("srclang", value);

        #endregion
    }
}