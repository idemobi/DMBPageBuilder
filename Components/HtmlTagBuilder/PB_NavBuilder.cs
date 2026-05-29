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
    ///     Builds an HTML <c>nav</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_NavBuilder : HtmlTagBuilder<PB_NavBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_NavBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_NavBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "nav";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_NavBuilder CreateInstance()
        {
            return new PB_NavBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}