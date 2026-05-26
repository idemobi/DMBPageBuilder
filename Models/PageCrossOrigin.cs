#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageCrossOrigin.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the crossorigin attribute value rendered on script and link tags.
    /// </summary>
    public enum PageCrossOrigin
    {
        /// <summary>
        ///     Omits the <c>crossorigin</c> attribute.
        /// </summary>
        None,

        /// <summary>
        ///     Renders <c>crossorigin="anonymous"</c>.
        /// </summary>
        Anonymous,

        /// <summary>
        ///     Renders <c>crossorigin="use-credentials"</c>.
        /// </summary>
        UseCredentials
    }
}