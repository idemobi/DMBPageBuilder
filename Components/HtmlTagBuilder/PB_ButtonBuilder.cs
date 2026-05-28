#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_ButtonBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>button</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ButtonBuilder : HtmlTagBuilder<PB_ButtonBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ButtonBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ButtonBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "button";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ButtonBuilder CreateInstance()
        {
            return new PB_ButtonBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_ButtonBuilder" /> instance for chaining.</returns>
        public new PB_ButtonBuilder SetName(string name)
        {
            return SetAttribute("name", name);
        }

        /// <summary>
        ///     Sets the HTML <c>type</c> attribute.
        /// </summary>
        /// <param name="type">The value to assign to the HTML <c>type</c> attribute.</param>
        /// <returns>The current <see cref="PB_ButtonBuilder" /> instance for chaining.</returns>
        public PB_ButtonBuilder SetType(string type)
        {
            return SetAttribute("type", type);
        }

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_ButtonBuilder" /> instance for chaining.</returns>
        public PB_ButtonBuilder SetValue(string value)
        {
            return SetAttribute("value", value);
        }

        #endregion
    }
}