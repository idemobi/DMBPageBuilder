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
    ///     Builds an HTML <c>video</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_VideoBuilder : HtmlTagBuilder<PB_VideoBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_VideoBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_VideoBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "video";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_VideoBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>autoplay</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_VideoBuilder" /> instance for chaining.</returns>
        public PB_VideoBuilder SetAutoplay(bool value = true) => value ? SetAttribute("autoplay", "autoplay") : SetAttribute("autoplay", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>controls</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_VideoBuilder" /> instance for chaining.</returns>
        public PB_VideoBuilder SetControls(bool value = true) => value ? SetAttribute("controls", "controls") : SetAttribute("controls", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>height</c> attribute.
        /// </summary>
        /// <param name="height">The value to assign to the HTML <c>height</c> attribute.</param>
        /// <returns>The current <see cref="PB_VideoBuilder" /> instance for chaining.</returns>
        public PB_VideoBuilder SetHeight(int height) => SetAttribute("height", height);

        /// <summary>
        ///     Sets the HTML <c>loop</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_VideoBuilder" /> instance for chaining.</returns>
        public PB_VideoBuilder SetLoop(bool value = true) => value ? SetAttribute("loop", "loop") : SetAttribute("loop", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>muted</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_VideoBuilder" /> instance for chaining.</returns>
        public PB_VideoBuilder SetMuted(bool value = true) => value ? SetAttribute("muted", "muted") : SetAttribute("muted", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>poster</c> attribute.
        /// </summary>
        /// <param name="poster">The value to assign to the HTML <c>poster</c> attribute.</param>
        /// <returns>The current <see cref="PB_VideoBuilder" /> instance for chaining.</returns>
        public PB_VideoBuilder SetPoster(string poster) => SetAttribute("poster", poster);

        /// <summary>
        ///     Sets the HTML <c>src</c> attribute.
        /// </summary>
        /// <param name="src">The value to assign to the HTML <c>src</c> attribute.</param>
        /// <returns>The current <see cref="PB_VideoBuilder" /> instance for chaining.</returns>
        public PB_VideoBuilder SetSrc(string src) => SetAttribute("src", src);

        /// <summary>
        ///     Sets the HTML <c>width</c> attribute.
        /// </summary>
        /// <param name="width">The value to assign to the HTML <c>width</c> attribute.</param>
        /// <returns>The current <see cref="PB_VideoBuilder" /> instance for chaining.</returns>
        public PB_VideoBuilder SetWidth(int width) => SetAttribute("width", width);

        /// <inheritdoc />
        protected override void ValidateAttributeValue(string name, string value)
        {
            HtmlUrlAttributeDataPolicy dataPolicy = string.Equals(name, "src", StringComparison.OrdinalIgnoreCase)
                ? HtmlUrlAttributeDataPolicy.Video
                : string.Equals(name, "poster", StringComparison.OrdinalIgnoreCase)
                    ? HtmlUrlAttributeDataPolicy.Image
                    : HtmlUrlAttributeDataPolicy.None;
            HtmlUrlAttributeValidator.Validate(name, value, dataPolicy);
        }

        #endregion
    }
}