#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IHasStyleBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for has style builder.
    /// </summary>
    public interface IHasStyleBuilder<out TBuilder>
    {
        #region Instance methods

        TBuilder SetStyle(string key, string value, bool important = false);

        #endregion
    }
}