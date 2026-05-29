#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder.Resources;
using DMBServerHelper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides fluent helpers for adding alerts to a <see cref="PageInformation" /> instance.
    /// </summary>
    public static class PageInformationAlertExtensions
    {
        #region Static methods

        /// <summary>
        ///     Adds an alert to the page information.
        /// </summary>
        /// <param name="pageInformation">The page information that receives the alert.</param>
        /// <param name="style">The alert visual style.</param>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The current <see cref="PageInformation" /> instance.</returns>
        public static PageInformation AddAlert(this PageInformation pageInformation, PageAlertStyle style, string title, string? message, IEnumerable<string>? details = null)
        {
            ArgumentNullException.ThrowIfNull(pageInformation);
            pageInformation.AlertManager.AddAlert(PageAlertLayout.Alert, style, title, message, details);
            return pageInformation;
        }

        /// <summary>
        ///     Adds a danger alert to the page information.
        /// </summary>
        /// <param name="pageInformation">The page information that receives the alert.</param>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The current <see cref="PageInformation" /> instance.</returns>
        public static PageInformation AddDanger(this PageInformation pageInformation, string title, string? message, IEnumerable<string>? details = null)
        {
            return pageInformation.AddAlert(PageAlertStyle.Danger, title, message, details);
        }

        /// <summary>
        ///     Adds the standard exception alert to the page information.
        /// </summary>
        /// <param name="pageInformation">The page information that receives the alert.</param>
        /// <param name="exception">The exception used to populate the alert.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The current <see cref="PageInformation" /> instance.</returns>
        public static PageInformation AddExceptionAlert(this PageInformation pageInformation, Exception exception, IEnumerable<string>? details = null)
        {
            ArgumentNullException.ThrowIfNull(pageInformation);
            ArgumentNullException.ThrowIfNull(exception);
            List<string> finalDetails = new List<string>
            {
                exception.GetType().Name
            };
            if (details != null)
            {
                finalDetails.AddRange(details.Where(detail => string.IsNullOrWhiteSpace(detail) == false));
            }

            return pageInformation.AddDanger(
                WebLocalizer.GetInternal(nameof(DMBPageBuilderInternalLocalization.PageAlert_Exception_Title)),
                exception.Message,
                finalDetails);
        }

        /// <summary>
        ///     Adds an informational alert to the page information.
        /// </summary>
        /// <param name="pageInformation">The page information that receives the alert.</param>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The current <see cref="PageInformation" /> instance.</returns>
        public static PageInformation AddInfo(this PageInformation pageInformation, string title, string? message, IEnumerable<string>? details = null)
        {
            return pageInformation.AddAlert(PageAlertStyle.Info, title, message, details);
        }

        /// <summary>
        ///     Adds the standard invalid-captcha alert to the page information.
        /// </summary>
        /// <param name="pageInformation">The page information that receives the alert.</param>
        /// <returns>The current <see cref="PageInformation" /> instance.</returns>
        public static PageInformation AddInvalidCaptchaAlert(this PageInformation pageInformation)
        {
            return pageInformation.AddWarning(
                WebLocalizer.GetInternal(nameof(DMBPageBuilderInternalLocalization.PageAlert_InvalidCaptcha_Title)),
                WebLocalizer.GetInternal(nameof(DMBPageBuilderInternalLocalization.PageAlert_InvalidCaptcha_Message)));
        }

        /// <summary>
        ///     Adds the standard invalid-model alert to the page information.
        /// </summary>
        /// <param name="pageInformation">The page information that receives the alert.</param>
        /// <param name="modelState">The model state that contains validation errors.</param>
        /// <returns>The current <see cref="PageInformation" /> instance.</returns>
        public static PageInformation AddInvalidModelAlert(this PageInformation pageInformation, ModelStateDictionary? modelState)
        {
            ArgumentNullException.ThrowIfNull(pageInformation);
            pageInformation.AlertManager.AddInvalidModel(
                WebLocalizer.GetInternal(nameof(DMBPageBuilderInternalLocalization.PageAlert_InvalidModel_Title)),
                WebLocalizer.GetInternal(nameof(DMBPageBuilderInternalLocalization.PageAlert_InvalidModel_Message)),
                modelState);
            return pageInformation;
        }

        /// <summary>
        ///     Adds a success alert to the page information.
        /// </summary>
        /// <param name="pageInformation">The page information that receives the alert.</param>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The current <see cref="PageInformation" /> instance.</returns>
        public static PageInformation AddSuccess(this PageInformation pageInformation, string title, string? message, IEnumerable<string>? details = null)
        {
            return pageInformation.AddAlert(PageAlertStyle.Success, title, message, details);
        }

        /// <summary>
        ///     Adds a warning alert to the page information.
        /// </summary>
        /// <param name="pageInformation">The page information that receives the alert.</param>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The current <see cref="PageInformation" /> instance.</returns>
        public static PageInformation AddWarning(this PageInformation pageInformation, string title, string? message, IEnumerable<string>? details = null)
        {
            return pageInformation.AddAlert(PageAlertStyle.Warning, title, message, details);
        }

        #endregion
    }
}