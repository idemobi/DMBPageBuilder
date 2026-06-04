#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Linq;
using DMBPageBuilder;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class PageInformationTests
{
    [Test]
    public void AddNullDefinitionsThrowArgumentNullException()
    {
        PageInformation page = new PageInformation();

        Assert.Multiple(() =>
        {
            Assert.That(() => page.AddLink(null!), Throws.TypeOf<ArgumentNullException>());
            Assert.That(() => page.AddMeta(null!), Throws.TypeOf<ArgumentNullException>());
            Assert.That(() => page.AddScript(null!), Throws.TypeOf<ArgumentNullException>());
        });
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("javascript:alert(1)")]
    [TestCase("java\nscript:alert(1)")]
    public void AddLinkRejectsEmptyOrUnsafeHref(string href)
    {
        PageInformation page = new PageInformation();
        PageLinkDefinition link = new PageLinkDefinition
        {
            Rel = PageLinkRel.Stylesheet,
            Href = href
        };

        Assert.That(() => page.AddLink(link), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("javascript:alert(1)")]
    [TestCase("java\nscript:alert(1)")]
    public void AddScriptRejectsEmptyOrUnsafeUrl(string url)
    {
        PageInformation page = new PageInformation();
        PageScriptDefinition script = new PageScriptDefinition
        {
            Url = url
        };

        Assert.That(() => page.AddScript(script), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("javascript:alert(1)")]
    public void SetStylesheetRejectsEmptyOrUnsafeHref(string href)
    {
        PageInformation page = new PageInformation();

        Assert.That(() => page.SetStylesheet(href), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("javascript:alert(1)")]
    public void SetScriptFileRejectsEmptyOrUnsafeUrl(string url)
    {
        PageInformation page = new PageInformation();

        Assert.That(() => page.SetScriptFile(url), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void ScriptsLinksAndInlineBlocksAreDeduplicatedByKey()
    {
        PageInformation page = new PageInformation()
            .SetStylesheet("/site.css", order: 2)
            .SetStylesheet("/site.css", order: 5)
            .SetScriptFile("/site.js", PageScriptLocation.Head, PageScriptLoadingMode.Async, order: 1)
            .SetScriptFile("/site.js", PageScriptLocation.EndOfBody, PageScriptLoadingMode.Defer, order: 3)
            .AddScriptInline("startup", "one();")
            .AddScriptInline("startup", "two();", PageScriptLocation.Head)
            .AddStyleSheetInline("theme", "body { color: red; }")
            .AddStyleSheetInline("theme", "body { color: blue; }");

        Assert.Multiple(() =>
        {
            Assert.That(page.Links, Has.Count.EqualTo(1));
            Assert.That(page.Links["/site.css"].Order, Is.EqualTo(5));
            Assert.That(page.Scripts, Has.Count.EqualTo(1));
            Assert.That(page.Scripts["/site.js"].Location, Is.EqualTo(PageScriptLocation.EndOfBody));
            Assert.That(page.Scripts["/site.js"].Order, Is.EqualTo(3));
            Assert.That(page.ScriptsInline, Has.Count.EqualTo(1));
            Assert.That(page.ScriptsInline["startup"].Script, Is.EqualTo("two();"));
            Assert.That(page.ScriptsInline["startup"].Location, Is.EqualTo(PageScriptLocation.Head));
            Assert.That(page.StylesheetsInline, Has.Count.EqualTo(1));
            Assert.That(page.StylesheetsInline["theme"].Content, Is.EqualTo("body { color: blue; }"));
        });
    }

    [Test]
    public void SettersPopulatePageMetadataCollections()
    {
        PageInformation page = new PageInformation()
            .SetTitle("Dashboard")
            .SetCharset(PageCharset.Utf8)
            .SetViewport()
            .SetDescription("Operational dashboard", order: 4)
            .SetKeywords(9, "alpha", "", "beta")
            .SetFavicon(PageFaviconSet.Default, "/icons/", "app");

        Assert.Multiple(() =>
        {
            Assert.That(page.Title, Is.EqualTo("Dashboard"));
            Assert.That(page.Metas, Has.Count.EqualTo(3));
            Assert.That(page.Metas.Any(meta => meta.Kind == PageMetaKind.Charset && meta._Charset == "utf-8" && meta.Order == -100), Is.True);
            Assert.That(page.Metas.Any(meta => meta.Name == "viewport" && meta.Order == -90), Is.True);
            Assert.That(page.Metas.Any(meta => meta.Name == "description" && meta.Content == "Operational dashboard" && meta.Order == 4), Is.True);
            Assert.That(page.Keywords, Is.EqualTo(new[] { "alpha", "beta" }));
            Assert.That(page.KeywordsOrder, Is.EqualTo(9));
            Assert.That(page.FaviconSet, Is.EqualTo(PageFaviconSet.Default));
            Assert.That(page.FaviconBasePath, Is.EqualTo("/icons/"));
            Assert.That(page.FaviconBaseName, Is.EqualTo("app"));
        });
    }
}
