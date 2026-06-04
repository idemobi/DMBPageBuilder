#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>ol</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_OlBuilder : HtmlConstrainedTagBuilder<PB_OlBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.OrderedList;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_OlBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_OlBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "ol";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_OlBuilder CreateInstance()
        {
            return new PB_OlBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>reversed</c> attribute.
        /// </summary>
        /// <param name="reversed">The value to assign to the HTML <c>reversed</c> attribute.</param>
        /// <returns>The current <see cref="PB_OlBuilder" /> instance for chaining.</returns>
        public PB_OlBuilder SetReversed(bool reversed = true)
        {
            return reversed
                ? SetAttribute("reversed", "reversed")
                : SetAttribute("reversed", (string?)null);
        }

        /// <summary>
        ///     Sets the HTML <c>start</c> attribute.
        /// </summary>
        /// <param name="start">The value to assign to the HTML <c>start</c> attribute.</param>
        /// <returns>The current <see cref="PB_OlBuilder" /> instance for chaining.</returns>
        public PB_OlBuilder SetStart(int start)
        {
            return SetAttribute("start", start);
        }

        /// <summary>
        ///     Sets the HTML <c>type</c> attribute.
        /// </summary>
        /// <param name="type">The value to assign to the HTML <c>type</c> attribute.</param>
        /// <returns>The current <see cref="PB_OlBuilder" /> instance for chaining.</returns>
        public PB_OlBuilder SetType(string type)
        {
            return SetAttribute("type", type);
        }

        #endregion
    }
}