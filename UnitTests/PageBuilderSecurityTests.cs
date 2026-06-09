#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

/// <summary>
///     Verifies that PageBuilder HTML-encodes every field it writes into the document,
///     preventing XSS injection through page-level metadata, asset URLs, and other
///     user-controlled inputs surfaced in the rendered output.
/// </summary>
[TestFixture]
public sealed class PageBuilderSecurityTests
{
    // ── Helpers ─────────────────────────────────────────────────────────────

    private static string RenderStart(PageInformation page)
    {
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        return RenderContent(builder.RenderDocumentStart(new DefaultHttpContext()));
    }

    private static string RenderEnd(PageInformation page)
    {
        PageBuilder builder = new PageBuilder(TestHtmlHelperFactory.Create(), page);
        DefaultHttpContext context = new DefaultHttpContext();
        _ = RenderContent(builder.RenderDocumentStart(context));
        return RenderContent(builder.RenderDocumentEnd(context));
    }

    private static string RenderContent(IHtmlContent content)
    {
        using StringWriter writer = new();
        content.WriteTo(writer, HtmlEncoder.Default);
        return writer.ToString();
    }

    [Test]
    public void EmptyAndWhitespaceKeywordsAreFilteredOut()
    {
        PageInformation page = new PageInformation()
            .SetKeywords("valid", "", "   ", "also-valid");

        string html = RenderStart(page);

        Assert.That(html, Does.Contain("content=\"valid, also-valid\""));
    }

    // ── Inline content is NOT encoded (trusted by design) ─────────────────

    [Test]
    public void InlineScriptContentIsWrittenRawAndNotDoubleEncoded()
    {
        const string trustedScript = "window.config = { url: '/api', flag: true };";
        PageInformation page = new PageInformation()
            .AddScriptInline("config", trustedScript, PageScriptLocation.Head);

        string html = RenderStart(page);

        Assert.That(html, Does.Contain($"<script>{trustedScript}</script>"));
    }

    [Test]
    public void InlineStyleContentIsWrittenRawAndNotDoubleEncoded()
    {
        const string trustedCss = "body { color: #333; background: url('/img/bg.png'); }";
        PageInformation page = new PageInformation()
            .AddStyleSheetInline("theme", trustedCss);

        string html = RenderStart(page);

        Assert.That(html, Does.Contain($"<style>{trustedCss}</style>"));
    }

    // ── Keywords encoding ─────────────────────────────────────────────────

    [Test]
    public void KeywordsXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .SetKeywords("normal", "<script>alert(1)</script>", "\"injected\"");

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("normal"));
            Assert.That(html, Does.Not.Contain("<script>alert(1)</script>"));
            Assert.That(html, Does.Not.Contain("\"injected\""));
        });
    }

    // ── Link/stylesheet href encoding ─────────────────────────────────────

    [Test]
    public void LinkHrefXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .SetStylesheet("\"><script>alert(1)</script>");

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("href=\"&quot;&gt;&lt;script&gt;alert(1)&lt;/script&gt;\""));
            Assert.That(html, Does.Not.Contain("href=\"\"><script>"));
        });
    }

    [Test]
    public void LinkIntegrityXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .SetStylesheet("/site.css", integrity: "\" onload=\"alert(1)");

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("integrity=\"&quot; onload=&quot;alert(1)\""));
            Assert.That(html, Does.Not.Contain("integrity=\"\" onload="));
        });
    }

    [Test]
    public void LinkSizesXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .AddLink(new PageLinkDefinition
            {
                Rel = PageLinkRel.AppleTouchIcon,
                Href = "/icon.png",
                Sizes = "180x180\"><script>alert(1)</script>"
            });

        string html = RenderStart(page);

        Assert.That(html, Does.Not.Contain("<script>alert(1)</script>"));
    }

    [Test]
    public void LinkTypeXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .AddLink(new PageLinkDefinition
            {
                Rel = PageLinkRel.Stylesheet,
                Href = "/site.css",
                Type = "text/css\"><script>alert(1)</script>"
            });

        string html = RenderStart(page);

        Assert.That(html, Does.Not.Contain("<script>alert(1)</script>"));
    }

    [Test]
    public void MetaContentXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .AddMeta(PageMetaDefinition.NameMeta("description", "\"><script>alert(1)</script>"));

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("content=\"&quot;&gt;&lt;script&gt;alert(1)&lt;/script&gt;\""));
            Assert.That(html, Does.Not.Contain("content=\"\"><script>"));
        });
    }

    [Test]
    public void MetaHttpEquivXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .AddMeta(PageMetaDefinition.HttpEquivMeta("refresh\"><script>alert(1)</script>", "0"));

        string html = RenderStart(page);

        Assert.That(html, Does.Not.Contain("<script>alert(1)</script>"));
    }

    // ── Meta encoding ─────────────────────────────────────────────────────

    [Test]
    public void MetaNameXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .AddMeta(PageMetaDefinition.NameMeta("<img src=x onerror=alert(1)>", "safe-content"));

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("name=\"&lt;img src=x onerror=alert(1)&gt;\""));
            Assert.That(html, Does.Not.Contain("name=\"<img"));
        });
    }

    [Test]
    public void MetaPropertyXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .AddMeta(PageMetaDefinition.PropertyMeta("og:title\"><script>alert(1)</script>", "value"));

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("property=\"og:title&quot;&gt;&lt;script&gt;alert(1)&lt;/script&gt;\""));
            Assert.That(html, Does.Not.Contain("<script>alert(1)</script>"));
        });
    }

    [Test]
    public void NullTitleOmitsTitleTag()
    {
        PageInformation page = new PageInformation();

        string html = RenderStart(page);

        Assert.That(html, Does.Not.Contain("<title>"));
    }

    // ── Constructor guards ────────────────────────────────────────────────

    [Test]
    public void PageBuilderThrowsArgumentNullExceptionWhenHtmlHelperIsNull()
    {
        Assert.That(() => new PageBuilder(null!, new PageInformation()), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void PageBuilderThrowsArgumentNullExceptionWhenPageInformationIsNull()
    {
        Assert.That(() => new PageBuilder(TestHtmlHelperFactory.Create(), null!), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void ScriptEndOfBodySrcXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .SetScriptFile("\"><script>alert(1)</script>", PageScriptLocation.EndOfBody);

        string html = RenderEnd(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("src=\"&quot;&gt;&lt;script&gt;alert(1)&lt;/script&gt;\""));
            Assert.That(html, Does.Not.Contain("src=\"\"><script>"));
        });
    }

    // ── Comment name injection ────────────────────────────────────────────

    [Test]
    public void ScriptInlineCommentClosingSequenceIsNeutralized()
    {
        PageInformation page = new PageInformation()
            .AddScriptInline("name --> </script><script>alert(1)", "window.ok = true;", PageScriptLocation.Head);

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Not.Contain("<!-- name --> </script><script>alert(1) -->"));
            Assert.That(html, Does.Contain("<script>window.ok = true;</script>"));
        });
    }

    [Test]
    public void ScriptIntegrityXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .SetScriptFile(
                "/app.js",
                PageScriptLocation.Head,
                integrity: "\"><script>alert(1)</script>"
            );

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("integrity=\"&quot;&gt;&lt;script&gt;alert(1)&lt;/script&gt;\""));
            Assert.That(html, Does.Not.Contain("integrity=\"\"><script>"));
        });
    }

    // ── Script src encoding ───────────────────────────────────────────────

    [Test]
    public void ScriptSrcXssPayloadIsEncoded()
    {
        PageInformation page = new PageInformation()
            .SetScriptFile("\"><script>alert(1)</script>", PageScriptLocation.Head);

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("src=\"&quot;&gt;&lt;script&gt;alert(1)&lt;/script&gt;\""));
            Assert.That(html, Does.Not.Contain("src=\"\"><script>"));
        });
    }

    [Test]
    public void StyleSheetInlineCommentClosingSequenceIsNeutralized()
    {
        PageInformation page = new PageInformation()
            .AddStyleSheetInline("theme --> </style><script>alert(1)", "body { margin: 0; }");

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Not.Contain("<!-- theme --> </style><script>alert(1) -->"));
            Assert.That(html, Does.Contain("<style>body { margin: 0; }</style>"));
        });
    }

    [Test]
    public void TitleWithAmpersandIsHtmlEncoded()
    {
        PageInformation page = new PageInformation()
            .SetTitle("Sales & Marketing <2025>");

        string html = RenderStart(page);

        Assert.That(html, Does.Contain("<title>Sales &amp; Marketing &lt;2025&gt;</title>"));
    }

    [Test]
    public void TitleWithQuoteBreakoutIsEncoded()
    {
        PageInformation page = new PageInformation()
            .SetTitle("\" onload=\"alert(1)\" x=\"");

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("<title>&quot; onload=&quot;alert(1)&quot; x=&quot;</title>"));
            Assert.That(html, Does.Not.Contain("<title>\" onload="));
        });
    }

    // ── Title encoding ────────────────────────────────────────────────────

    [Test]
    public void TitleXssPayloadIsHtmlEncoded()
    {
        PageInformation page = new PageInformation()
            .SetTitle("<script>alert(1)</script>");

        string html = RenderStart(page);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.Contain("<title>&lt;script&gt;alert(1)&lt;/script&gt;</title>"));
            Assert.That(html, Does.Not.Contain("<title><script>"));
        });
    }
}