#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageAlertStyle.cs create at 2026/05/07 14:05:43
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines semantic styles available for page-level alerts.
    /// </summary>
    public enum PageAlertStyle
    {
        /// <summary>
        ///     Primary informational style.
        /// </summary>
        Primary,

        /// <summary>
        ///     Secondary neutral style.
        /// </summary>
        Secondary,

        /// <summary>
        ///     Success style.
        /// </summary>
        Success,

        /// <summary>
        ///     Informational style.
        /// </summary>
        Info,

        /// <summary>
        ///     Warning style.
        /// </summary>
        Warning,

        /// <summary>
        ///     Danger or error style.
        /// </summary>
        Danger,

        /// <summary>
        ///     Light neutral style.
        /// </summary>
        Light,

        /// <summary>
        ///     Dark neutral style.
        /// </summary>
        Dark
    }
}