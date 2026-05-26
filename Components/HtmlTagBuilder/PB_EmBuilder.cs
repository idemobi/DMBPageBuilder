#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_EmBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>em</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_EmBuilder : HtmlTagBuilder<PB_EmBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_EmBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_EmBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "em";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_EmBuilder CreateInstance()
        {
            return new PB_EmBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}