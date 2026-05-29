#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>meter</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_MeterBuilder : HtmlTagBuilder<PB_MeterBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_MeterBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_MeterBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "meter";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_MeterBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>high</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_MeterBuilder" /> instance for chaining.</returns>
        public PB_MeterBuilder SetHigh(decimal value) => SetAttribute("high", value);

        /// <summary>
        ///     Sets the HTML <c>low</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_MeterBuilder" /> instance for chaining.</returns>
        public PB_MeterBuilder SetLow(decimal value) => SetAttribute("low", value);

        /// <summary>
        ///     Sets the HTML <c>max</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_MeterBuilder" /> instance for chaining.</returns>
        public PB_MeterBuilder SetMax(decimal value) => SetAttribute("max", value);

        /// <summary>
        ///     Sets the HTML <c>min</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_MeterBuilder" /> instance for chaining.</returns>
        public PB_MeterBuilder SetMin(decimal value) => SetAttribute("min", value);

        /// <summary>
        ///     Sets the HTML <c>optimum</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_MeterBuilder" /> instance for chaining.</returns>
        public PB_MeterBuilder SetOptimum(decimal value) => SetAttribute("optimum", value);

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_MeterBuilder" /> instance for chaining.</returns>
        public PB_MeterBuilder SetValue(decimal value) => SetAttribute("value", value);

        #endregion
    }
}