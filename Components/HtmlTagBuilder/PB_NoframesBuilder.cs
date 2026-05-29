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
    ///     Builds an HTML <c>noframes</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("noframes is obsolete.")]
    public sealed class PB_NoframesBuilder : HtmlTagBuilder<PB_NoframesBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_NoframesBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_NoframesBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "noframes";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_NoframesBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}