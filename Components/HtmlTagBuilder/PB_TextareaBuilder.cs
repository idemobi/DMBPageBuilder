#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_TextareaBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>textarea</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_TextareaBuilder : HtmlTagBuilder<PB_TextareaBuilder>
    {
        #region Instance fields and properties

        private string? _value
        {
            get => GetInternal<string?>("_value", null);
            set => SetInternal("_value", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_TextareaBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_TextareaBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "textarea";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_TextareaBuilder CreateInstance()
        {
            return new PB_TextareaBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>cols</c> attribute.
        /// </summary>
        /// <param name="cols">The value to assign to the HTML <c>cols</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaBuilder" /> instance for chaining.</returns>
        public PB_TextareaBuilder SetCols(int cols)
        {
            return SetAttribute("cols", cols);
        }

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaBuilder" /> instance for chaining.</returns>
        public new PB_TextareaBuilder SetName(string name)
        {
            return SetAttribute("name", name);
        }

        /// <summary>
        ///     Sets the HTML <c>placeholder</c> attribute.
        /// </summary>
        /// <param name="placeholder">The value to assign to the HTML <c>placeholder</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaBuilder" /> instance for chaining.</returns>
        public PB_TextareaBuilder SetPlaceholder(string placeholder)
        {
            return SetAttribute("placeholder", placeholder);
        }

        /// <summary>
        ///     Sets the HTML <c>rows</c> attribute.
        /// </summary>
        /// <param name="rows">The value to assign to the HTML <c>rows</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaBuilder" /> instance for chaining.</returns>
        public PB_TextareaBuilder SetRows(int rows)
        {
            return SetAttribute("rows", rows);
        }

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaBuilder" /> instance for chaining.</returns>
        public PB_TextareaBuilder SetValue(string? value)
        {
            _value = value;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<{_tag}{BuildAttributes()}>");

            if (!string.IsNullOrEmpty(_value))
            {
                writer.Write(System.Net.WebUtility.HtmlEncode(_value));
            }

            writer.Write($"</{_tag}>");
        }

        #endregion
    }
}