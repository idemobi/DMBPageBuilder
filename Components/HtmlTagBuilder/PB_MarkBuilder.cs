#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_MarkBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>mark</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_MarkBuilder : HtmlTagBuilder<PB_MarkBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_MarkBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_MarkBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "mark";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_MarkBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}