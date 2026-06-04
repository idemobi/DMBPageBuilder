#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>ins</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_InsBuilder : HtmlTagBuilder<PB_InsBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_InsBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_InsBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "ins";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_InsBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>cite</c> attribute.
        /// </summary>
        /// <param name="cite">The value to assign to the HTML <c>cite</c> attribute.</param>
        /// <returns>The current <see cref="PB_InsBuilder" /> instance for chaining.</returns>
        public PB_InsBuilder SetCite(string cite) => SetAttribute("cite", cite);

        /// <summary>
        ///     Sets the date time value.
        /// </summary>
        /// <param name="value">The value to assign to the HTML <c>value</c> attribute.</param>
        /// <returns>The current <see cref="PB_InsBuilder" /> instance for chaining.</returns>
        public PB_InsBuilder SetDateTime(DateTimeOffset value) => SetAttribute("datetime", value);

        #endregion
    }
}