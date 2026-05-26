#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_ListItemBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>li</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ListItemBuilder : HtmlConstrainedTagBuilder<PB_ListItemBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.UnorderedList,
                HtmlRenderContextKind.OrderedList
            };

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.ListItem;

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ListItemBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ListItemBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "li";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ListItemBuilder CreateInstance()
        {
            return new PB_ListItemBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}