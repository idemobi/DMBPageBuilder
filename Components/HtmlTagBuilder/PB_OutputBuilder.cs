#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_OutputBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>output</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_OutputBuilder : HtmlTagBuilder<PB_OutputBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_OutputBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_OutputBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "output";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_OutputBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>for</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_OutputBuilder" /> instance for chaining.</returns>
        public PB_OutputBuilder SetFor(string value) => SetAttribute("for", value);

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_OutputBuilder" /> instance for chaining.</returns>
        public PB_OutputBuilder SetName(string value) => SetAttribute("name", value);

        #endregion
    }
}