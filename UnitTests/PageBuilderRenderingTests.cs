#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.IO;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using DMBServerHelper;
using DMBServerWebHelper;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class PageBuilderRenderingTests
{
    [Test]
    public void InlineAssetCommentNamesAreEncodedWithoutEncodingInlineContent()
    {
        PageInformation page = new PageInformation()
            .AddScriptInline("startup --><script>alert(1)</script>", "window.ready = true;", PageScriptLocation.Head)
            .AddStyleSheetInline("theme --><style>body{display:none}</style>", "body { color: red; }");
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("<!-- Script inline startup - -&gt;&lt;script&gt;alert(1)&lt;/script&gt; -->"));
            Assert.That(html, Does.Contain("<!-- StyleSheet inline theme - -&gt;&lt;style&gt;body{display:none}&lt;/style&gt; -->"));
            Assert.That(html, Does.Contain("<script>window.ready = true;</script>"));
            Assert.That(html, Does.Contain("<style>body { color: red; }</style>"));
            Assert.That(html, Does.Not.Contain("<!-- Script inline startup --><script>"));
            Assert.That(html, Does.Not.Contain("<!-- StyleSheet inline theme --><style>"));
        });
    }

    [Test]
    public void InlineScriptContentCannotCloseScriptElementPrematurely()
    {
        PageInformation page = new PageInformation()
            .AddScriptInline(
                "startup",
                "window.payload = \"</script><img src=x onerror=alert(1)>\"; window.second = '</SCRIPT   >';",
                PageScriptLocation.Head);
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("window.payload = \"<\\/script><img src=x onerror=alert(1)>\";"));
            Assert.That(html, Does.Contain("window.second = '<\\/SCRIPT   >';"));
            Assert.That(CountOccurrences(html, "</script>"), Is.EqualTo(1));
            Assert.That(html, Does.Not.Contain("</script><img"));
        });
    }

    [Test]
    public void InlineStyleContentCannotCloseStyleElementPrematurely()
    {
        PageInformation page = new PageInformation()
            .AddStyleSheetInline(
                "theme",
                "body::before { content: \"</style><script>alert(1)</script>\"; } .x::after { content: '</STYLE   >'; }");
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("body::before { content: \"<\\/style><script>alert(1)</script>\"; }"));
            Assert.That(html, Does.Contain(".x::after { content: '<\\/STYLE   >'; }"));
            Assert.That(CountOccurrences(html, "</style>"), Is.EqualTo(1));
            Assert.That(html, Does.Not.Contain("</style><script>"));
        });
    }

    [Test]
    public void FaviconLinksAreRenderedFromSafeLocalPaths()
    {
        PageInformation page = new PageInformation()
            .SetFavicon(PageFaviconSet.Default, "/icons/", "app");
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain(@"<link rel=""icon"" href=""/icons/app.ico"));
            Assert.That(html, Does.Contain(@"<link rel=""icon"" href=""/icons/app-16x16.png"));
            Assert.That(html, Does.Contain(@"<link rel=""icon"" href=""/icons/app-32x32.png"));
            Assert.That(html, Does.Contain(@"<link rel=""apple-touch-icon"" href=""/icons/apple-touch-icon-180x180.png"));
            Assert.That(html, Does.Contain(@"sizes=""180x180"">"));
        });
    }

    [TestCase("javascript:alert(1)", "favicon")]
    [TestCase("/icons/\n", "favicon")]
    [TestCase("/icons/", "java\nscript:alert(1)")]
    public void FaviconLinksRejectUnsafeGeneratedUrls(string basePath, string baseName)
    {
        PageInformation page = new PageInformation()
            .SetFavicon(PageFaviconSet.Minimal, basePath, baseName);
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        Assert.That(() => RenderContent(builder.RenderDocumentStart(new DefaultHttpContext())), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void CookieConsentComposerContentIsRenderedThroughWriteTo()
    {
        CookieBool? previousCookieConsent = ServerWebHelperConfiguration.CookieConsent;
        try
        {
            ServerWebHelperConfiguration.CookieConsent = new CookieBool(
                $"PageBuilderConsent_{Guid.NewGuid():N}",
                "Consent",
                "Consent",
                CookieDefinitionGroup.Consent,
                false);
            PageInformation page = new PageInformation
            {
                CookieConsentComposer = new TestCookieConsentComposer()
            };
            PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
            DefaultHttpContext context = new DefaultHttpContext();

            _ = RenderContent(builder.RenderDocumentStart(context));
            string html = RenderContent(builder.RenderDocumentEnd(context));

            Assert.Multiple(() =>
            {
                Assert.That(html, Does.Contain("<aside data-cookie-consent=\"true\"></aside>"));
                Assert.That(html, Does.Not.Contain("TO_STRING_COOKIE_CONSENT"));
            });
        }
        finally
        {
            ServerWebHelperConfiguration.CookieConsent = previousCookieConsent;
        }
    }

    [Test]
    public void RenderDocumentStartIsIdempotentForSameBuilderInstance()
    {
        PageInformation page = new PageInformation()
            .SetTitle("Dashboard")
            .SetScriptFile("/js/end.js", PageScriptLocation.EndOfBody);
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        DefaultHttpContext context = new DefaultHttpContext();

        string firstRender = RenderContent(builder.RenderDocumentStart(context));
        string secondRender = RenderContent(builder.RenderDocumentStart(context));

        Assert.Multiple(() =>
        {
            Assert.That(secondRender, Is.EqualTo(firstRender));
            Assert.That(CountOccurrences(secondRender, "<body"), Is.EqualTo(1));
            Assert.That(CountOccurrences(secondRender, "<main"), Is.EqualTo(1));
        });
    }

    [Test]
    public void RenderDocumentEndIsIdempotentForSameBuilderInstance()
    {
        PageInformation page = new PageInformation()
            .SetScriptFile("/js/end.js", PageScriptLocation.EndOfBody)
            .AddScriptInline("end", "window.done = true;", PageScriptLocation.EndOfBody);
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        DefaultHttpContext context = new DefaultHttpContext();

        _ = RenderContent(builder.RenderDocumentStart(context));
        string firstRender = RenderContent(builder.RenderDocumentEnd(context));
        _ = RenderContent(builder.RenderDocumentStart(context));
        string secondRender = RenderContent(builder.RenderDocumentEnd(context));

        Assert.Multiple(() =>
        {
            Assert.That(secondRender, Is.EqualTo(firstRender));
            Assert.That(CountOccurrences(secondRender, "</main>"), Is.EqualTo(1));
            Assert.That(CountOccurrences(secondRender, "</body>"), Is.EqualTo(1));
            Assert.That(CountOccurrences(secondRender, "/js/end.js"), Is.EqualTo(1));
            Assert.That(CountOccurrences(secondRender, "window.done = true;"), Is.EqualTo(1));
        });
    }

    [Test]
    public void RenderDocumentStartSupportsBodyBuildersThatCloseStartWriterDuringEndRendering()
    {
        PageInformation page = new PageInformation
        {
            BodyBuilder = new StatefulBodyBuilder()
        };
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        DefaultHttpContext context = new DefaultHttpContext();

        string firstRender = RenderContent(builder.RenderDocumentStart(context));
        string secondRender = RenderContent(builder.RenderDocumentStart(context));

        Assert.Multiple(() =>
        {
            Assert.That(secondRender, Is.EqualTo(firstRender));
            Assert.That(secondRender, Does.Contain("<section class=\"stateful\"></section>"));
            Assert.That(CountOccurrences(secondRender, "<section class=\"stateful\">"), Is.EqualTo(1));
        });
    }

    [Test]
    public void RenderDocumentStartProducesWellFormedDocumentShell()
    {
        PageInformation page = new PageInformation().SetTitle("Shell");
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        DefaultHttpContext context = new DefaultHttpContext();

        string start = RenderContent(builder.RenderDocumentStart(context));
        string end = RenderContent(builder.RenderDocumentEnd(context));

        Assert.Multiple(() =>
        {
            Assert.That(start, Does.StartWith("<!doctype html>"));
            Assert.That(start, Does.Contain("<html lang=\""));
            Assert.That(start, Does.Contain("<head page-builder=\"true\">"));
            Assert.That(start, Does.Contain("</head>"));
            Assert.That(start, Does.Contain("<body>"));
            Assert.That(start, Does.Contain("<header>"));
            Assert.That(start, Does.Contain("</header>"));
            Assert.That(start, Does.Contain("<main>"));
            Assert.That(end, Does.Contain("</main>"));
            Assert.That(end, Does.Contain("<footer>"));
            Assert.That(end, Does.Contain("</footer>"));
            Assert.That(end, Does.Contain("</body>"));
            Assert.That(end, Does.EndWith("</html>"));
        });
    }

    [Test]
    public void RenderDocumentStartRespectsBodyBuilderAttributesOrder()
    {
        BasicBodyBuilder bodyBuilder = new BasicBodyBuilder();
        bodyBuilder.BodyClasses.Add("dark-theme");
        bodyBuilder.BodyAttributes["data-controller"] = "app";
        bodyBuilder.MainClasses.Add("container");
        bodyBuilder.MainAttributes["data-page"] = "home";

        PageInformation page = new PageInformation { BodyBuilder = bodyBuilder };
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("<body class=\"dark-theme\" data-controller=\"app\">"));
            Assert.That(html, Does.Contain("<main class=\"container\" data-page=\"home\">"));
        });
    }

    [Test]
    public void ViewportMetaIsAutoInjectedWhenAbsent()
    {
        PageInformation page = new PageInformation();
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.That(html, Does.Contain("name=\"viewport\""));
    }

    [Test]
    public void ViewportMetaIsNotDuplicatedWhenAlreadyPresent()
    {
        PageInformation page = new PageInformation().SetViewport("width=device-width");
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.That(CountOccurrences(html, "name=\"viewport\""), Is.EqualTo(1));
    }

    [Test]
    public void KeywordsAreRenderedAsMetaTagInHead()
    {
        PageInformation page = new PageInformation().SetKeywords("framework", "dotnet", "mvc");
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.That(html, Does.Contain("name=\"keywords\" content=\"framework, dotnet, mvc\""));
    }

    [Test]
    public void KeywordsTagIsNotRenderedWhenKeywordsListIsEmpty()
    {
        PageInformation page = new PageInformation();
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.That(html, Does.Not.Contain("name=\"keywords\""));
    }

    [Test]
    public void HeadScriptAppearsInHeadAndNotInEndOfBody()
    {
        PageInformation page = new PageInformation()
            .SetScriptFile("/head.js", PageScriptLocation.Head)
            .SetScriptFile("/body.js", PageScriptLocation.EndOfBody);
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        DefaultHttpContext context = new DefaultHttpContext();

        string start = RenderContent(builder.RenderDocumentStart(context));
        string end = RenderContent(builder.RenderDocumentEnd(context));

        Assert.Multiple(() =>
        {
            Assert.That(start, Does.Contain("/head.js"));
            Assert.That(start, Does.Not.Contain("/body.js"));
            Assert.That(end, Does.Contain("/body.js"));
            Assert.That(end, Does.Not.Contain("/head.js"));
        });
    }

    [Test]
    public void InlineScriptInHeadAppearsInHeadAndNotInEndOfBody()
    {
        PageInformation page = new PageInformation()
            .AddScriptInline("head-init", "window.head = true;", PageScriptLocation.Head)
            .AddScriptInline("body-init", "window.body = true;", PageScriptLocation.EndOfBody);
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        DefaultHttpContext context = new DefaultHttpContext();

        string start = RenderContent(builder.RenderDocumentStart(context));
        string end = RenderContent(builder.RenderDocumentEnd(context));

        Assert.Multiple(() =>
        {
            Assert.That(start, Does.Contain("window.head = true;"));
            Assert.That(start, Does.Not.Contain("window.body = true;"));
            Assert.That(end, Does.Contain("window.body = true;"));
            Assert.That(end, Does.Not.Contain("window.head = true;"));
        });
    }

    [Test]
    public void ScriptsAreRenderedInOrderAscending()
    {
        PageInformation page = new PageInformation()
            .SetScriptFile("/third.js", PageScriptLocation.Head, order: 30)
            .SetScriptFile("/first.js", PageScriptLocation.Head, order: 10)
            .SetScriptFile("/second.js", PageScriptLocation.Head, order: 20);
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        int firstIndex = html.IndexOf("/first.js", StringComparison.Ordinal);
        int secondIndex = html.IndexOf("/second.js", StringComparison.Ordinal);
        int thirdIndex = html.IndexOf("/third.js", StringComparison.Ordinal);

        Assert.That(firstIndex, Is.LessThan(secondIndex));
        Assert.That(secondIndex, Is.LessThan(thirdIndex));
    }

    [Test]
    public void StylesheetLinkIsRenderedInHead()
    {
        PageInformation page = new PageInformation()
            .SetStylesheet("/site.css");
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("rel=\"stylesheet\""));
            Assert.That(html, Does.Contain("href=\"/site.css"));
        });
    }

    [Test]
    public void CultureNameIsRenderedInHtmlLangAttribute()
    {
        PageInformation page = new PageInformation()
            .SetCulture(new System.Globalization.CultureInfo("fr-FR"));
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.That(html, Does.Contain("<html lang=\"fr-FR\">"));
    }

    [Test]
    public void RenderDocumentEndAlwaysClosesHtmlTag()
    {
        PageInformation page = new PageInformation();
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        DefaultHttpContext context = new DefaultHttpContext();

        _ = RenderContent(builder.RenderDocumentStart(context));
        string end = RenderContent(builder.RenderDocumentEnd(context));

        Assert.That(end, Does.EndWith("</html>"));
    }

    [Test]
    public void BodyClassDeduplicationPreservesUniqueClasses()
    {
        BasicBodyBuilder bodyBuilder = new BasicBodyBuilder();
        bodyBuilder.BodyClasses.Add("layout");
        bodyBuilder.BodyClasses.Add("layout");
        bodyBuilder.BodyClasses.Add("dark");
        bodyBuilder.BodyClasses.Add("dark");

        PageInformation page = new PageInformation { BodyBuilder = bodyBuilder };
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);

        string html = RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));

        Assert.That(CountOccurrences(html, "layout"), Is.EqualTo(1));
        Assert.That(CountOccurrences(html, "dark"), Is.EqualTo(1));
    }

    private static string RenderContent(IHtmlContent content)
    {
        using StringWriter writer = new();
        content.WriteTo(writer, HtmlEncoder.Default);
        return writer.ToString();
    }

    private static int CountOccurrences(string value, string pattern)
    {
        int count = 0;
        int index = 0;
        while ((index = value.IndexOf(pattern, index, StringComparison.Ordinal)) >= 0)
        {
            count++;
            index += pattern.Length;
        }

        return count;
    }

    private sealed class TestCookieConsentComposer : ICookieConsentComposer
    {
        public IHtmlContent RenderCookieConsent(IHtmlHelper htmlHelper, PageInformation page, CookieDefinition cookieConsent, HttpContext context)
        {
            return new TestCookieConsentHtmlContent();
        }
    }

    private sealed class TestCookieConsentHtmlContent : IHtmlContent
    {
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("<aside data-cookie-consent=\"true\"></aside>");
        }

        public override string ToString()
        {
            return "TO_STRING_COOKIE_CONSENT";
        }
    }

    private sealed class StatefulBodyBuilder : IBodyBuilder
    {
        private TextWriter? _startWriter;

        public void RenderBodyEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write("</body>");
        }

        public void RenderBodyStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write("<body>");
        }

        public void RenderFooterEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write("</footer>");
        }

        public void RenderFooterStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write("<footer>");
        }

        public void RenderHeaderEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write("</header>");
        }

        public void RenderHeaderStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write("<header>");
        }

        public void RenderMainEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            _startWriter?.Write("</section>");
            writer.Write("</main>");
        }

        public void RenderMainStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write("<main>");
            writer.Write("<section class=\"stateful\">");
            _startWriter = writer;
        }
    }
}
