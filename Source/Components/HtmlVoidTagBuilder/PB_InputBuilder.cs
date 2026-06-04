#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>input</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_InputBuilder : HtmlVoidTagBuilder<PB_InputBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_InputBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_InputBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "input";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_InputBuilder CreateInstance()
        {
            return new PB_InputBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_InputBuilder" /> instance for chaining.</returns>
        public new PB_InputBuilder SetName(string name)
        {
            return SetAttribute("name", name);
        }

        /// <summary>
        ///     Sets the HTML <c>placeholder</c> attribute.
        /// </summary>
        /// <param name="placeholder">The value to assign to the HTML <c>placeholder</c> attribute.</param>
        /// <returns>The current <see cref="PB_InputBuilder" /> instance for chaining.</returns>
        public PB_InputBuilder SetPlaceholder(string placeholder)
        {
            return SetAttribute("placeholder", placeholder);
        }

        /// <summary>
        ///     Sets the HTML <c>required</c> attribute.
        /// </summary>
        /// <param name="required">The value to assign to the HTML <c>required</c> attribute.</param>
        /// <returns>The current <see cref="PB_InputBuilder" /> instance for chaining.</returns>
        public PB_InputBuilder SetRequired(bool required = true)
        {
            return required
                ? SetAttribute("required", "required")
                : SetAttribute("required", (string?)null);
        }

        /// <summary>
        ///     Sets the HTML <c>type</c> attribute.
        /// </summary>
        /// <param name="type">The value to assign to the HTML <c>type</c> attribute.</param>
        /// <returns>The current <see cref="PB_InputBuilder" /> instance for chaining.</returns>
        public PB_InputBuilder SetType(string type)
        {
            return SetAttribute("type", type);
        }

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_InputBuilder" /> instance for chaining.</returns>
        public PB_InputBuilder SetValue(string value)
        {
            return SetAttribute("value", value);
        }

        #endregion
    }
}