#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>form</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_FormBuilder : HtmlTagBuilder<PB_FormBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_FormBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_FormBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "form";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_FormBuilder CreateInstance()
        {
            return new PB_FormBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>action</c> attribute.
        /// </summary>
        /// <param name="action">The value to assign to the HTML <c>action</c> attribute.</param>
        /// <returns>The current <see cref="PB_FormBuilder" /> instance for chaining.</returns>
        public PB_FormBuilder SetAction(string action)
        {
            return SetAttribute("action", action);
        }

        /// <summary>
        ///     Sets the HTML <c>enctype</c> attribute.
        /// </summary>
        /// <param name="enctype">The value to assign to the HTML <c>enctype</c> attribute.</param>
        /// <returns>The current <see cref="PB_FormBuilder" /> instance for chaining.</returns>
        public PB_FormBuilder SetEnctype(string enctype)
        {
            return SetAttribute("enctype", enctype);
        }

        /// <summary>
        ///     Sets the HTML <c>method</c> attribute.
        /// </summary>
        /// <param name="method">The value to assign to the HTML <c>method</c> attribute.</param>
        /// <returns>The current <see cref="PB_FormBuilder" /> instance for chaining.</returns>
        public PB_FormBuilder SetMethod(string method)
        {
            return SetAttribute("method", method);
        }

        #endregion
    }
}