#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_PictureBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>picture</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_PictureBuilder : HtmlTagBuilder<PB_PictureBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_PictureBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_PictureBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "picture";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_PictureBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}