#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.ModelBinding;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Collects page alerts generated during controller and rendering workflows.
    /// </summary>
    public class PageAlertManager : IPageAlertManager
    {
        #region Static methods

        private static string GetHttpErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                >= 500 => "The server could not complete the request.",
                404 => "The requested page could not be found.",
                405 => "This HTTP method is not allowed for the requested page.",
                401 => "Authentication is required to access this page.",
                403 => "Access to this page is forbidden.",
                >= 400 => "The request could not be completed.",
                >= 300 => "The request was redirected.",
                _ => "The request returned an HTTP status."
            };
        }

        private static List<string> NormalizeDetails(IEnumerable<string>? details)
        {
            if (details == null)
            {
                return new List<string>();
            }

            return details.Where(detail => !string.IsNullOrWhiteSpace(detail)).ToList();
        }

        private static PageAlertStyle ToHttpErrorStyle(int statusCode)
        {
            return statusCode switch
            {
                >= 500 => PageAlertStyle.Danger,
                404 or 405 => PageAlertStyle.Warning,
                >= 400 => PageAlertStyle.Danger,
                >= 300 => PageAlertStyle.Info,
                _ => PageAlertStyle.Info
            };
        }

        #endregion

        #region Instance fields and properties

        private readonly List<PageAlertModel> _alerts = new();

        #region From interface IPageAlertManager

        /// <summary>
        ///     Gets the registered page alerts.
        /// </summary>
        public IReadOnlyList<PageAlertModel> Alerts => _alerts;

        #endregion

        #endregion

        #region Instance methods

        #region From interface IPageAlertManager

        /// <summary>
        ///     Adds an already configured page alert when it contains visible content.
        /// </summary>
        /// <param name="alert">The alert model to register.</param>
        /// <returns>The registered <see cref="PageAlertModel" /> instance.</returns>
        public virtual PageAlertModel AddAlert(PageAlertModel alert)
        {
            ArgumentNullException.ThrowIfNull(alert);
            if (!string.IsNullOrWhiteSpace(alert.Title) || !string.IsNullOrWhiteSpace(alert.Message) || alert.Details.Count > 0)
            {
                _alerts.Add(alert);
            }

            return alert;
        }

        /// <summary>
        ///     Creates and adds a page alert.
        /// </summary>
        /// <param name="layout">The alert layout to render.</param>
        /// <param name="style">The visual style of the alert.</param>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The created <see cref="PageAlertModel" /> instance.</returns>
        public virtual PageAlertModel AddAlert(PageAlertLayout layout, PageAlertStyle style, string title, string? message, IEnumerable<string>? details = null)
        {
            return AddAlert(new PageAlertModel
            {
                Layout = layout,
                Style = style,
                Title = title,
                Message = message,
                Details = NormalizeDetails(details)
            });
        }

        /// <summary>
        ///     Creates and adds a danger alert.
        /// </summary>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The created <see cref="PageAlertModel" /> instance.</returns>
        public virtual PageAlertModel AddError(string title, string? message, IEnumerable<string>? details = null)
        {
            return AddAlert(PageAlertLayout.Alert, PageAlertStyle.Danger, title, message, details);
        }

        /// <summary>
        ///     Creates and adds an alert from an exception.
        /// </summary>
        /// <param name="exception">The exception used to populate the alert.</param>
        /// <param name="details">The optional alert details.</param>
        /// <returns>The created <see cref="PageAlertModel" /> instance.</returns>
        public virtual PageAlertModel AddException(Exception exception, IEnumerable<string>? details = null)
        {
            ArgumentNullException.ThrowIfNull(exception);
            List<string> finalDetails = new();
            finalDetails.Add(exception.GetType().Name);
            finalDetails.AddRange(NormalizeDetails(details));
            return AddError("Exception", exception.Message, finalDetails);
        }

        /// <summary>
        ///     Creates and adds an alert for an HTTP error.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="reasonPhrase">The optional HTTP reason phrase.</param>
        /// <param name="originalUrl">The optional original URL.</param>
        /// <param name="requestUrl">The optional requested URL.</param>
        /// <returns>The created <see cref="PageAlertModel" /> instance.</returns>
        public virtual PageAlertModel AddHttpError(int statusCode, string? reasonPhrase, string? originalUrl = null, string? requestUrl = null)
        {
            string title = string.IsNullOrWhiteSpace(reasonPhrase) ? "HTTP error" : reasonPhrase;
            List<string> details = new();
            if (!string.IsNullOrWhiteSpace(originalUrl))
            {
                details.Add("Original URL: " + originalUrl);
            }

            if (!string.IsNullOrWhiteSpace(requestUrl) && !string.Equals(originalUrl, requestUrl, StringComparison.OrdinalIgnoreCase))
            {
                details.Add("Request URL: " + requestUrl);
            }

            return AddAlert(new PageAlertModel
            {
                Code = statusCode,
                Layout = PageAlertLayout.Alert,
                Style = ToHttpErrorStyle(statusCode),
                Title = title,
                Message = GetHttpErrorMessage(statusCode),
                OriginalUrl = originalUrl,
                RequestUrl = requestUrl,
                Details = details
            });
        }

        /// <summary>
        ///     Creates and adds an alert from model validation errors.
        /// </summary>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="modelState">The model state that contains validation errors.</param>
        /// <returns>The created <see cref="PageAlertModel" />, or <see langword="null" /> when no model state is provided.</returns>
        public virtual PageAlertModel? AddInvalidModel(string title, string? message, ModelStateDictionary? modelState)
        {
            if (modelState == null)
            {
                return null;
            }

            List<string> details = new();
            foreach (KeyValuePair<string, ModelStateEntry> state in modelState)
            {
                if (state.Value == null)
                {
                    continue;
                }

                foreach (ModelError error in state.Value.Errors)
                {
                    if (!string.IsNullOrWhiteSpace(error.ErrorMessage))
                    {
                        details.Add(error.ErrorMessage);
                    }
                }
            }

            return AddAlert(PageAlertLayout.Alert, PageAlertStyle.Warning, title, message, details);
        }

        /// <summary>
        ///     Clears all registered alerts.
        /// </summary>
        public virtual void Clear()
        {
            _alerts.Clear();
        }

        #endregion

        #endregion
    }
}