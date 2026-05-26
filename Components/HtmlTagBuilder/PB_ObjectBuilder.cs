#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_ObjectBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>object</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ObjectBuilder : HtmlTagBuilder<PB_ObjectBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ObjectBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ObjectBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "object";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ObjectBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>data</c> attribute.
        /// </summary>
        /// <param name="data">The value to assign to the HTML <c>data</c> attribute.</param>
        /// <returns>The current <see cref="PB_ObjectBuilder" /> instance for chaining.</returns>
        public PB_ObjectBuilder SetData(string data) => SetAttribute("data", data);

        /// <summary>
        ///     Sets the HTML <c>height</c> attribute.
        /// </summary>
        /// <param name="height">The value to assign to the HTML <c>height</c> attribute.</param>
        /// <returns>The current <see cref="PB_ObjectBuilder" /> instance for chaining.</returns>
        public PB_ObjectBuilder SetHeight(string height) => SetAttribute("height", height);

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_ObjectBuilder" /> instance for chaining.</returns>
        public PB_ObjectBuilder SetName(string name) => SetAttribute("name", name);

        /// <summary>
        ///     Sets the HTML <c>type</c> attribute.
        /// </summary>
        /// <param name="type">The value to assign to the HTML <c>type</c> attribute.</param>
        /// <returns>The current <see cref="PB_ObjectBuilder" /> instance for chaining.</returns>
        public PB_ObjectBuilder SetType(string type) => SetAttribute("type", type);

        /// <summary>
        ///     Sets the HTML <c>width</c> attribute.
        /// </summary>
        /// <param name="width">The value to assign to the HTML <c>width</c> attribute.</param>
        /// <returns>The current <see cref="PB_ObjectBuilder" /> instance for chaining.</returns>
        public PB_ObjectBuilder SetWidth(string width) => SetAttribute("width", width);

        #endregion
    }
}