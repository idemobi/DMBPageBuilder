#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using DMBPageBuilder;

#endregion

namespace DMBPageBuilderLabs.Navigation;

/// <summary>
///     Provides reusable navigation fragments for DMBPageBuilder labs hosts.
/// </summary>
/// <remarks>
///     The agent only builds DMBPageBuilder-specific menu and sidebar fragments. Host websites remain
///     responsible for assembling these fragments into their own navbar providers, sidebar filters, and
///     global navigation structures.
/// </remarks>
public static class DMBPageBuilderLabsNavigationAgent
{
    #region Static methods

    private static AspRouteActionItem CreateAction(
        string action,
        string title,
        string icon,
        string? currentController = null,
        string? currentAction = null
    )
    {
        bool active =
            string.Equals(currentController, "PageBuilder", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase);

        return ActionItemFactory.AspRoute("PageBuilder", action)
            .SetTitle(title)
            .SetIcon(IconStruct.Bootstrap(icon))
            .SetActive(active);
    }

    /// <summary>
    ///     Creates the DMBPageBuilder navbar menu group.
    /// </summary>
    /// <returns>The configured <see cref="GroupActionItem" /> containing DMBPageBuilder labs page links.</returns>
    public static GroupActionItem CreateMenuGroup()
    {
        return ActionItemFactory.Group("DMBPageBuilder", IconStruct.Bootstrap("bi-file-earmark-code"))
            .AddItems(
                ActionItemFactory.Group("General", IconStruct.Bootstrap("bi-info-circle"))
                    .AddItems(
                        CreateAction("Introduction", "Introduction", "bi-info-circle"),
                        CreateAction("GettingStarted", "Getting Started", "bi-play-circle"),
                        CreateAction("Architecture", "Architecture", "bi-diagram-3"),
                        CreateAction("RenderingPipeline", "Rendering Pipeline", "bi-bezier2")
                    ),
                ActionItemFactory.Group("Usage", IconStruct.Bootstrap("bi-terminal"))
                    .AddItems(
                        CreateAction("CSHtml", "Using in Razor (cshtml)", "bi-file-earmark-code"),
                        CreateAction("CSharp", "Using in C#", "bi-braces"),
                        CreateAction("Examples", "Examples", "bi-code-square")
                    ),
                ActionItemFactory.Group("Core Concepts", IconStruct.Bootstrap("bi-boxes"))
                    .AddItems(
                        CreateAction("BuilderLifecycle", "Builder lifecycle", "bi-arrow-repeat"),
                        CreateAction("BodyBuilder", "Layout & BodyBuilder", "bi-layout-text-window"),
                        CreateAction("HtmlBuilderBase", "HtmlBuilderBase", "bi-box"),
                        CreateAction("Attributes", "Attributes", "bi-tag"),
                        CreateAction("Styles", "Styles", "bi-palette"),
                        CreateAction("CSSSystem", "CSS Composers", "bi-layers")
                    ),
                ActionItemFactory.Group("Advanced", IconStruct.Bootstrap("bi-puzzle"))
                    .AddItems(
                        CreateAction("Extensibility", "Extensibility", "bi-puzzle"),
                        CreateAction("Diagnostics", "Debug & Diagnostics", "bi-bug")
                    ),
                ActionItemFactory.Group("Catalog of components", IconStruct.Bootstrap("bi-collection"))
                    .AddItems(
                        CreateAction("HtmlComponents", "HTML tag catalog", "bi-list-ul")
                    )
            );
    }

    /// <summary>
    ///     Creates the DMBPageBuilder sidebar component.
    /// </summary>
    /// <param name="currentController">The current MVC controller name used to mark the active item.</param>
    /// <param name="currentAction">The current MVC action name used to mark the active item.</param>
    /// <param name="sidebarId">The HTML identifier applied to the sidebar component.</param>
    /// <param name="localStorageKey">The browser local-storage key used for sidebar state.</param>
    /// <returns>The configured <see cref="SideBarComponent" />.</returns>
    public static SideBarComponent CreateSidebar(
        string? currentController,
        string? currentAction,
        string sidebarId = "page_builder_sidebar",
        string localStorageKey = "dmbpagebuilder.labs.sidebar"
    )
    {
        SideBarComponent sidebar = new SideBarComponent()
            .WithId(sidebarId)
            .WithLocalStorageKey(localStorageKey)
            .WithAutoExpandActivePath()
            .WithRememberExpandedState();

        sidebar.AddSection(CreateSidebarSection(currentController, currentAction));

        return sidebar;
    }

    /// <summary>
    ///     Creates the DMBPageBuilder sidebar section.
    /// </summary>
    /// <param name="currentController">The current MVC controller name used to mark the active item.</param>
    /// <param name="currentAction">The current MVC action name used to mark the active item.</param>
    /// <returns>The configured <see cref="SideBarSectionComponent" />.</returns>
    public static SideBarSectionComponent CreateSidebarSection(string? currentController, string? currentAction)
    {
        return new SideBarSectionComponent("DMBPageBuilder")
            .Add(
                ActionItemFactory.Group("General", IconStruct.Bootstrap("bi-info-circle"))
                    .AddItems(
                        CreateAction("Introduction", "Introduction", "bi-info-circle", currentController, currentAction),
                        CreateAction("GettingStarted", "Getting Started", "bi-play-circle", currentController, currentAction),
                        CreateAction("Architecture", "Architecture", "bi-diagram-3", currentController, currentAction),
                        CreateAction("RenderingPipeline", "Rendering Pipeline", "bi-bezier2", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Usage", IconStruct.Bootstrap("bi-terminal"))
                    .AddItems(
                        CreateAction("CSHtml", "Using in Razor (cshtml)", "bi-file-earmark-code", currentController, currentAction),
                        CreateAction("CSharp", "Using in C#", "bi-braces", currentController, currentAction),
                        CreateAction("Examples", "Examples", "bi-code-square", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Core Concepts", IconStruct.Bootstrap("bi-boxes"))
                    .AddItems(
                        CreateAction("BuilderLifecycle", "Builder lifecycle", "bi-arrow-repeat", currentController, currentAction),
                        CreateAction("BodyBuilder", "Layout & BodyBuilder", "bi-layout-text-window", currentController, currentAction),
                        CreateAction("HtmlBuilderBase", "HtmlBuilderBase", "bi-box", currentController, currentAction),
                        CreateAction("Attributes", "Attributes", "bi-tag", currentController, currentAction),
                        CreateAction("Styles", "Styles", "bi-palette", currentController, currentAction),
                        CreateAction("CSSSystem", "CSS Composers", "bi-layers", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Advanced", IconStruct.Bootstrap("bi-puzzle"))
                    .AddItems(
                        CreateAction("Extensibility", "Extensibility", "bi-puzzle", currentController, currentAction),
                        CreateAction("Diagnostics", "Debug & Diagnostics", "bi-bug", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Catalog of components", IconStruct.Bootstrap("bi-collection"))
                    .AddItems(
                        CreateAction("HtmlComponents", "HTML tag catalog", "bi-list-ul", currentController, currentAction)
                    )
            );
    }

    /// <summary>
    ///     Resolves the Bootstrap icon for a DMBPageBuilder labs action.
    /// </summary>
    /// <param name="actionName">The MVC action name to resolve.</param>
    /// <returns>The icon value represented as an <see cref="IconStruct" />.</returns>
    public static IconStruct ResolveActionIcon(string? actionName)
    {
        return actionName switch
        {
            "GettingStarted" => IconStruct.Bootstrap("bi-play-circle"),
            "Architecture" => IconStruct.Bootstrap("bi-diagram-3"),
            "RenderingPipeline" => IconStruct.Bootstrap("bi-bezier2"),
            "CSHtml" => IconStruct.Bootstrap("bi-file-earmark-code"),
            "CSharp" => IconStruct.Bootstrap("bi-braces"),
            "Examples" => IconStruct.Bootstrap("bi-code-square"),
            "BuilderLifecycle" => IconStruct.Bootstrap("bi-arrow-repeat"),
            "BodyBuilder" => IconStruct.Bootstrap("bi-layout-text-window"),
            "HtmlBuilderBase" => IconStruct.Bootstrap("bi-box"),
            "Attributes" => IconStruct.Bootstrap("bi-tag"),
            "Styles" => IconStruct.Bootstrap("bi-palette"),
            "CSSSystem" => IconStruct.Bootstrap("bi-layers"),
            "Extensibility" => IconStruct.Bootstrap("bi-puzzle"),
            "Diagnostics" => IconStruct.Bootstrap("bi-bug"),
            "HtmlComponents" => IconStruct.Bootstrap("bi-list-ul"),
            _ => IconStruct.Bootstrap("bi-info-circle")
        };
    }

    /// <summary>
    ///     Resolves the display title for a DMBPageBuilder labs action.
    /// </summary>
    /// <param name="actionName">The MVC action name to resolve.</param>
    /// <returns>The display title for the action.</returns>
    public static string ResolveActionTitle(string? actionName)
    {
        return actionName switch
        {
            "GettingStarted" => "Getting Started",
            "Architecture" => "Architecture",
            "RenderingPipeline" => "Rendering Pipeline",
            "CSHtml" => "Using in Razor (cshtml)",
            "CSharp" => "Using in C#",
            "Examples" => "Examples",
            "BuilderLifecycle" => "Builder lifecycle",
            "BodyBuilder" => "Layout & BodyBuilder",
            "HtmlBuilderBase" => "HtmlBuilderBase",
            "Attributes" => "Attributes",
            "Styles" => "Styles",
            "CSSSystem" => "CSS Composers",
            "Extensibility" => "Extensibility",
            "Diagnostics" => "Debug & Diagnostics",
            "HtmlComponents" => "HTML tag catalog",
            _ => "Introduction"
        };
    }

    #endregion
}