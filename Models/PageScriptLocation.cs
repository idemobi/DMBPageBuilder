#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines where an external or inline script is rendered in the generated HTML document.
    /// </summary>
    public enum PageScriptLocation
    {
        /// <summary>
        ///     Renders the script in the document <c>head</c>.
        /// </summary>
        Head,

        /// <summary>
        ///     Renders the script near the end of the document body.
        /// </summary>
        EndOfBody
    }
}