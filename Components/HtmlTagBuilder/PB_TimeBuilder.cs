#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_TimeBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>time</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_TimeBuilder : HtmlTagBuilder<PB_TimeBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_TimeBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_TimeBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "time";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_TimeBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the date time value.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_TimeBuilder" /> instance for chaining.</returns>
        public PB_TimeBuilder SetDateTime(DateTimeOffset value) => SetAttribute("datetime", value);

        /// <summary>
        ///     Sets the date time value.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_TimeBuilder" /> instance for chaining.</returns>
        public PB_TimeBuilder SetDateTime(string value) => SetAttribute("datetime", value);

        #endregion
    }
}