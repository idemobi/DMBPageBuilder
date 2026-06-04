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
    ///     Builds an HTML <c>map</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_MapBuilder : HtmlTagBuilder<PB_MapBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_MapBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_MapBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "map";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_MapBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_MapBuilder" /> instance for chaining.</returns>
        public new PB_MapBuilder SetName(string name) => SetAttribute("name", name);

        #endregion
    }
}