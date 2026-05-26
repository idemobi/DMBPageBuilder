#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_ScriptBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>script</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ScriptBuilder : HtmlTagBuilder<PB_ScriptBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ScriptBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ScriptBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "script";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ScriptBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>async</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_ScriptBuilder" /> instance for chaining.</returns>
        public PB_ScriptBuilder SetAsync(bool value = true) => value ? SetAttribute("async", "async") : SetAttribute("async", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>defer</c> attribute.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_ScriptBuilder" /> instance for chaining.</returns>
        public PB_ScriptBuilder SetDefer(bool value = true) => value ? SetAttribute("defer", "defer") : SetAttribute("defer", (string?)null);

        /// <summary>
        ///     Sets the no module value.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_ScriptBuilder" /> instance for chaining.</returns>
        public PB_ScriptBuilder SetNoModule(bool value = true) => value ? SetAttribute("nomodule", "nomodule") : SetAttribute("nomodule", (string?)null);

        /// <summary>
        ///     Sets the HTML <c>src</c> attribute.
        /// </summary>
        /// <param name="src">The value to assign to the HTML <c>src</c> attribute.</param>
        /// <returns>The current <see cref="PB_ScriptBuilder" /> instance for chaining.</returns>
        public PB_ScriptBuilder SetSrc(string src) => SetAttribute("src", src);

        /// <summary>
        ///     Sets the HTML <c>type</c> attribute.
        /// </summary>
        /// <param name="type">The value to assign to the HTML <c>type</c> attribute.</param>
        /// <returns>The current <see cref="PB_ScriptBuilder" /> instance for chaining.</returns>
        public PB_ScriptBuilder SetType(string type) => SetAttribute("type", type);

        #endregion
    }
}