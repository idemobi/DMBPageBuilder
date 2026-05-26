#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj ScriptInline.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Describes an inline script block rendered by <see cref="PageBuilder" />.
    /// </summary>
    /// <remarks>
    ///     Inline script content is written inside a <c>script</c> tag. Consumers must only pass trusted script content.
    /// </remarks>
    public sealed class ScriptInline
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets where the inline script is rendered in the document.
        /// </summary>
        public PageScriptLocation Location { get; set; } = PageScriptLocation.EndOfBody;

        /// <summary>
        ///     Gets or sets the optional script name used in the generated HTML comment.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the raw JavaScript content rendered inside the <c>script</c> tag.
        /// </summary>
        public string Script { get; set; } = string.Empty;

        #endregion
    }
}