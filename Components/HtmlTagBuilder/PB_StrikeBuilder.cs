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
    ///     Builds an HTML <c>strike</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("strike is obsolete.")]
    public sealed class PB_StrikeBuilder : HtmlTagBuilder<PB_StrikeBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_StrikeBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_StrikeBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "strike";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_StrikeBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}