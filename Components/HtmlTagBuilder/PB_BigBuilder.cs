#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_BigBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    [Obsolete("big is obsolete in HTML5.")]
    /// <summary>
    /// Builds an HTML <c>big</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_BigBuilder : HtmlTagBuilder<PB_BigBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_BigBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_BigBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "big";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_BigBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}