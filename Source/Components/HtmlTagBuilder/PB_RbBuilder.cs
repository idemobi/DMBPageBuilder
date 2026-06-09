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
    ///     Builds an HTML <c>rb</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("rb is obsolete.")]
    public sealed class PB_RbBuilder : HtmlTagBuilder<PB_RbBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_RbBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_RbBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "rb";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_RbBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}