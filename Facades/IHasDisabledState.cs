#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

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