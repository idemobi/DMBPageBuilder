#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IHasClassBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for has class builder.
    /// </summary>
    public interface IHasClassBuilder<out TBuilder>
    {
        #region Instance methods

        TBuilder AddClass(string cssClass);

        #endregion
    }
}