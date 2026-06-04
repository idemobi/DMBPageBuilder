#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>tbody</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_TbodyBuilder : HtmlConstrainedTagBuilder<PB_TbodyBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.Table
            };

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.TableBody;

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_TbodyBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_TbodyBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "tbody";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_TbodyBuilder CreateInstance()
        {
            return new PB_TbodyBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}