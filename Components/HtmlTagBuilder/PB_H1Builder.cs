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
    ///     Builds an HTML <c>h1</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_H1Builder : HtmlTagBuilder<PB_H1Builder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_H1Builder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_H1Builder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "h1";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_H1Builder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}