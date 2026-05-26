#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj HtmlComment.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Renders an HTML comment in PageBuilder output.
    /// </summary>
    public sealed class HtmlComment : HtmlCommentBuilder<HtmlComment>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="HtmlComment" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        /// <param name="comment">The comment text to render.</param>
        public HtmlComment(TextWriter writer, IHtmlHelper html, string comment = "comment")
            : base(writer, html, comment)
        {
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override HtmlComment CreateInstance()
        {
            return new HtmlComment(_textWriter, _htmlHelper, GetInternal<string?>("_comment", "comment") ?? "comment");
        }

        #endregion
    }
}