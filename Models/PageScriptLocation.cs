#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageScriptLocation.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

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