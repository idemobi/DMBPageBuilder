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
    ///     Builds an HTML <c>rtc</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("rtc is obsolete.")]
    public sealed class PB_RtcBuilder : HtmlConstrainedTagBuilder<PB_RtcBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override bool RequiresParentContext => false;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_RtcBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_RtcBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "rtc";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_RtcBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}