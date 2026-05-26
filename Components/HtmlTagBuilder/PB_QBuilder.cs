#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_QBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>q</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_QBuilder : HtmlTagBuilder<PB_QBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_QBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_QBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "q";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_QBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>cite</c> attribute.
        /// </summary>
        /// <param name="cite">The value to assign to the HTML <c>cite</c> attribute.</param>
        /// <returns>The current <see cref="PB_QBuilder" /> instance for chaining.</returns>
        public PB_QBuilder SetCite(string cite) => SetAttribute("cite", cite);

        #endregion
    }
}