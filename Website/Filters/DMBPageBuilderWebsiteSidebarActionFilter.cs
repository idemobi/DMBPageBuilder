#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using DMBBootstrapBuilder;
using DMBPageBuilder;
using DMBPageBuilderLabs.Navigation;
using Microsoft.AspNetCore.Mvc.Filters;

#endregion

namespace DMBPageBuilderWebsite;

internal sealed class DMBPageBuilderWebsiteSidebarActionFilter : IActionFilter
{
    #region Instance methods

    #region From interface IActionFilter

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.Controller is not RawBootstrapController controller)
        {
            return;
        }

        string? currentController = context.RouteData.Values["controller"]?.ToString();
        string? currentAction = context.RouteData.Values["action"]?.ToString();

        if (!string.Equals(currentController, "PageBuilder", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        controller.SetSidebar(DMBPageBuilderLabsNavigationAgent.CreateSidebar(currentController, currentAction));
        controller.AddBreadcrumb(
            ActionItemFactory.Url("Home", "/", IconStruct.Bootstrap("bi-house")),
            ActionItemFactory.AspRoute("PageBuilder", "Introduction")
                .SetTitle("DMBPageBuilder")
                .SetIcon(IconStruct.Bootstrap("bi-file-earmark-code")),
            ActionItemFactory.AspRoute("PageBuilder", string.IsNullOrWhiteSpace(currentAction) ? "Introduction" : currentAction)
                .SetTitle(DMBPageBuilderLabsNavigationAgent.ResolveActionTitle(currentAction))
                .SetIcon(DMBPageBuilderLabsNavigationAgent.ResolveActionIcon(currentAction))
        );
    }

    #endregion

    #endregion
}
