#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides Razor helpers for rendering generated lorem ipsum text.
    /// </summary>
    public static class LoremIpsum_HtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Renders a paragraph containing generated lorem ipsum text.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used by the extension method.</param>
        /// <param name="min">The minimum number of words to generate.</param>
        /// <param name="max">The maximum number of words to generate.</param>
        /// <returns>An HTML paragraph containing generated lorem ipsum text.</returns>
        public static IHtmlContent LoremIpsum(this IHtmlHelper htmlHelper, int min, int max)
        {
            string loremText = LoremIpsumGenerator.RandomWords(min, max);
            string tHtml = @$"<p>{loremText}</p>";
            return new HtmlString(tHtml);
        }

        #endregion
    }
}