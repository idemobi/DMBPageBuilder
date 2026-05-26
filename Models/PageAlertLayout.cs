#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageAlertLayout.cs create at 2026/05/07 14:05:43
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines how a page-level alert should be presented.
    /// </summary>
    public enum PageAlertLayout
    {
        /// <summary>
        ///     Presents the alert inline in the page alert area.
        /// </summary>
        Alert,

        /// <summary>
        ///     Presents the alert as a popup-style message.
        /// </summary>
        PopUp
    }
}