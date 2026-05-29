#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Describes an inline stylesheet block rendered by <see cref="PageBuilder" /> in the document head.
    /// </summary>
    /// <remarks>
    ///     Inline stylesheet content is written inside a <c>style</c> tag. Consumers must only pass trusted CSS content.
    /// </remarks>
    public sealed class StyleSheetInline
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the raw CSS content rendered inside the <c>style</c> tag.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the optional stylesheet name used in the generated HTML comment.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        #endregion
    }
}