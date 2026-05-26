#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IGuardedActionItem.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for guarded action item.
    /// </summary>
    public interface IGuardedActionItem : IActionItem
    {
        #region Instance fields and properties

        IActionItem InnerAction { get; }

        bool RenderAsButtonGroup { get; set; }
        bool SwitchDefaultValue { get; set; }

        string? SwitchText { get; set; }
        IconStruct WarningIcon { get; set; }

        string? WarningText { get; set; }

        #endregion
    }
}