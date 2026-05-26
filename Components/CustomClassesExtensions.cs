#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj CustomClassesExtensions.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides fluent extension methods for custom CSS class composition.
    /// </summary>
    public static class CustomClassesExtensions
    {
        #region Static methods

        /// <summary>
        ///     Adds one custom CSS class to the builder.
        /// </summary>
        /// <typeparam name="TBuilder">The concrete builder type.</typeparam>
        /// <param name="builder">The builder that receives the CSS class.</param>
        /// <param name="cssClass">The CSS class name to add.</param>
        /// <returns>The current builder instance.</returns>
        public static TBuilder AddClass<TBuilder>(
            this TBuilder builder,
            string cssClass
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseCustomClasses
        {
            CustomClassesComposer composer =
                builder.GetOrCreateCssComposer(() => new CustomClassesComposer());

            composer.Add(cssClass);

            return builder;
        }

        /// <summary>
        ///     Adds custom CSS classes to the builder.
        /// </summary>
        /// <typeparam name="TBuilder">The concrete builder type.</typeparam>
        /// <param name="builder">The builder that receives the CSS classes.</param>
        /// <param name="cssClasses">The CSS class names to add.</param>
        /// <returns>The current builder instance.</returns>
        public static TBuilder AddClasses<TBuilder>(
            this TBuilder builder,
            params string[] cssClasses
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseCustomClasses
        {
            CustomClassesComposer composer =
                builder.GetOrCreateCssComposer(() => new CustomClassesComposer());

            composer.AddRange(cssClasses);

            return builder;
        }

        /// <summary>
        ///     Adds custom CSS classes to the builder.
        /// </summary>
        /// <typeparam name="TBuilder">The concrete builder type.</typeparam>
        /// <param name="builder">The builder that receives the CSS classes.</param>
        /// <param name="cssClasses">The CSS class names to add.</param>
        /// <returns>The current builder instance.</returns>
        public static TBuilder AddClasses<TBuilder>(
            this TBuilder builder,
            IEnumerable<string> cssClasses
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseCustomClasses
        {
            CustomClassesComposer composer =
                builder.GetOrCreateCssComposer(() => new CustomClassesComposer());

            composer.AddRange(cssClasses);

            return builder;
        }

        /// <summary>
        ///     Clears the custom classes state.
        /// </summary>
        /// <typeparam name="TBuilder">The concrete builder type.</typeparam>
        /// <param name="builder">The builder whose custom classes are cleared.</param>
        /// <returns>The current builder instance.</returns>
        public static TBuilder ClearCustomClasses<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseCustomClasses
        {
            CustomClassesComposer composer =
                builder.GetOrCreateCssComposer(() => new CustomClassesComposer());

            composer.Clear();

            return builder;
        }

        /// <summary>
        ///     Gets the CSS class value that would currently be rendered by the builder.
        /// </summary>
        /// <typeparam name="TBuilder">The concrete builder type.</typeparam>
        /// <param name="builder">The builder whose classes are inspected.</param>
        /// <returns>The composed CSS class attribute value.</returns>
        public static string GetCurrentClassValue<TBuilder>(this HtmlBuilderBase<TBuilder> builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseCustomClasses
        {
            return builder.BuildClassValue();
        }

        /// <summary>
        ///     Removes one custom CSS class from the builder.
        /// </summary>
        /// <typeparam name="TBuilder">The concrete builder type.</typeparam>
        /// <param name="builder">The builder that owns the custom classes.</param>
        /// <param name="cssClass">The CSS class name to remove.</param>
        /// <returns>The current builder instance.</returns>
        public static TBuilder RemoveClass<TBuilder>(
            this TBuilder builder,
            string cssClass
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseCustomClasses
        {
            CustomClassesComposer composer =
                builder.GetOrCreateCssComposer(() => new CustomClassesComposer());

            composer.Remove(cssClass);

            return builder;
        }

        #endregion
    }
}