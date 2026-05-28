#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_SelectBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>select</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_SelectBuilder : HtmlConstrainedTagBuilder<PB_SelectBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Select;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_SelectBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_SelectBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "select";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_SelectBuilder CreateInstance()
        {
            return new PB_SelectBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>multiple</c> attribute.
        /// </summary>
        /// <param name="multiple">The value to assign to the HTML <c>multiple</c> attribute.</param>
        /// <returns>The current <see cref="PB_SelectBuilder" /> instance for chaining.</returns>
        public PB_SelectBuilder SetMultiple(bool multiple = true)
        {
            return multiple
                ? SetAttribute("multiple", "multiple")
                : SetAttribute("multiple", (string?)null);
        }

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The value to assign to the HTML <c>name</c> attribute.</param>
        /// <returns>The current <see cref="PB_SelectBuilder" /> instance for chaining.</returns>
        public new PB_SelectBuilder SetName(string name)
        {
            return SetAttribute("name", name);
        }

        /// <summary>
        ///     Sets the HTML <c>size</c> attribute.
        /// </summary>
        /// <param name="size">The value to assign to the HTML <c>size</c> attribute.</param>
        /// <returns>The current <see cref="PB_SelectBuilder" /> instance for chaining.</returns>
        public PB_SelectBuilder SetSize(int size)
        {
            return SetAttribute("size", size);
        }

        #endregion
    }
}