#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_SelectTagBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>selecttag</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_SelectTagBuilder : HtmlConstrainedTagBuilder<PB_SelectTagBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Select;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_SelectTagBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_SelectTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "select";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_SelectTagBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>multiple</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_SelectTagBuilder" /> instance for chaining.</returns>
        public PB_SelectTagBuilder SetMultiple(bool value = true) => value ? SetAttribute("multiple", "multiple") : SetAttribute("multiple", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_SelectTagBuilder" /> instance for chaining.</returns>
        public PB_SelectTagBuilder SetName(string name) => SetAttribute("name", name);

        /// <summary>
        ///     Sets the HTML <c>size</c> attribute.
        /// </summary>
        /// <param name="size">The value to assign to the HTML <c>size</c> attribute.</param>
        /// <returns>The current <see cref="PB_SelectTagBuilder" /> instance for chaining.</returns>
        public PB_SelectTagBuilder SetSize(int size) => SetAttribute("size", size);

        #endregion
    }
}