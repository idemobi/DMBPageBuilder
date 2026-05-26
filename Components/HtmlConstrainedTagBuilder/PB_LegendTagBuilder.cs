#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_LegendTagBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>legend</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_LegendTagBuilder : HtmlConstrainedTagBuilder<PB_LegendTagBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds => new[] { HtmlRenderContextKind.Fieldset };

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_LegendTagBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_LegendTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "legend";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_LegendTagBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}