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
    ///     Builds an HTML <c>hr</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_HrBuilder : HtmlVoidTagBuilder<PB_HrBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_HrBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_HrBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "hr";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_HrBuilder CreateInstance()
        {
            return new PB_HrBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}