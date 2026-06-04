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
    ///     Builds an HTML <c>xmp</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("xmp is obsolete.")]
    public sealed class PB_XmpBuilder : HtmlTagBuilder<PB_XmpBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_XmpBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_XmpBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "xmp";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_XmpBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}