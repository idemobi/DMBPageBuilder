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
    ///     Builds an HTML <c>datalist</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_DatalistBuilder : HtmlConstrainedTagBuilder<PB_DatalistBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Datalist;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_DatalistBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_DatalistBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "datalist";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_DatalistBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>id</c> attribute.
        /// </summary>
        /// <param name="id">The value to assign to the HTML <c>id</c> attribute.</param>
        /// <returns>The current <see cref="PB_DatalistBuilder" /> instance for chaining.</returns>
        public new PB_DatalistBuilder SetId(string id) => base.SetId(id);

        #endregion
    }
}