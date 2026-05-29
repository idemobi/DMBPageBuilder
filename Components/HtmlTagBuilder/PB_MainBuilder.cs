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
    ///     Builds an HTML <c>main</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_MainBuilder : HtmlTagBuilder<PB_MainBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_MainBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_MainBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "main";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_MainBuilder CreateInstance()
        {
            return new PB_MainBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}