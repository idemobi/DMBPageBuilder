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
    ///     Builds an HTML <c>nobr</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("nobr is obsolete and non-standard.")]
    public sealed class PB_NobrBuilder : HtmlTagBuilder<PB_NobrBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_NobrBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_NobrBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "nobr";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_NobrBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}