#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_BdoBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>bdo</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_BdoBuilder : HtmlTagBuilder<PB_BdoBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_BdoBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_BdoBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "bdo";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_BdoBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>dir</c> attribute.
        /// </summary>
        /// <param name="dir">The value to assign to the HTML <c>dir</c> attribute.</param>
        /// <returns>The current <see cref="PB_BdoBuilder" /> instance for chaining.</returns>
        public PB_BdoBuilder SetDir(string dir) => SetAttribute("dir", dir);

        #endregion
    }
}