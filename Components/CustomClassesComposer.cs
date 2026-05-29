#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Collects custom CSS classes and exposes them to PageBuilder class composition.
    /// </summary>
    public sealed class CustomClassesComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private readonly List<string> _classes = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds a CSS class name to the composed class list.
        /// </summary>
        /// <param name="cssClass">The CSS class name to add when it is not empty.</param>
        /// <returns>The current <see cref="CustomClassesComposer" /> instance.</returns>
        public CustomClassesComposer Add(string cssClass)
        {
            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                _classes.Add(cssClass);
            }

            return this;
        }

        /// <summary>
        ///     Adds a sequence of CSS class names to the composed class list.
        /// </summary>
        /// <param name="cssClasses">The CSS class names to add.</param>
        /// <returns>The current <see cref="CustomClassesComposer" /> instance.</returns>
        public CustomClassesComposer AddRange(IEnumerable<string> cssClasses)
        {
            if (cssClasses == null)
            {
                return this;
            }

            foreach (string cssClass in cssClasses)
            {
                Add(cssClass);
            }

            return this;
        }

        /// <summary>
        ///     Clears all custom CSS classes.
        /// </summary>
        /// <returns>The current <see cref="CustomClassesComposer" /> instance.</returns>
        public CustomClassesComposer Clear()
        {
            _classes.Clear();
            return this;
        }

        /// <summary>
        ///     Removes a CSS class from the composed class list.
        /// </summary>
        /// <param name="cssClass">The CSS class name to remove.</param>
        /// <returns>The current <see cref="CustomClassesComposer" /> instance.</returns>
        public CustomClassesComposer Remove(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
            {
                return this;
            }

            _classes.RemoveAll(x => string.Equals(x, cssClass, StringComparison.Ordinal));
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds the distinct non-empty CSS class list.
        /// </summary>
        /// <returns>The CSS class names collected by this composer.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            return _classes
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.Ordinal)
                .ToList();
        }

        /// <summary>
        ///     Creates a clone of the current composer.
        /// </summary>
        /// <returns>A new composer with the same class names.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new CustomClassesComposer();
            clone.AddRange(_classes);
            return clone;
        }

        #endregion

        #endregion
    }
}