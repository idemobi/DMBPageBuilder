#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides the base implementation for builders that render HTML void tags.
    /// </summary>
    /// <typeparam name="TBuilder">The concrete builder type used for fluent chaining.</typeparam>
    /// <remarks>
    ///     Void tag builders write a single element without an end tag. HTML4 rendering uses a self-closing form,
    ///     while HTML5 rendering writes the standard void-element syntax.
    /// </remarks>
    public abstract class HtmlVoidTagBuilder<TBuilder> : HtmlBuilderBase<TBuilder>
        where TBuilder : HtmlVoidTagBuilder<TBuilder>
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new void-tag builder.
        /// </summary>
        /// <param name="writer">The writer used by immediate rendering APIs.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        protected HtmlVoidTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "br";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            switch (_version)
            {
                case HtmlVersion.Html4:
                    writer.Write($"<{_tag}{BuildAttributes()} />");
                break;

                case HtmlVersion.Html5:
                default:
                    writer.Write($"<{_tag}{BuildAttributes()}>");
                break;
            }
        }

        #endregion
    }
}