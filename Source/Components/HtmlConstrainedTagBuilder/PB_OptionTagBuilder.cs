#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>option</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_OptionTagBuilder : HtmlConstrainedTagBuilder<PB_OptionTagBuilder>
    {
        #region Instance fields and properties

        private bool _selected
        {
            get => GetInternal("_selected", false);
            set => SetInternal("_selected", value);
        }

        private string? _text
        {
            get => GetInternal<string?>("_text", null);
            set => SetInternal("_text", value);
        }

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[] { HtmlRenderContextKind.Select, HtmlRenderContextKind.Optgroup, HtmlRenderContextKind.Datalist };

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_OptionTagBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_OptionTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "option";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        public override string BuildAttributes()
        {
            string? previous = GetAttributeValue("selected");
            try
            {
                if (_selected)
                    _attributes["selected"] = "selected";
                else
                    _attributes.Remove("selected");
                return base.BuildAttributes();
            }
            finally
            {
                if (string.IsNullOrWhiteSpace(previous))
                    _attributes.Remove("selected");
                else
                    _attributes["selected"] = previous;
            }
        }

        /// <inheritdoc />
        protected override PB_OptionTagBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>selected</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_OptionTagBuilder" /> instance for chaining.</returns>
        public PB_OptionTagBuilder SetSelected(bool value = true)
        {
            _selected = value;
            return this;
        }

        /// <summary>
        ///     Sets the HTML <c>text</c> attribute.
        /// </summary>
        /// <param name="text">The value to assign to the HTML <c>text</c> attribute.</param>
        /// <returns>The current <see cref="PB_OptionTagBuilder" /> instance for chaining.</returns>
        public PB_OptionTagBuilder SetText(string? text)
        {
            _text = text;
            return this;
        }

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_OptionTagBuilder" /> instance for chaining.</returns>
        public PB_OptionTagBuilder SetValue(string value) => SetAttribute("value", value);

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateTagName();
            writer.Write($"<{_tag}{BuildAttributes()}>");
            if (!string.IsNullOrWhiteSpace(_text))
            {
                writer.Write(HtmlEncoder.Default.Encode(_text));
            }

            writer.Write($"</{_tag}>");
        }

        #endregion
    }
}
