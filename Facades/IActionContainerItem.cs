#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IActionContainerItem.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Represents an action container item within the PageBuilder rendering model.
    ///     This interface extends <see cref="IActionItem" /> and is designed to hold
    ///     a collection of child action items, enabling hierarchical structuring of actions.
    /// </summary>
    /// <remarks>
    ///     The <see cref="IActionContainerItem" /> interface is crucial for managing
    ///     complex action hierarchies, allowing for nested actions and dropdowns.
    ///     It participates in the rendering pipeline by providing a list of child items
    ///     that can be rendered recursively.
    ///     Implementations of this interface should ensure proper management of child items,
    ///     including adding, removing, and iterating over them. The <see cref="HasChildren" />
    ///     property indicates whether the container holds any child items, which is essential
    ///     for rendering logic in components like <see cref="SideBarComponent" />.
    ///     This interface is typically used in conjunction with classes such as
    ///     <see cref="SplitActionItem" />, <see cref="GroupActionItem" />,
    ///     and <see cref="ModalActionItem" />, which provide specific implementations
    ///     of action containers with additional functionality.
    ///     The <see cref="Items" /> property provides access to the list of child action items,
    ///     which can be manipulated by implementing classes. This property is used during
    ///     the rendering process to recursively render each child item.
    ///     Implementations of this interface should also consider lifecycle methods such as
    ///     <see cref="WriteTo" />, <see cref="Begin" />, and <see cref="Dispose" /> to manage
    ///     resources effectively, especially when dealing with complex action hierarchies.
    ///     The <see cref="HtmlAttributes" /> property, inherited from <see cref="IActionItem" />,
    ///     can be used to add custom HTML attributes to the container element, allowing for
    ///     further customization of the rendered output.
    ///     In summary, <see cref="IActionContainerItem" /> plays a vital role in the PageBuilder
    ///     rendering model by enabling hierarchical action structuring and facilitating
    ///     recursive rendering of child items.
    /// </remarks>
    public interface IActionContainerItem : IActionItem
    {
        #region Instance fields and properties

        /// <summary>
        ///     Indicates whether the current action container item has any child items.
        /// </summary>
        /// <remarks>
        ///     The <c>HasChildren</c> property is a crucial indicator in the PageBuilder rendering model,
        ///     particularly within the <see cref="ActionContainerBase{TBuilder}" /> and <see cref="SplitActionItem" /> classes.
        ///     It determines whether the action container should render its child items, which is essential for building
        ///     hierarchical UI structures.
        ///     In the rendering pipeline, this property plays a significant role in deciding whether to invoke lifecycle methods
        ///     like <see cref="WriteTo" />
        ///     or <see cref="Dispose" /> on child items. It also contributes to the construction of <see cref="PageInformation" />
        ///     , ensuring that all nested
        ///     elements are accounted for in the final rendered output.
        /// </remarks>
        /// <returns>
        ///     A boolean value indicating whether the action container has child items.
        /// </returns>
        /// <seealso cref="HtmlBuilderBase{TBuilder}" />
        /// <seealso cref="IActionContainerItem" />
        /// <seealso cref="PageInformation" />
        bool HasChildren { get; }

        /// <summary>
        ///     Represents a collection of action items within an action container.
        /// </summary>
        /// <remarks>
        ///     The <c>Items</c> property is a fundamental component of the PageBuilder rendering model,
        ///     particularly within classes that implement <see cref="IActionContainerItem" /> such as
        ///     <see cref="SplitActionItem" />
        ///     and <see cref="ActionContainerBase{TSelf}" />. This property holds a list of child action items that are managed
        ///     and rendered by the container.
        ///     In the rendering pipeline, the <c>Items</c> property is crucial for determining how and when child items are
        ///     processed.
        ///     It influences the invocation of lifecycle methods like <see cref="WriteTo" /> and <see cref="Dispose" />, ensuring
        ///     that
        ///     each child item is properly rendered and disposed of as part of the overall page construction.
        ///     The <c>Items</c> property also contributes to the construction of <see cref="PageInformation" />, providing a
        ///     hierarchical
        ///     representation of the action items that are part of the page. This is essential for generating accurate and
        ///     complete
        ///     HTML output.
        ///     Interaction with <see cref="HtmlBuilderBase{TBuilder}" /> is facilitated through the <c>Items</c> property,
        ///     allowing
        ///     for the dynamic inclusion and exclusion of action items based on rendering context and requirements.
        ///     In summary, the <c>Items</c> property is a key element in managing and rendering action items within the
        ///     PageBuilder
        ///     framework, playing a vital role in the construction of complex UI structures.
        /// </remarks>
        /// <returns>
        ///     A list of action items contained within the action container.
        /// </returns>
        /// <seealso cref="HtmlBuilderBase{TBuilder}" />
        /// <seealso cref="IActionContainerItem" />
        /// <seealso cref="PageInformation" />
        List<IActionItem> Items { get; }

        #endregion
    }
}