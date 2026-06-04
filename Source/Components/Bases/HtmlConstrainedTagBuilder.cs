#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides a paired-tag builder base that can validate parent and child HTML rendering contexts.
    /// </summary>
    /// <typeparam name="TBuilder">The concrete builder type used for fluent chaining.</typeparam>
    /// <remarks>
    ///     Constrained builders are used for elements such as table rows, cells, list items, options, and legends,
    ///     where valid HTML depends on the active parent context.
    /// </remarks>
    public abstract class HtmlConstrainedTagBuilder<TBuilder> : HtmlTagBuilder<TBuilder>
        where TBuilder : HtmlConstrainedTagBuilder<TBuilder>
    {
        #region Instance fields and properties

        private HtmlRenderContext? _renderContext;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new constrained tag builder.
        /// </summary>
        /// <param name="writer">The writer used by immediate rendering APIs.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        protected HtmlConstrainedTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
        }

        #endregion

        #region Constraint metadata

        /// <summary>
        ///     Gets the rendering context exposed while this element is open.
        /// </summary>
        protected virtual HtmlRenderContextKind ContextKind => HtmlRenderContextKind.None;

        /// <summary>
        ///     Gets the parent context kinds allowed for this element.
        /// </summary>
        protected virtual IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            Array.Empty<HtmlRenderContextKind>();

        /// <summary>
        ///     Gets a value indicating whether this element requires an active parent context.
        /// </summary>
        protected virtual bool RequiresParentContext => false;

        #endregion

        #region Rendering hooks

        /// <inheritdoc />
        protected override void OnBeginRendering()
        {
            ValidateParentContext();

            if (ContextKind != HtmlRenderContextKind.None)
            {
                _renderContext = new HtmlRenderContext
                {
                    Kind = ContextKind,
                    Owner = this
                };

                HtmlRenderContextManager.Push(HtmlHelper, _renderContext);
            }

            base.OnBeginRendering();
        }

        /// <inheritdoc />
        protected override void OnEndRendering()
        {
            try
            {
                base.OnEndRendering();
            }
            finally
            {
                if (_renderContext != null)
                {
                    HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);

                    if (ReferenceEquals(current, _renderContext))
                    {
                        HtmlRenderContextManager.Pop(HtmlHelper);
                    }

                    _renderContext = null;
                }
            }
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateTagName();
            ValidateParentContext();

            HtmlRenderContext? localContext = null;

            if (ContextKind != HtmlRenderContextKind.None)
            {
                localContext = new HtmlRenderContext
                {
                    Kind = ContextKind,
                    Owner = this
                };

                HtmlRenderContextManager.Push(HtmlHelper, localContext);
            }

            try
            {
                writer.Write($"<{_tag}{BuildAttributes()}>");
                writer.Write($"</{_tag}>");
            }
            finally
            {
                if (localContext != null)
                {
                    HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);

                    if (ReferenceEquals(current, localContext))
                    {
                        HtmlRenderContextManager.Pop(HtmlHelper);
                    }
                }
            }
        }

        #endregion

        #region Validation

        /// <summary>
        ///     Validates the current parent render context before rendering.
        /// </summary>
        protected virtual void ValidateParentContext()
        {
            HtmlRenderContext? parent = HtmlRenderContextManager.Current(HtmlHelper);

            if (!RequiresParentContext)
            {
                return;
            }

            if (parent == null)
            {
                LogConstraintWarning(
                    $"<{_tag}> requires a parent context in [{FormatKinds(AllowedParentContextKinds)}], but no parent context is active.");
                return;
            }

            if (!AllowedParentContextKinds.Contains(parent.Kind))
            {
                LogConstraintWarning(
                    $"<{_tag}> is rendered inside invalid parent context '{parent.Kind}'. Allowed parents: [{FormatKinds(AllowedParentContextKinds)}].");
            }
        }

        private static string FormatKinds(IEnumerable<HtmlRenderContextKind> kinds)
        {
            return string.Join(", ", kinds);
        }

        /// <summary>
        ///     Logs an HTML context warning in debug builds.
        /// </summary>
        /// <param name="message">The warning message.</param>
        [Conditional("DEBUG")]
        protected virtual void LogConstraintWarning(string message)
        {
            Console.Error.WriteLine($"[DMBPageBuilder] {message}");
        }

        #endregion
    }
}
