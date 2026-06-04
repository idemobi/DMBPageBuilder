#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Manages the stack of active HTML render contexts for the current Razor request.
    /// </summary>
    public static class HtmlRenderContextManager
    {
        #region Constants

        private const string ContextStackKey = "__DMB_HTML_RENDER_CONTEXT_STACK__";

        #endregion

        #region Static methods

        /// <summary>
        ///     Gets the current HTML render context for the Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that owns the context stack.</param>
        /// <returns>The current <see cref="HtmlRenderContext" />, or <see langword="null" /> when no context is active.</returns>
        public static HtmlRenderContext? Current(IHtmlHelper html)
        {
            ArgumentNullException.ThrowIfNull(html);

            Stack<HtmlRenderContext> stack = GetOrCreateStack(html);
            return stack.Count > 0 ? stack.Peek() : null;
        }

        private static Stack<HtmlRenderContext> GetOrCreateStack(IHtmlHelper html)
        {
            object items = html.ViewContext.HttpContext.Items[ContextStackKey] ??= new Stack<HtmlRenderContext>();
            return (Stack<HtmlRenderContext>)items;
        }

        /// <summary>
        ///     Removes the current render context from the current Razor request stack.
        /// </summary>
        /// <param name="html">The Razor HTML helper that owns the context stack.</param>
        /// <returns>The removed <see cref="HtmlRenderContext" />, or <see langword="null" /> when the stack is empty.</returns>
        public static HtmlRenderContext? Pop(IHtmlHelper html)
        {
            ArgumentNullException.ThrowIfNull(html);

            Stack<HtmlRenderContext> stack = GetOrCreateStack(html);
            return stack.Count > 0 ? stack.Pop() : null;
        }

        /// <summary>
        ///     Pushes a render context onto the current Razor request stack.
        /// </summary>
        /// <param name="html">The Razor HTML helper that owns the context stack.</param>
        /// <param name="context">The render context to activate.</param>
        public static void Push(IHtmlHelper html, HtmlRenderContext context)
        {
            ArgumentNullException.ThrowIfNull(html);
            ArgumentNullException.ThrowIfNull(context);

            Stack<HtmlRenderContext> stack = GetOrCreateStack(html);
            stack.Push(context);
        }

        /// <summary>
        ///     Gets a stable snapshot of the active render context stack.
        /// </summary>
        /// <param name="html">The Razor HTML helper that owns the context stack.</param>
        /// <returns>The active render contexts from outermost to innermost.</returns>
        public static IReadOnlyCollection<HtmlRenderContext> Snapshot(IHtmlHelper html)
        {
            ArgumentNullException.ThrowIfNull(html);

            Stack<HtmlRenderContext> stack = GetOrCreateStack(html);
            return stack.Reverse().ToArray();
        }

        #endregion
    }
}