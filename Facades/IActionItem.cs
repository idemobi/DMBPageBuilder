#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IActionItem.cs create at 2026/05/12 08:05:05
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the shared rendering contract for a PageBuilder action item.
    /// </summary>
    /// <remarks>
    ///     Action items provide metadata used by navigation, buttons, menus, and other command surfaces.
    ///     Implementations decide how these values map to concrete HTML.
    /// </remarks>
    public interface IActionItem
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets a value indicating whether the action represents the active item.
        /// </summary>
        bool Active { get; set; }

        /// <summary>
        ///     Gets or sets additional CSS classes appended to the rendered action.
        /// </summary>
        string AdditionalClasses { get; set; }

        /// <summary>
        ///     Gets or sets the visual style used for the optional badge.
        /// </summary>
        VariantStyle BadgeStyle { get; set; }

        /// <summary>
        ///     Gets or sets the optional badge text rendered near the action title.
        /// </summary>
        string? BadgeText { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the action should render only in debug-oriented contexts.
        /// </summary>
        bool DebugOnly { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the action should render as disabled.
        /// </summary>
        bool Disabled { get; set; }

        /// <summary>
        ///     Gets the HTML attributes assigned to the rendered action.
        /// </summary>
        public IReadOnlyDictionary<string, string> HtmlAttributes { get; }

        /// <summary>
        ///     Gets or sets the icon metadata rendered with the action.
        /// </summary>
        IconStruct Icon { get; set; }

        /// <summary>
        ///     Gets or sets the stable HTML identifier or action identifier.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the action uses an outline visual style.
        /// </summary>
        bool Outline { get; set; }

        /// <summary>
        ///     Gets or sets the Bootstrap-oriented size used by the rendered action.
        /// </summary>
        BoostrapButtonSize Size { get; set; }

        /// <summary>
        ///     Gets or sets the optional subtitle rendered below or near the main title.
        /// </summary>
        string? Subtitle { get; set; }

        /// <summary>
        ///     Gets or sets the optional action title.
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        ///     Gets or sets the visual variant used by the rendered action.
        /// </summary>
        VariantStyle Variant { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Creates a copy of the current action item.
        /// </summary>
        /// <returns>
        ///     A new action item instance with the same public rendering metadata.
        /// </returns>
        IActionItem Clone();

        #endregion
    }
}
