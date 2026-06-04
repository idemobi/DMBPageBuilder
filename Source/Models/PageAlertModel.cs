#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System.Collections.Generic;

namespace DMBPageBuilder
{
    /// <summary>
    ///     Represents an alert message collected by PageBuilder and rendered by the host UI.
    /// </summary>
    public class PageAlertModel
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the optional status or application code associated with the alert.
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the alert should expose a contact action.
        /// </summary>
        public bool ContactUs { get; set; }

        /// <summary>
        ///     Gets or sets additional detail lines rendered with the alert.
        /// </summary>
        public List<string> Details { get; set; } = new List<string>();

        /// <summary>
        ///     Gets or sets the alert layout used by the renderer.
        /// </summary>
        public PageAlertLayout Layout { get; set; } = PageAlertLayout.Alert;

        /// <summary>
        ///     Gets or sets the main alert message.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        ///     Gets or sets the original URL that caused the alert.
        /// </summary>
        public string? OriginalUrl { get; set; }

        /// <summary>
        ///     Gets or sets the label of the primary action.
        /// </summary>
        public string PrimaryText { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the URL of the primary action.
        /// </summary>
        public string PrimaryUrl { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the URL requested when the alert was created.
        /// </summary>
        public string? RequestUrl { get; set; }

        /// <summary>
        ///     Gets or sets the label of the secondary action.
        /// </summary>
        public string SecondaryText { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the URL of the secondary action.
        /// </summary>
        public string SecondaryUrl { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the visual style of the alert.
        /// </summary>
        public PageAlertStyle Style { get; set; } = PageAlertStyle.Warning;

        /// <summary>
        ///     Gets or sets the optional alert subtitle.
        /// </summary>
        public string Subtitle { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the alert title.
        /// </summary>
        public string? Title { get; set; }

        #endregion
    }
}