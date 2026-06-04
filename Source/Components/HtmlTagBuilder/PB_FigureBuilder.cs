#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>figure</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_FigureBuilder : HtmlTagBuilder<PB_FigureBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_FigureBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_FigureBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "figure";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_FigureBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}