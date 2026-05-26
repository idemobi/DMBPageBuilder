#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_AbbrBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>abbr</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_AbbrBuilder : HtmlTagBuilder<PB_AbbrBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_AbbrBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_AbbrBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "abbr";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_AbbrBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}