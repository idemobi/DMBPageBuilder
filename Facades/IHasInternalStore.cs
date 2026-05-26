#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IHasInternalStore.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for has internal store.
    /// </summary>
    public interface IHasInternalStore<out TBuilder>
    {
        #region Instance methods

        T GetInternal<T>(string key, T defaultValue = default!);
        TBuilder SetInternal(string key, object value);

        #endregion
    }
}