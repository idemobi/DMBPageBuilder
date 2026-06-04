#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

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