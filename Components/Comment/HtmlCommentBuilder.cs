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
    ///     Provides the base implementation for builders that render HTML comments.
    /// </summary>
    public abstract class HtmlCommentBuilder<TBuilder> : HtmlBuilderBase<TBuilder>
        where TBuilder : HtmlCommentBuilder<TBuilder>
    {
        #region Instance fields and properties

        private string? _comment
        {
            get => GetInternal<string?>("_comment", null);
            set => SetInternal("_comment", value ?? string.Empty);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="HtmlCommentBuilder{TBuilder}" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        /// <param name="comment">The comment text to render.</param>
        protected HtmlCommentBuilder(TextWriter writer, IHtmlHelper html, string comment = "comment")
            : base(writer, html)
        {
            _tag = "!--";
            _comment = comment;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Sets the comment text to render.
        /// </summary>
        /// <param name="comment">The comment text, or <see langword="null" /> to render an empty comment.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetComment(string? comment)
        {
            _comment = comment;
            return This();
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("<!-- ");
            writer.Write(HtmlCommentTextEncoder.Encode(_comment));
            writer.Write(" -->");
        }

        #endregion
    }
}
