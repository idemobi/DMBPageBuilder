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
    ///     Builds an HTML <c>hgroup</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_HgroupBuilder : HtmlTagBuilder<PB_HgroupBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_HgroupBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_HgroupBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "hgroup";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_HgroupBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}