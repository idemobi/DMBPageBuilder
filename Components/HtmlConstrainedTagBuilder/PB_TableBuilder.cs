#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_TableBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>table</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_TableBuilder : HtmlConstrainedTagBuilder<PB_TableBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Table;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_TableBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_TableBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "table";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_TableBuilder CreateInstance()
        {
            return new PB_TableBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}