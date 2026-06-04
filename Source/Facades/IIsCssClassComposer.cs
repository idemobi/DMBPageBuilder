#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System.Collections.Generic;

namespace DMBPageBuilder
{
    /// <summary>
    ///     Represents an interface for composing CSS classes in the PageBuilder rendering model.
    ///     Implementations of this interface are responsible for generating a list of CSS class names
    ///     that can be applied to HTML elements. This interface is part of the rendering pipeline,
    ///     allowing for dynamic class composition based on various properties and configurations.
    /// </summary>
    public interface IIsCssClassComposer
    {
        #region Instance methods

        /// <summary>
        ///     Represents a method for building CSS classes in the PageBuilder rendering model.
        ///     This method is part of the <see cref="IIsCssClassComposer" /> interface and is responsible
        ///     for generating a list of CSS class names that can be applied to HTML elements. The method is
        ///     invoked during the rendering pipeline to dynamically compose CSS classes based on various
        ///     properties and configurations.
        /// </summary>
        /// <returns>A read-only list of CSS class names as strings.</returns>
        /// <remarks>
        ///     This method is crucial for the rendering process in the PageBuilder framework. It allows
        ///     for dynamic class composition, enabling developers to apply CSS classes conditionally based on
        ///     the state or configuration of HTML elements. The method is typically called within the
        ///     <see cref="HtmlBuilderBase{TBuilder}.BuildClassValue" /> method, where it contributes to the
        ///     final set of CSS classes applied to an HTML element.
        ///     Implementations of this method should ensure that the returned list of class names is
        ///     valid and does not contain any null or whitespace-only strings. This method should also be
        ///     efficient, as it may be called frequently during the rendering process.
        ///     The method's role in the rendering pipeline is to provide a flexible and dynamic way of
        ///     applying CSS classes, which can enhance the visual presentation and responsiveness of web pages.
        /// </remarks>
        IReadOnlyList<string> BuildClasses();

        /// <summary>
        ///     Represents a method for creating a deep copy of the current instance in the PageBuilder rendering model.
        ///     This method is part of the <see cref="IIsCssClassComposer" /> interface and is responsible for generating
        ///     a new instance with the same state as the current instance. The method is invoked during operations that
        ///     require duplication of the composer's state, such as when building complex HTML elements with varying
        ///     configurations.
        /// </summary>
        /// <returns>A new instance of the same type as the current composer, with the same state.</returns>
        /// <remarks>
        ///     This method is crucial for maintaining consistency and flexibility in the rendering process. It allows
        ///     for the duplication of composers, enabling developers to apply different configurations or styles without
        ///     altering the original composer's state. The method is typically called within the
        ///     <see cref="HtmlBuilderBase{TBuilder}.InternalClone" /> method, where it contributes to the cloning of
        ///     the entire builder's state.
        ///     Implementations of this method should ensure that all relevant properties and configurations are
        ///     accurately copied to the new instance. This method should also be efficient, as it may be called
        ///     frequently during the rendering process.
        ///     The method's role in the rendering pipeline is to provide a robust mechanism for duplicating composers,
        ///     which can enhance the modularity and reusability of web page components.
        /// </remarks>
        IIsCssClassComposer Clone();

        #endregion
    }
}