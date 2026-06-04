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
    ///     Builds an HTML <c>acronym</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("acronym is obsolete in HTML5.")]
    public sealed class PB_AcronymBuilder : HtmlTagBuilder<PB_AcronymBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_AcronymBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_AcronymBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "acronym";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_AcronymBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}