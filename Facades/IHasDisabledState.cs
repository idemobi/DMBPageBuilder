#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IHasDisabledState.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines a contract for objects that expose a disabled rendering state.
    /// </summary>
    public interface IHasDisabledState
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets a value indicating whether the item should render as disabled.
        /// </summary>
        bool Disabled { get; set; }

        #endregion
    }
}
