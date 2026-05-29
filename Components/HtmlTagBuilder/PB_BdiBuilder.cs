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
    ///     Builds an HTML <c>bdi</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_BdiBuilder : HtmlTagBuilder<PB_BdiBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_BdiBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_BdiBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "bdi";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_BdiBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}