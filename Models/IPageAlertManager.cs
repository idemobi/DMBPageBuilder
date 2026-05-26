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
    ///     Defines the contract for page alert manager.
    /// </summary>
    public interface IPageAlertManager
    {
        #region Instance fields and properties

        IReadOnlyList<PageAlertModel> Alerts { get; }

        #endregion

        #region Instance methods

        PageAlertModel AddAlert(PageAlertModel alert);
        PageAlertModel AddAlert(PageAlertLayout layout, PageAlertStyle style, string title, string? message, IEnumerable<string>? details = null);
        PageAlertModel AddError(string title, string? message, IEnumerable<string>? details = null);
        PageAlertModel AddException(Exception exception, IEnumerable<string>? details = null);
        PageAlertModel AddHttpError(int statusCode, string? reasonPhrase, string? originalUrl = null, string? requestUrl = null);
        PageAlertModel? AddInvalidModel(string title, string? message, ModelStateDictionary? modelState);
        void Clear();

        #endregion
    }
}