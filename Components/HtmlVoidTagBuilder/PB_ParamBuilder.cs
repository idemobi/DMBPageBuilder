#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_ParamBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>param</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ParamBuilder : HtmlVoidTagBuilder<PB_ParamBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ParamBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ParamBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "param";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ParamBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_ParamBuilder" /> instance for chaining.</returns>
        public new PB_ParamBuilder SetName(string name) => SetAttribute("name", name);

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_ParamBuilder" /> instance for chaining.</returns>
        public PB_ParamBuilder SetValue(string value) => SetAttribute("value", value);

        #endregion
    }
}