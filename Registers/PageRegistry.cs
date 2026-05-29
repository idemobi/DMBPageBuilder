#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Http;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Stores and retrieves the request-scoped <see cref="PageInformation" /> instance.
    /// </summary>
    /// <remarks>
    ///     The registry uses <see cref="HttpContext.Items" /> so each HTTP request receives its own page model.
    ///     Controllers publish the model before the view renders, and Razor helpers can retrieve it later.
    /// </remarks>
    public static class PageRegistry
    {
        #region Constants

        private const string Key = $"__{nameof(PageRegistry)}_PageInformation__";

        #endregion

        #region Static methods

        /// <summary>
        ///     Gets the current request page information or creates and registers a new instance.
        /// </summary>
        /// <param name="httpContext">The HTTP context storing request-scoped data.</param>
        /// <returns>The existing or newly created <see cref="PageInformation" /> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="httpContext" /> is <see langword="null" />.</exception>
        public static PageInformation GetOrCreatePageInformation(HttpContext httpContext)
        {
            ArgumentNullException.ThrowIfNull(httpContext);
            PageInformation? page = GetPageInformation(httpContext);
            if (page != null)
            {
                return page;
            }

            page = new PageInformation();
            SetPageInformation(httpContext, page);
            return page;
        }

        /// <summary>
        ///     Gets the current request page information when one has already been registered.
        /// </summary>
        /// <param name="httpContext">The HTTP context storing request-scoped data.</param>
        /// <returns>The registered <see cref="PageInformation" />, or <see langword="null" /> when none exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="httpContext" /> is <see langword="null" />.</exception>
        public static PageInformation? GetPageInformation(HttpContext httpContext)
        {
            ArgumentNullException.ThrowIfNull(httpContext);
            return httpContext.Items.TryGetValue(Key, out object? value)
                ? value as PageInformation
                : null;
        }

        /// <summary>
        ///     Registers the page information for the current HTTP request.
        /// </summary>
        /// <param name="httpContext">The HTTP context storing request-scoped data.</param>
        /// <param name="page">The page information to register.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="httpContext" /> or <paramref name="page" /> is <see langword="null" />.
        /// </exception>
        public static void SetPageInformation(HttpContext httpContext, PageInformation page)
        {
            ArgumentNullException.ThrowIfNull(httpContext);
            ArgumentNullException.ThrowIfNull(page);
            httpContext.Items[Key] = page;
        }

        #endregion
    }
}