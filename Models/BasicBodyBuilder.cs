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
    ///     Provides the default <see cref="IBodyBuilder" /> implementation used by <see cref="PageInformation" />.
    /// </summary>
    /// <remarks>
    ///     The default layout writes a standard <c>body</c>, <c>header</c>, <c>main</c>, and <c>footer</c> sequence.
    ///     Consumers can add body and main classes or attributes before <see cref="PageBuilder" /> renders the document.
    /// </remarks>
    public class BasicBodyBuilder : IBodyBuilder
    {
        #region Instance fields and properties

        /// <summary>
        ///     Stores additional attributes rendered on the opening <c>body</c> tag.
        /// </summary>
        public readonly Dictionary<string, string> BodyAttributes = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores CSS classes rendered on the opening <c>body</c> tag.
        /// </summary>
        public readonly List<string> BodyClasses = new();

        /// <summary>
        ///     Stores additional attributes rendered on the opening <c>main</c> tag.
        /// </summary>
        public readonly Dictionary<string, string> MainAttributes = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores CSS classes rendered on the opening <c>main</c> tag.
        /// </summary>
        public readonly List<string> MainClasses = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Renders the encoded attributes and CSS classes for the opening <c>body</c> tag.
        /// </summary>
        /// <returns>The leading-space-prefixed attribute string, or an empty string when no body attributes exist.</returns>
        public string RenderBodyAttributes()
        {
            List<string> attrs = new();

            if (BodyClasses.Count > 0)
            {
                attrs.Add($@"class=""{HtmlEncoder.Default.Encode(string.Join(" ", BodyClasses.Distinct()))}""");
            }

            foreach ((string key, string value) in BodyAttributes)
            {
                HtmlAttributeNameValidator.Validate(key);
                HtmlUrlAttributeValidator.Validate(key, value);
                attrs.Add($@"{key}=""{HtmlEncoder.Default.Encode(value)}""");
            }

            return attrs.Count > 0 ? " " + string.Join(" ", attrs) : string.Empty;
        }

        /// <summary>
        ///     Renders the encoded attributes and CSS classes for the opening <c>main</c> tag.
        /// </summary>
        /// <returns>The leading-space-prefixed attribute string, or an empty string when no main attributes exist.</returns>
        public string RenderMainAttributes()
        {
            List<string> attrs = new();

            if (MainClasses.Count > 0)
            {
                attrs.Add($@"class=""{HtmlEncoder.Default.Encode(string.Join(" ", MainClasses.Distinct()))}""");
            }

            foreach ((string key, string value) in MainAttributes)
            {
                HtmlAttributeNameValidator.Validate(key);
                HtmlUrlAttributeValidator.Validate(key, value);
                attrs.Add($@"{key}=""{HtmlEncoder.Default.Encode(value)}""");
            }

            return attrs.Count > 0 ? " " + string.Join(" ", attrs) : string.Empty;
        }

        #region From interface IBodyBuilder

        /// <inheritdoc />
        public void RenderBodyEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"</body>");
        }

        /// <inheritdoc />
        public void RenderBodyStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"<body{RenderBodyAttributes()}>");
        }

        /// <inheritdoc />
        public void RenderFooterEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"</footer>");
        }

        /// <inheritdoc />
        public void RenderFooterStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"<footer>");
        }

        /// <inheritdoc />
        public void RenderHeaderEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"</header>");
        }

        /// <inheritdoc />
        public void RenderHeaderStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"<header>");
        }

        /// <inheritdoc />
        public void RenderMainEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"</main>");
        }

        /// <inheritdoc />
        public void RenderMainStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"<main{RenderMainAttributes()}>");
        }

        #endregion

        #endregion
    }
}
