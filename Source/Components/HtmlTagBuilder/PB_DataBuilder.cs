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
    ///     Builds an HTML <c>data</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_DataBuilder : HtmlTagBuilder<PB_DataBuilder>
    {
        #region Instance fields and properties

        private string? _text
        {
            get => GetInternal<string?>("_text", null);
            set => SetInternal("_text", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_DataBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_DataBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "data";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_DataBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>text</c> attribute.
        /// </summary>
        /// <param name="text">The value to assign to the HTML <c>text</c> attribute.</param>
        /// <returns>The current <see cref="PB_DataBuilder" /> instance for chaining.</returns>
        public PB_DataBuilder SetText(string? text)
        {
            _text = text;
            return this;
        }

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_DataBuilder" /> instance for chaining.</returns>
        public PB_DataBuilder SetValue(string value) => SetAttribute("value", value);

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateTagName();
            writer.Write($"<{_tag}{BuildAttributes()}>");
            if (!string.IsNullOrEmpty(_text))
            {
                writer.Write(HtmlEncoder.Default.Encode(_text));
            }

            writer.Write($"</{_tag}>");
        }

        #endregion
    }
}
