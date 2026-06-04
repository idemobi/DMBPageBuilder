#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>colgroup</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ColgroupBuilder : HtmlConstrainedTagBuilder<PB_ColgroupBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.Table
            };

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ColgroupBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ColgroupBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "colgroup";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_ColgroupBuilder CreateInstance()
        {
            return new PB_ColgroupBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Sets the HTML <c>span</c> attribute.
        /// </summary>
        /// <param name="span">The value to assign to the HTML <c>span</c> attribute.</param>
        /// <returns>The current <see cref="PB_ColgroupBuilder" /> instance for chaining.</returns>
        public PB_ColgroupBuilder SetSpan(int span)
        {
            if (span < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(span), span, "Span must be greater than or equal to 1.");
            }

            return SetAttribute("span", span);
        }

        #endregion
    }
}