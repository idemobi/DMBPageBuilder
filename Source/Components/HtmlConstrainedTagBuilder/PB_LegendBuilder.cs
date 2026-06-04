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
    ///     Builds an HTML <c>legend</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_LegendBuilder : HtmlConstrainedTagBuilder<PB_LegendBuilder>
    {
        #region Instance fields and properties

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.Fieldset
            };

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_LegendBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_LegendBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "legend";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_LegendBuilder CreateInstance()
        {
            return new PB_LegendBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}