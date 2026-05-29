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
    ///     Builds an HTML <c>rp</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_RpBuilder : HtmlConstrainedTagBuilder<PB_RpBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override bool RequiresParentContext => false;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_RpBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_RpBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "rp";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_RpBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}