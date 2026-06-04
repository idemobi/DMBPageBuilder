#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>big</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("big is obsolete in HTML5.")]
    public sealed class PB_BigBuilder : HtmlTagBuilder<PB_BigBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_BigBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_BigBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "big";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_BigBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}