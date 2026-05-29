#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines a fluent builder contract for adding CSS classes to rendered HTML output.
    /// </summary>
    /// <typeparam name="TBuilder">
    ///     The concrete builder type returned for fluent chaining.
    /// </typeparam>
    public interface IHasClassBuilder<out TBuilder>
    {
        #region Instance methods

        /// <summary>
        ///     Adds a CSS class to the builder output.
        /// </summary>
        /// <param name="cssClass">
        ///     The CSS class name to add. Implementations decide whether empty or duplicate values are ignored.
        /// </param>
        /// <returns>
        ///     The current builder instance for fluent chaining.
        /// </returns>
        TBuilder AddClass(string cssClass);

        #endregion
    }
}