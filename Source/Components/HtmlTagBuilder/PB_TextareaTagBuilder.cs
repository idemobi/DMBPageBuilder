#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>textarea</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_TextareaTagBuilder : HtmlTagBuilder<PB_TextareaTagBuilder>
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
        ///     Initializes a new <see cref="PB_TextareaTagBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_TextareaTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "textarea";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_TextareaTagBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>cols</c> attribute.
        /// </summary>
        /// <param name="cols">The value to assign to the HTML <c>cols</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaTagBuilder" /> instance for chaining.</returns>
        public PB_TextareaTagBuilder SetCols(int cols) => SetAttribute("cols", cols);

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaTagBuilder" /> instance for chaining.</returns>
        public new PB_TextareaTagBuilder SetName(string name) => SetAttribute("name", name);

        /// <summary>
        ///     Sets the HTML <c>placeholder</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaTagBuilder" /> instance for chaining.</returns>
        public PB_TextareaTagBuilder SetPlaceholder(string value) => SetAttribute("placeholder", value);

        /// <summary>
        ///     Sets the HTML <c>rows</c> attribute.
        /// </summary>
        /// <param name="rows">The value to assign to the HTML <c>rows</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaTagBuilder" /> instance for chaining.</returns>
        public PB_TextareaTagBuilder SetRows(int rows) => SetAttribute("rows", rows);

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_TextareaTagBuilder" /> instance for chaining.</returns>
        public PB_TextareaTagBuilder SetValue(string? value)
        {
            _value = value;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateTagName();
            writer.Write($"<{_tag}{BuildAttributes()}>");
            if (!string.IsNullOrEmpty(_value))
            {
                writer.Write(HtmlEncoder.Default.Encode(_value));
            }

            writer.Write($"</{_tag}>");
        }

        #endregion
    }
}
