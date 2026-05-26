#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_DirBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    [Obsolete("dir is obsolete in HTML5.")]
    /// <summary>
    /// Builds an HTML <c>dir</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_DirBuilder : HtmlTagBuilder<PB_DirBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_DirBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_DirBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "dir";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override PB_DirBuilder CreateInstance() => new(_textWriter, _htmlHelper);

        #endregion
    }
}