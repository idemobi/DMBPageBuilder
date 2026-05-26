#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_AudioBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>audio</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_AudioBuilder : HtmlTagBuilder<PB_AudioBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_AudioBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_AudioBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "audio";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_AudioBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>autoplay</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_AudioBuilder" /> instance for chaining.</returns>
        public PB_AudioBuilder SetAutoplay(bool value = true) => value ? SetAttribute("autoplay", "autoplay") : SetAttribute("autoplay", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>controls</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_AudioBuilder" /> instance for chaining.</returns>
        public PB_AudioBuilder SetControls(bool value = true) => value ? SetAttribute("controls", "controls") : SetAttribute("controls", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>loop</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_AudioBuilder" /> instance for chaining.</returns>
        public PB_AudioBuilder SetLoop(bool value = true) => value ? SetAttribute("loop", "loop") : SetAttribute("loop", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>muted</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_AudioBuilder" /> instance for chaining.</returns>
        public PB_AudioBuilder SetMuted(bool value = true) => value ? SetAttribute("muted", "muted") : SetAttribute("muted", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>src</c> attribute.
        /// </summary>
        /// <param name="src">The value to assign to the HTML <c>src</c> attribute.</param>
        /// <returns>The current <see cref="PB_AudioBuilder" /> instance for chaining.</returns>
        public PB_AudioBuilder SetSrc(string src) => SetAttribute("src", src);

        #endregion
    }
}