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
    ///     Builds an HTML <c>caption</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_CaptionBuilder : HtmlConstrainedTagBuilder<PB_CaptionBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.Table
            };

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_CaptionBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_CaptionBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "caption";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_CaptionBuilder CreateInstance()
        {
            return new PB_CaptionBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}