#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_BrBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>br</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_BrBuilder : HtmlVoidTagBuilder<PB_BrBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_BrBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_BrBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "br";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_BrBuilder CreateInstance()
        {
            return new PB_BrBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}