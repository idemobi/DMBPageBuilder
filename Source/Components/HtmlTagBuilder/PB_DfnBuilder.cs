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
    ///     Builds an HTML <c>dfn</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_DfnBuilder : HtmlTagBuilder<PB_DfnBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_DfnBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_DfnBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "dfn";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_DfnBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}