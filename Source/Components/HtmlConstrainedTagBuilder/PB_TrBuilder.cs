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
    ///     Builds an HTML <c>tr</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_TrBuilder : HtmlConstrainedTagBuilder<PB_TrBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.Table,
                HtmlRenderContextKind.TableHead,
                HtmlRenderContextKind.TableBody,
                HtmlRenderContextKind.TableFoot
            };

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.TableRow;

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_TrBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_TrBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "tr";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_TrBuilder CreateInstance()
        {
            return new PB_TrBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}