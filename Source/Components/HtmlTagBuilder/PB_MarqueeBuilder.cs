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
    ///     Builds an HTML <c>marquee</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("marquee is obsolete and non-standard.")]
    public sealed class PB_MarqueeBuilder : HtmlTagBuilder<PB_MarqueeBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_MarqueeBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_MarqueeBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "marquee";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_MarqueeBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}