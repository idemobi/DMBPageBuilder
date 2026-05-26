#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_FieldsetBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>fieldset</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_FieldsetBuilder : HtmlTagBuilder<PB_FieldsetBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_FieldsetBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_FieldsetBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "fieldset";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_FieldsetBuilder CreateInstance()
        {
            return new PB_FieldsetBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}