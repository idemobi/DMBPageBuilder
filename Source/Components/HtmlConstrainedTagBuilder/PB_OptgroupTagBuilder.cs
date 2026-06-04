#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>optgroup</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_OptgroupTagBuilder : HtmlConstrainedTagBuilder<PB_OptgroupTagBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds => new[] { HtmlRenderContextKind.Select };

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Optgroup;

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_OptgroupTagBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_OptgroupTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "optgroup";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_OptgroupTagBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        /// <summary>
        ///     Sets the HTML <c>label</c> attribute.
        /// </summary>
        /// <param name="label">The value to assign to the HTML <c>label</c> attribute.</param>
        /// <returns>The current <see cref="PB_OptgroupTagBuilder" /> instance for chaining.</returns>
        public PB_OptgroupTagBuilder SetLabel(string label) => SetAttribute("label", label);

        #endregion
    }
}