#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_PlaintextBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    /// Builds an HTML <c>plaintext</c> element for PageBuilder Razor output.
    /// </summary>
    [Obsolete("plaintext is obsolete.")]
    public sealed class PB_PlaintextBuilder : HtmlTagBuilder<PB_PlaintextBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_PlaintextBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_PlaintextBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "plaintext";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_PlaintextBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}