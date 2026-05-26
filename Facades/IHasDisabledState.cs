#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IHasDisabledState.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for has disabled state.
    /// </summary>
    public interface IHasDisabledState
    {
        #region Instance fields and properties

        bool Disabled { get; set; }

        #endregion
    }
}