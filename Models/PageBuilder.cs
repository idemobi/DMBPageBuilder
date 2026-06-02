#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using System.Text.Encodings.Web;
using DMBServerHelper;
using DMBServerWebHelper;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schema.NET;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Renders a complete HTML document shell from a <see cref="PageInformation" /> instance.
    /// </summary>
    /// <remarks>
    ///     Layout views typically call <see cref="RenderDocumentStart(HttpContext)" /> before rendering Razor body
    ///     content and <see cref="RenderDocumentEnd(HttpContext)" /> after the body content. The builder writes the
    ///     document head, body regions, global assets, metadata, schema.org blocks, inline scripts, and cookie consent UI.
    /// </remarks>
    public sealed class PageBuilder
    {
        #region Static methods

        private static string AppendVersion(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return url;
            if (url.StartsWith("/") && ServerHelperConfiguration.Config.AddLaunchToken)
            {
                string separator = url.Contains('?') ? "&" : "?";
                return $"{url}{separator}v={ServerHelperConfiguration.Config.LaunchToken}";
            }

            return url;
        }

        private static void WriteArtificialIntelligenceMeta(TextWriter writer, string name, string? content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }

            WriteMeta(writer, PageMetaDefinition.NameMeta(name, content));
        }

        private static void WriteArtificialIntelligenceMetaData(TextWriter writer, PageArtificialIntelligenceMetaData metaData)
        {
            writer.Write("<!-- AI profile -->");
            WriteArtificialIntelligenceMeta(writer, "ai:purpose", metaData.Purpose);
            WriteArtificialIntelligenceMeta(writer, "ai:audience", metaData.Audience);
            WriteArtificialIntelligenceMeta(writer, "ai:summary-policy", metaData.SummaryPolicy);

            if (metaData.Citation)
            {
                WriteArtificialIntelligenceMeta(writer, "ai:citation", "required");
            }

            WriteArtificialIntelligenceMeta(writer, "ai:license", metaData.License);
            WriteArtificialIntelligenceMeta(writer, "ai:training-permission", metaData.TrainingPermission);
            WriteArtificialIntelligenceMeta(writer, "ai:quotas", metaData.Quotas);
            WriteArtificialIntelligenceMeta(writer, "ai:disclaimer", metaData.Disclaimer);
        }

        private static void WriteLink(TextWriter writer, PageLinkDefinition link)
        {
            HtmlUrlAttributeValidator.Validate("href", link.Href);
            writer.Write($@"<link rel=""{link.Rel.GetValue()}"" href=""{HtmlEncoder.Default.Encode(AppendVersion(link.Href))}""");

            if (!string.IsNullOrWhiteSpace(link.Type))
            {
                writer.Write($@" type=""{HtmlEncoder.Default.Encode(link.Type)}""");
            }

            if (!string.IsNullOrWhiteSpace(link.Sizes))
            {
                writer.Write($@" sizes=""{HtmlEncoder.Default.Encode(link.Sizes)}""");
            }

            if (!string.IsNullOrWhiteSpace(link.As))
            {
                writer.Write($@" as=""{HtmlEncoder.Default.Encode(link.As)}""");
            }

            if (link.CrossOrigin != PageCrossOrigin.None)
            {
                writer.Write($@" crossorigin=""{HtmlEncoder.Default.Encode(link.CrossOrigin.GetValue())}""");
            }

            if (!string.IsNullOrWhiteSpace(link.Integrity))
            {
                writer.Write($@" integrity=""{HtmlEncoder.Default.Encode(link.Integrity)}""");
            }

            #if DEBUG
            writer.Write($@" order=""{HtmlEncoder.Default.Encode(link.Order.ToString(CultureInfo.InvariantCulture))}""");
            #endif

            writer.Write(">");
        }

        private static void WriteMeta(TextWriter writer, PageMetaDefinition meta)
        {
            string order = string.Empty;
            #if DEBUG
            order = $@" order=""{HtmlEncoder.Default.Encode(meta.Order.ToString(CultureInfo.InvariantCulture))}""";
            #endif

            switch (meta.Kind)
            {
                case PageMetaKind.Charset:
                    writer.Write($@"<meta charset=""{HtmlEncoder.Default.Encode(meta._Charset ?? "utf-8")}""{order}>");
                break;

                case PageMetaKind.Name:
                    writer.Write($@"<meta name=""{HtmlEncoder.Default.Encode(meta.Name ?? string.Empty)}"" content=""{HtmlEncoder.Default.Encode(meta.Content ?? string.Empty)}""{order}>");
                break;

                case PageMetaKind.Property:
                    writer.Write($@"<meta property=""{HtmlEncoder.Default.Encode(meta.Name ?? string.Empty)}"" content=""{HtmlEncoder.Default.Encode(meta.Content ?? string.Empty)}""{order}>");
                break;

                case PageMetaKind.HttpEquiv:
                    writer.Write($@"<meta http-equiv=""{HtmlEncoder.Default.Encode(meta.Name ?? string.Empty)}"" content=""{HtmlEncoder.Default.Encode(meta.Content ?? string.Empty)}""{order}>");
                break;
            }
        }

        private static void WriteSchemaOrg(TextWriter writer, IThing schema)
        {
            if (schema is not Thing thing)
            {
                return;
            }

            writer.Write(@"<script type=""application/ld+json"">");
            writer.Write(thing.ToHtmlEscapedString());
            writer.Write("</script>");
        }

        private static void WriteScript(TextWriter writer, PageScriptDefinition script)
        {
            HtmlUrlAttributeValidator.Validate("src", script.Url ?? string.Empty);
            writer.Write("<script");
            if (!string.IsNullOrWhiteSpace(script.Type))
            {
                writer.Write($@" type=""{HtmlEncoder.Default.Encode(script.Type)}""");
            }

            writer.Write($@" src=""{HtmlEncoder.Default.Encode(AppendVersion(script.Url ?? string.Empty))}""");

            if (script.LoadingMode == PageScriptLoadingMode.Async)
            {
                writer.Write(" async");
            }
            else if (script.LoadingMode == PageScriptLoadingMode.Defer)
            {
                writer.Write(" defer");
            }

            if (script.CrossOrigin != PageCrossOrigin.None)
            {
                writer.Write($@" crossorigin=""{HtmlEncoder.Default.Encode(script.CrossOrigin.GetValue())}""");
            }

            if (!string.IsNullOrWhiteSpace(script.Integrity))
            {
                writer.Write($@" integrity=""{HtmlEncoder.Default.Encode(script.Integrity)}""");
            }

            #if DEBUG
            writer.Write($@" order=""{HtmlEncoder.Default.Encode(script.Order.ToString(CultureInfo.InvariantCulture))}""");
            #endif

            writer.Write("></script>");
            return;
        }

        private static void WriteScriptInline(TextWriter writer, ScriptInline script)
        {
            if (!string.IsNullOrWhiteSpace(script.Name))
            {
                writer.Write($@"<!-- Script inline {HtmlCommentTextEncoder.Encode(script.Name)} -->");
            }

            writer.Write("<script>");
            writer.Write(HtmlRawElementContentEncoder.EncodeClosingElement(script.Script, "script"));
            writer.Write("</script>");
        }

        private static void WriteStyleSheetInline(TextWriter writer, StyleSheetInline stylesheet)
        {
            if (!string.IsNullOrWhiteSpace(stylesheet.Name))
            {
                writer.Write($@"<!-- StyleSheet inline {HtmlCommentTextEncoder.Encode(stylesheet.Name)} -->");
            }

            writer.Write("<style>");
            writer.Write(HtmlRawElementContentEncoder.EncodeClosingElement(stylesheet.Content, "style"));
            writer.Write("</style>");
        }

        #endregion

        #region Instance fields and properties

        private readonly IHtmlHelper _html;
        private readonly PageInformation _page;
        private StringWriter _writerEndBody = new(CultureInfo.InvariantCulture);
        private StringWriter _writerStartBody = new(CultureInfo.InvariantCulture);

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PageBuilder" /> instance for a Razor HTML helper and page model.
        /// </summary>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <param name="page">The page information to render.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="html" /> or <paramref name="page" /> is <see langword="null" />.
        /// </exception>
        public PageBuilder(IHtmlHelper html, PageInformation page)
        {
            _html = html ?? throw new ArgumentNullException(nameof(html));
            _page = page ?? throw new ArgumentNullException(nameof(page));
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Renders the closing body regions, end-of-body scripts, optional cookie consent UI, and closing document tag.
        /// </summary>
        /// <param name="context">The current HTTP context used to evaluate cookie consent state.</param>
        /// <returns>The rendered HTML content for the end of the document.</returns>
        public IHtmlContent RenderDocumentEnd(HttpContext context)
        {
            using StringWriter writer = new();
            if (_page.NeedCookieConsent)
            {
                CookieBool? cookieConsent = ServerWebHelperConfiguration.CookieConsent;
                if (cookieConsent != null && cookieConsent.GetValue(context) == false)
                {
                    if (_page.CookieConsentComposer != null)
                    {
                        writer.Write(_page.CookieConsentComposer.RenderCookieConsent(_html, _page, cookieConsent, context));
                    }
                }
            }

            writer.Write(_writerEndBody.ToString());
            writer.Write("<!-- Render content end -->");
            writer.Write("</html>");
            return new HtmlString(writer.ToString());
        }

        /// <summary>
        ///     Renders the document start, head content, opening body regions, and opening main content region.
        /// </summary>
        /// <param name="context">The current HTTP context for the rendering request.</param>
        /// <returns>The rendered HTML content for the start of the document.</returns>
        /// <remarks>
        ///     This method prepares the matching closing markup internally. Call
        ///     <see cref="RenderDocumentEnd(HttpContext)" /> after the Razor body content has been written.
        /// </remarks>
        public IHtmlContent RenderDocumentStart(HttpContext context)
        {
            ResetBodyWriters();
            RenderDocumentStartBody();
            RenderDocumentEndBody();

            using StringWriter writer = new();
            writer.Write("<!doctype html>");
            #if DEBUG
            writer.Write("<!-- https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/ -->");
            #endif
            string lang = _page.Culture?.Name ?? CultureInfo.CurrentCulture.Name;
            writer.Write($@"<html lang=""{HtmlEncoder.Default.Encode(lang)}"">");
            writer.Write(RenderHeadString());
            writer.Write("<!-- Render content start -->");
            writer.Write(_writerStartBody.ToString());
            return new HtmlString(writer.ToString());
        }

        private void RenderDocumentEndBody()
        {
            _page.BodyBuilder.RenderMainEnd(_writerEndBody, _html, _page);
            _page.BodyBuilder.RenderFooterStart(_writerEndBody, _html, _page);
            _page.BodyBuilder.RenderFooterEnd(_writerEndBody, _html, _page);
            _writerEndBody.Write(RenderEndOfBodyScriptsString());
            _page.BodyBuilder.RenderBodyEnd(_writerEndBody, _html, _page);
        }

        private void RenderDocumentStartBody()
        {
            _page.BodyBuilder.RenderBodyStart(_writerStartBody, _html, _page);
            _page.BodyBuilder.RenderHeaderStart(_writerStartBody, _html, _page);
            _page.BodyBuilder.RenderHeaderEnd(_writerStartBody, _html, _page);
            _page.BodyBuilder.RenderMainStart(_writerStartBody, _html, _page);
        }

        private void ResetBodyWriters()
        {
            _writerStartBody = new StringWriter(CultureInfo.InvariantCulture);
            _writerEndBody = new StringWriter(CultureInfo.InvariantCulture);
        }

        private string RenderEndOfBodyScriptsString()
        {
            using StringWriter writer = new();
            writer.Write($@"<!-- scripts end of body tags -->");
            foreach (PageScriptDefinition script in _page.Scripts.Values.Where(x => x.Location == PageScriptLocation.EndOfBody).OrderBy(x => x.Order))
            {
                WriteScript(writer, script);
            }

            foreach (ScriptInline script in _page.ScriptsInline.Values.Where(x => x.Location == PageScriptLocation.EndOfBody))
            {
                WriteScriptInline(writer, script);
            }

            return writer.ToString();
        }

        private string RenderHeadString()
        {
            using StringWriter writer = new();

            writer.Write(@$"<head page-builder=""true"">");

            bool hasViewport = _page.Metas.Any(x =>
                x.Kind == PageMetaKind.Name &&
                string.Equals(x.Name, "viewport", StringComparison.OrdinalIgnoreCase));

            if (!hasViewport)
            {
                writer.Write($@"<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">");
            }

            if (!string.IsNullOrWhiteSpace(_page.Title))
            {
                writer.Write($@"<title>{HtmlEncoder.Default.Encode(_page.Title)}</title>");
            }

            writer.Write($@"<!-- metas tags -->");
            if (_page.Keywords.Count > 0 && _page.Metas.Any(x =>
                    x.Kind == PageMetaKind.Name &&
                    string.Equals(x.Name, PageMetaName.Keywords.GetValue(), StringComparison.OrdinalIgnoreCase)) == false)
            {
                WriteMeta(writer, PageMetaDefinition.NameMeta(
                        PageMetaName.Keywords,
                        string.Join(", ", _page.Keywords.Where(x => !string.IsNullOrWhiteSpace(x))))
                    .SetOrder(_page.KeywordsOrder));
            }

            foreach (PageMetaDefinition meta in _page.Metas.OrderBy(x => x.Order))
            {
                WriteMeta(writer, meta);
            }

            if (_page.ArtificialIntelligenceMetaData != null)
            {
                WriteArtificialIntelligenceMetaData(writer, _page.ArtificialIntelligenceMetaData);
            }

            writer.Write($@"<!-- favicons tags -->");
            WriteFavicons(writer);
            writer.Write($@"<!-- links tags -->");

            foreach (PageLinkDefinition link in _page.Links.Values.OrderBy(x => x.Order))
            {
                WriteLink(writer, link);
            }

            if (_page.SchemaOrg.Count > 0)
            {
                writer.Write($@"<!-- schema.org JSON-LD -->");
                foreach (IThing schema in _page.SchemaOrg)
                {
                    WriteSchemaOrg(writer, schema);
                }
            }

            if (_page.StylesheetsInline.Count > 0)
            {
                writer.Write($@"<!-- style sheets inline -->");
            }

            foreach (StyleSheetInline stylesheet in _page.StylesheetsInline.Values)
            {
                WriteStyleSheetInline(writer, stylesheet);
            }

            writer.Write($@"<!-- scripts tags {_page.Id} elements in table Scripts {_page.Scripts.Count} -->");
            foreach (PageScriptDefinition script in _page.Scripts.Values.Where(x => x.Location == PageScriptLocation.Head).OrderBy(x => x.Order))
            {
                WriteScript(writer, script);
            }

            writer.Write($@"<!-- scripts inline tags {_page.Id} elements in table Scripts {_page.ScriptsInline.Count} -->");
            foreach (ScriptInline script in _page.ScriptsInline.Values.Where(x => x.Location == PageScriptLocation.Head))
            {
                WriteScriptInline(writer, script);
            }

            writer.Write("</head>");
            return writer.ToString();
        }

        private void WriteFavicons(TextWriter writer)
        {
            if (_page.FaviconSet == PageFaviconSet.None)
            {
                return;
            }

            string basePath = string.IsNullOrWhiteSpace(_page.FaviconBasePath) ? "/favicons/" : _page.FaviconBasePath!;
            if (!basePath.EndsWith("/")) basePath += "/";
            string baseName = string.IsNullOrWhiteSpace(_page.FaviconBaseName) ? "favicon" : _page.FaviconBaseName!;

            writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}{baseName}.ico"))}"" type=""image/x-icon"">");

            switch (_page.FaviconSet)
            {
                case PageFaviconSet.Minimal:
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}{baseName}-32x32.png"))}"" type=""image/png"" sizes=""32x32"">");
                break;

                case PageFaviconSet.Default:
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}{baseName}-16x16.png"))}"" type=""image/png"" sizes=""16x16"">");
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}{baseName}-32x32.png"))}"" type=""image/png"" sizes=""32x32"">");
                    writer.Write($@"<link rel=""apple-touch-icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}apple-touch-icon-180x180.png"))}"" sizes=""180x180"">");
                break;

                case PageFaviconSet.Full:
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}{baseName}-16x16.png"))}"" type=""image/png"" sizes=""16x16"">");
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}{baseName}-32x32.png"))}"" type=""image/png"" sizes=""32x32"">");
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}{baseName}-48x48.png"))}"" type=""image/png"" sizes=""48x48"">");
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}{baseName}-96x96.png"))}"" type=""image/png"" sizes=""96x96"">");
                    writer.Write($@"<link rel=""apple-touch-icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}apple-touch-icon-180x180.png"))}"" sizes=""180x180"">");
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}android-chrome-192x192.png"))}"" type=""image/png"" sizes=""192x192"">");
                    writer.Write($@"<link rel=""icon"" href=""{HtmlEncoder.Default.Encode(AppendVersion($"{basePath}android-chrome-512x512.png"))}"" type=""image/png"" sizes=""512x512"">");
                break;
            }
        }

        #endregion
    }
}
