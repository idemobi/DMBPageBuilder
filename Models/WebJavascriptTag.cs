#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj WebJavascriptTag.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBServerHelper;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    /// Represents a legacy helper that renders one HTML <c>script</c> asset tag.
    /// </summary>
    [Serializable]
    public class WebJavascriptTag
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the legacy anonymous crossorigin setting.
        /// </summary>
        public string Anonymous { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets a value indicating whether the script is rendered with the <c>async</c> attribute.
        /// </summary>
        public bool Async { get; set; } = false;

        /// <summary>
        ///     Gets or sets the crossorigin policy.
        /// </summary>
        public string Crossorigin { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the subresource integrity hash.
        /// </summary>
        public string Integrity { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the script URL rendered in the <c>src</c> attribute.
        /// </summary>
        public string Src { get; set; } = string.Empty;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Renders the configured JavaScript asset as a <c>script</c> tag.
        /// </summary>
        /// <returns>The HTML markup for the configured JavaScript asset.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Src" /> is not set.</exception>
        public string Html()
        {
            if (string.IsNullOrEmpty(Src))
            {
                throw new InvalidOperationException("Src must be set.");
            }

            string asyncAttribut = Async ? "async" : "";
            var scriptTag = $"";
            if (ServerHelperConfiguration.Config.AddLaunchToken)
            {
                if (Src.Contains("?") == false && Src.StartsWith("/") == true)
                {
                    scriptTag += $"<script {asyncAttribut} src=\"{Src}?v={ServerHelperConfiguration.Config.LaunchToken}\"";
                }
                else
                {
                    scriptTag += $"<script {asyncAttribut} src=\"" + Src + "\"";
                }
            }
            else
            {
                scriptTag += $"<script {asyncAttribut} src=\"" + Src + "\"";
            }

            if (!string.IsNullOrEmpty(Anonymous))
            {
                scriptTag += $" crossorigin=\"{Anonymous}\"";
            }

            if (!string.IsNullOrEmpty(Integrity))
            {
                scriptTag += $" integrity=\"{Integrity}\"";
            }

            if (!string.IsNullOrEmpty(Crossorigin))
            {
                scriptTag += $" crossorigin=\"{Crossorigin}\"";
            }

            scriptTag += "></script>";

            return scriptTag;
        }

        #endregion
    }
}
