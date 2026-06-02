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
    ///     Builds an HTML <c>region</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_RegionBuilder : HtmlTagBuilder<PB_RegionBuilder>
    {
        #region Instance fields and properties

        private string? _name
        {
            get => GetInternal<string?>("_name", null);
            set => SetInternal("_name", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PB_RegionBuilder" /> class.
        /// </summary>
        /// <param name="writer">The output writer used to render the region markup.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        /// <param name="name">The logical region name written in the generated comments.</param>
        public PB_RegionBuilder(TextWriter writer, IHtmlHelper html, string name)
            : base(writer, html)
        {
            _tag = "div";
            _classesOfComponent.Add("region");
            _name = name?.Trim();
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_RegionBuilder CreateInstance()
        {
            return new PB_RegionBuilder(_textWriter, _htmlHelper, _name ?? string.Empty);
        }

        /// <inheritdoc />
        protected override void OnBeginRendering()
        {
            _textWriter.Write($"<!-- region {HtmlCommentTextEncoder.Encode(_name)} start -->");
        }

        /// <inheritdoc />
        protected override void OnEndRendering()
        {
            _textWriter.Write($"<!-- region {HtmlCommentTextEncoder.Encode(_name)} end -->");
        }

        /// <summary>
        ///     Sets the logical region name written in the generated comments.
        /// </summary>
        /// <param name="name">The logical region name to render.</param>
        /// <returns>The current <see cref="PB_RegionBuilder" /> instance.</returns>
        public new PB_RegionBuilder SetName(string name)
        {
            _name = name?.Trim();
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateTagName();
            writer.Write($"<!-- region {HtmlCommentTextEncoder.Encode(_name)} start -->");
            writer.Write($"<{_tag}{BuildAttributes()}>");
            writer.Write($"</{_tag}>");
            writer.Write($"<!-- region {HtmlCommentTextEncoder.Encode(_name)} end -->");
        }

        #endregion
    }
}
