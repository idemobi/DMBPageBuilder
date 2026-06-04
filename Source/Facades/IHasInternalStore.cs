#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines a fluent builder contract for storing implementation-specific state.
    /// </summary>
    /// <typeparam name="TBuilder">
    ///     The concrete builder type returned for fluent chaining.
    /// </typeparam>
    /// <remarks>
    ///     Internal store values are intended for PageBuilder infrastructure and composer extensions.
    ///     They should not be treated as rendered HTML attributes unless an implementation explicitly does so.
    /// </remarks>
    public interface IHasInternalStore<out TBuilder>
    {
        #region Instance methods

        /// <summary>
        ///     Gets a typed value from the internal store.
        /// </summary>
        /// <typeparam name="T">
        ///     The expected value type.
        /// </typeparam>
        /// <param name="key">
        ///     The internal store key.
        /// </param>
        /// <param name="defaultValue">
        ///     The value returned when the key is missing or cannot be resolved as <typeparamref name="T" />.
        /// </param>
        /// <returns>
        ///     The stored value, or <paramref name="defaultValue" /> when no compatible value is available.
        /// </returns>
        T GetInternal<T>(string key, T defaultValue = default!);

        /// <summary>
        ///     Sets or replaces a value in the internal store.
        /// </summary>
        /// <param name="key">
        ///     The internal store key.
        /// </param>
        /// <param name="value">
        ///     The value to store, or <see langword="null" /> when the key should store an explicit null value.
        /// </param>
        /// <returns>
        ///     The current builder instance for fluent chaining.
        /// </returns>
        TBuilder SetInternal(string key, object? value);

        #endregion
    }
}