#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageScriptDefinition.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Describes one external script file that <see cref="PageBuilder" /> renders as a <c>script</c> tag.
    /// </summary>
    /// <remarks>
    ///     Script definitions are stored in <see cref="PageInformation.Scripts" /> and are deduplicated by URL when
    ///     registered through <see cref="PageInformation.AddScript(PageScriptDefinition)" />.
    /// </remarks>
    public sealed class PageScriptDefinition
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the crossorigin policy rendered on the script tag.
        /// </summary>
        public PageCrossOrigin CrossOrigin { get; set; } = PageCrossOrigin.None;

        /// <summary>
        ///     Gets or sets the optional subresource integrity hash rendered on the script tag.
        /// </summary>
        public string? Integrity { get; set; }

        /// <summary>
        ///     Gets or sets how the browser loads the script.
        /// </summary>
        public PageScriptLoadingMode LoadingMode { get; set; } = PageScriptLoadingMode.Defer;

        /// <summary>
        ///     Gets or sets where the script is rendered in the document.
        /// </summary>
        public PageScriptLocation Location { get; set; } = PageScriptLocation.EndOfBody;

        /// <summary>
        ///     Gets or sets the ordering value used among scripts in the same location.
        /// </summary>
        public int Order { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the optional script MIME type.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        ///     Gets or sets the script URL rendered in the <c>src</c> attribute.
        /// </summary>
        public string Url { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Sets the crossorigin policy for the script tag.
        /// </summary>
        /// <param name="crossOrigin">The crossorigin policy to render.</param>
        /// <returns>The current <see cref="PageScriptDefinition" /> for chaining.</returns>
        public PageScriptDefinition SetCrossOrigin(PageCrossOrigin crossOrigin)
        {
            CrossOrigin = crossOrigin;
            return this;
        }

        /// <summary>
        ///     Sets the optional subresource integrity hash for the script tag.
        /// </summary>
        /// <param name="integrity">The integrity hash, or <see langword="null" /> to omit the attribute.</param>
        /// <returns>The current <see cref="PageScriptDefinition" /> for chaining.</returns>
        public PageScriptDefinition SetIntegrity(string? integrity)
        {
            Integrity = integrity;
            return this;
        }

        /// <summary>
        ///     Sets the ordering value used when scripts are rendered.
        /// </summary>
        /// <param name="order">The script ordering value. Lower values render earlier in the same location.</param>
        /// <returns>The current <see cref="PageScriptDefinition" /> for chaining.</returns>
        public PageScriptDefinition SetOrder(int order)
        {
            Order = order;
            return this;
        }

        #endregion
    }
}