#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IPageAlertManager.cs create at 2026/05/07 14:05:43
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.ModelBinding;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for collecting page alerts during a request.
    /// </summary>
    /// <remarks>
    ///     Implementations store alert models that can later be rendered by the page layout or alert components.
    /// </remarks>
    public interface IPageAlertManager
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets the current alert collection in rendering order.
        /// </summary>
        IReadOnlyList<PageAlertModel> Alerts { get; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds an existing alert model to the collection.
        /// </summary>
        /// <param name="alert">
        ///     The alert model to add.
        /// </param>
        /// <returns>
        ///     The added alert model.
        /// </returns>
        PageAlertModel AddAlert(PageAlertModel alert);

        /// <summary>
        ///     Creates and adds a page alert.
        /// </summary>
        /// <param name="layout">
        ///     The alert layout used when rendering.
        /// </param>
        /// <param name="style">
        ///     The alert visual style.
        /// </param>
        /// <param name="title">
        ///     The alert title.
        /// </param>
        /// <param name="message">
        ///     The optional alert message.
        /// </param>
        /// <param name="details">
        ///     Optional detail lines associated with the alert.
        /// </param>
        /// <returns>
        ///     The created alert model.
        /// </returns>
        PageAlertModel AddAlert(PageAlertLayout layout, PageAlertStyle style, string title, string? message, IEnumerable<string>? details = null);

        /// <summary>
        ///     Creates and adds an error alert.
        /// </summary>
        /// <param name="title">
        ///     The alert title.
        /// </param>
        /// <param name="message">
        ///     The optional alert message.
        /// </param>
        /// <param name="details">
        ///     Optional detail lines associated with the alert.
        /// </param>
        /// <returns>
        ///     The created error alert model.
        /// </returns>
        PageAlertModel AddError(string title, string? message, IEnumerable<string>? details = null);

        /// <summary>
        ///     Creates and adds an alert from an exception.
        /// </summary>
        /// <param name="exception">
        ///     The exception that provides the alert content.
        /// </param>
        /// <param name="details">
        ///     Optional detail lines appended to the exception information.
        /// </param>
        /// <returns>
        ///     The created exception alert model.
        /// </returns>
        PageAlertModel AddException(Exception exception, IEnumerable<string>? details = null);

        /// <summary>
        ///     Creates and adds an alert for an HTTP error.
        /// </summary>
        /// <param name="statusCode">
        ///     The HTTP status code.
        /// </param>
        /// <param name="reasonPhrase">
        ///     The optional HTTP reason phrase.
        /// </param>
        /// <param name="originalUrl">
        ///     The optional original URL before error handling or rewriting.
        /// </param>
        /// <param name="requestUrl">
        ///     The optional current request URL.
        /// </param>
        /// <returns>
        ///     The created HTTP error alert model.
        /// </returns>
        PageAlertModel AddHttpError(int statusCode, string? reasonPhrase, string? originalUrl = null, string? requestUrl = null);

        /// <summary>
        ///     Creates and adds an alert from invalid model state.
        /// </summary>
        /// <param name="title">
        ///     The alert title.
        /// </param>
        /// <param name="message">
        ///     The optional alert message.
        /// </param>
        /// <param name="modelState">
        ///     The model state dictionary to inspect, or <see langword="null"/>.
        /// </param>
        /// <returns>
        ///     The created alert model, or <see langword="null"/> when no invalid model state should be rendered.
        /// </returns>
        PageAlertModel? AddInvalidModel(string title, string? message, ModelStateDictionary? modelState);

        /// <summary>
        ///     Removes all stored alerts.
        /// </summary>
        void Clear();

        #endregion
    }
}
