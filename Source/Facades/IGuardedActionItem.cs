#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for an action item that wraps another action behind a confirmation or guard UI.
    /// </summary>
    public interface IGuardedActionItem : IActionItem
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets the action that is rendered or executed after the guard condition is accepted.
        /// </summary>
        IActionItem InnerAction { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether the guarded action should render as a button group.
        /// </summary>
        bool RenderAsButtonGroup { get; set; }

        /// <summary>
        ///     Gets or sets the default state used by the guard switch.
        /// </summary>
        bool SwitchDefaultValue { get; set; }

        /// <summary>
        ///     Gets or sets the optional text displayed near the guard switch.
        /// </summary>
        string? SwitchText { get; set; }

        /// <summary>
        ///     Gets or sets the warning icon displayed by the guard UI.
        /// </summary>
        IconStruct WarningIcon { get; set; }

        /// <summary>
        ///     Gets or sets the optional warning text displayed before the inner action is available.
        /// </summary>
        string? WarningText { get; set; }

        #endregion
    }
}