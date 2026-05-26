#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_DialogBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>dialog</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_DialogBuilder : HtmlTagBuilder<PB_DialogBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_DialogBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_DialogBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "dialog";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_DialogBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>open</c> attribute.
        /// </summary>
        /// <param name="open">The value to assign to the HTML <c>open</c> attribute.</param>
        /// <returns>The current <see cref="PB_DialogBuilder" /> instance for chaining.</returns>
        public PB_DialogBuilder SetOpen(bool open = true) => open ? SetAttribute("open", "open") : SetAttribute("open", (string?)null);

        #endregion
    }
}