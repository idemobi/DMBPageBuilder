#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_LinkBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>link</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_LinkBuilder : HtmlVoidTagBuilder<PB_LinkBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_LinkBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_LinkBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "link";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_LinkBuilder CreateInstance()
        {
            return new PB_LinkBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>href</c> attribute.
        /// </summary>
        /// <param name="href">The value to assign to the HTML <c>href</c> attribute.</param>
        /// <returns>The current <see cref="PB_LinkBuilder" /> instance for chaining.</returns>
        public PB_LinkBuilder SetHref(string href)
        {
            return SetAttribute("href", href);
        }

        /// <summary>
        ///     Sets the HTML <c>rel</c> attribute.
        /// </summary>
        /// <param name="rel">The value to assign to the HTML <c>rel</c> attribute.</param>
        /// <returns>The current <see cref="PB_LinkBuilder" /> instance for chaining.</returns>
        public PB_LinkBuilder SetRel(string rel)
        {
            return SetAttribute("rel", rel);
        }

        /// <summary>
        ///     Sets the HTML <c>type</c> attribute.
        /// </summary>
        /// <param name="type">The value to assign to the HTML <c>type</c> attribute.</param>
        /// <returns>The current <see cref="PB_LinkBuilder" /> instance for chaining.</returns>
        public PB_LinkBuilder SetType(string type)
        {
            return SetAttribute("type", type);
        }

        #endregion
    }
}