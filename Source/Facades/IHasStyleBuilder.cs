#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines a fluent builder contract for writing inline CSS style declarations.
    /// </summary>
    /// <typeparam name="TBuilder">
    ///     The concrete builder type returned for fluent chaining.
    /// </typeparam>
    public interface IHasStyleBuilder<out TBuilder>
    {
        #region Instance methods

        /// <summary>
        ///     Sets or replaces an inline CSS style declaration.
        /// </summary>
        /// <param name="key">
        ///     The CSS property name.
        /// </param>
        /// <param name="value">
        ///     The CSS property value.
        /// </param>
        /// <param name="important">
        ///     A value indicating whether the declaration should be rendered with <c>!important</c>.
        /// </param>
        /// <returns>
        ///     The current builder instance for fluent chaining.
        /// </returns>
        TBuilder SetStyle(string key, string value, bool important = false);

        #endregion
    }
}