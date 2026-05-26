#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_MarqueeBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    [Obsolete("marquee is obsolete and non-standard.")]
    /// <summary>
    /// Builds an HTML <c>marquee</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_MarqueeBuilder : HtmlTagBuilder<PB_MarqueeBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_MarqueeBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_MarqueeBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "marquee";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_MarqueeBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}