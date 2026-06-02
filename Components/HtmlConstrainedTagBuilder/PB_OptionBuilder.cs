#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>option</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_OptionBuilder : HtmlConstrainedTagBuilder<PB_OptionBuilder>
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
            new[]
            {
                HtmlRenderContextKind.Select,
                HtmlRenderContextKind.Optgroup
            };

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_OptionBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_OptionBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "option";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        public override string BuildAttributes()
        {
            string? previousSelected = GetAttributeValue("selected");

            try
            {
                if (_selected)
                {
                    _attributes["selected"] = "selected";
                }
                else
                {
                    _attributes.Remove("selected");
                }

                return base.BuildAttributes();
            }
            finally
            {
                if (string.IsNullOrWhiteSpace(previousSelected))
                    _attributes.Remove("selected");
                else
                    _attributes["selected"] = previousSelected;
            }
        }

        /// <inheritdoc />
        protected override PB_OptionBuilder CreateInstance()
        {
            return new PB_OptionBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>selected</c> attribute.
        /// </summary>
        /// <param name="selected">The value to assign to the HTML <c>selected</c> attribute.</param>
        /// <returns>The current <see cref="PB_OptionBuilder" /> instance for chaining.</returns>
        public PB_OptionBuilder SetSelected(bool selected = true)
        {
            _selected = selected;
            return this;
        }

        /// <summary>
        ///     Sets the HTML <c>text</c> attribute.
        /// </summary>
        /// <param name="text">The value to assign to the HTML <c>text</c> attribute.</param>
        /// <returns>The current <see cref="PB_OptionBuilder" /> instance for chaining.</returns>
        public PB_OptionBuilder SetText(string text)
        {
            _text = text;
            return this;
        }

        /// <summary>
        ///     Sets the HTML <c>value</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_OptionBuilder" /> instance for chaining.</returns>
        public PB_OptionBuilder SetValue(string value)
        {
            return SetAttribute("value", value);
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateTagName();
            writer.Write($"<{_tag}{BuildAttributes()}>");

            if (!string.IsNullOrWhiteSpace(_text))
            {
                writer.Write(System.Net.WebUtility.HtmlEncode(_text));
            }

            writer.Write($"</{_tag}>");
        }

        #endregion
    }
}
