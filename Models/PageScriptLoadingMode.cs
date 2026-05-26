#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageScriptLoadingMode.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines how a script tag should be loaded by the browser.
    /// </summary>
    public enum PageScriptLoadingMode
    {
        /// <summary>
        ///     Renders the script without <c>async</c> or <c>defer</c>.
        /// </summary>
        Normal,

        /// <summary>
        ///     Renders the script with the <c>async</c> attribute.
        /// </summary>
        Async,

        /// <summary>
        ///     Renders the script with the <c>defer</c> attribute.
        /// </summary>
        Defer
    }
}