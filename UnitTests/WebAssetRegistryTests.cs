#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class WebAssetRegistryTests
{
    [Test]
    public void RegisteringAssetsReturnsOrderedSnapshot()
    {
        WebAssetRegistry registry = new WebAssetRegistry();

        registry.RegisterScript(
            "scripts",
            "/app.js",
            PageScriptLocation.EndOfBody,
            PageScriptLoadingMode.Async,
            order: 20,
            PageCrossOrigin.Anonymous,
            "sha256-script");
        registry.RegisterStylesheet(
            "styles",
            "/site.css",
            order: 10,
            PageCrossOrigin.UseCredentials,
            "sha256-style");
        registry.RegisterLink(
            "manifest",
            new PageLinkDefinition
            {
                Href = "/manifest.webmanifest",
                Rel = PageLinkRel.Manifest,
                Type = "application/manifest+json",
                Order = 15
            });

        WebAssetRegistryEntry[] snapshot = registry.Snapshot().ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(snapshot, Has.Length.EqualTo(3));
            Assert.That(snapshot[0].Key, Is.EqualTo("styles"));
            Assert.That(snapshot[0].IsStylesheet, Is.True);
            Assert.That(snapshot[0].StylesheetUrl, Is.EqualTo("/site.css"));
            Assert.That(snapshot[0].CrossOrigin, Is.EqualTo(PageCrossOrigin.UseCredentials));
            Assert.That(snapshot[1].Key, Is.EqualTo("manifest"));
            Assert.That(snapshot[1].IsLink, Is.True);
            Assert.That(snapshot[1].Link?.Href, Is.EqualTo("/manifest.webmanifest"));
            Assert.That(snapshot[1].Link?.Rel, Is.EqualTo(PageLinkRel.Manifest));
            Assert.That(snapshot[1].Link?.Type, Is.EqualTo("application/manifest+json"));
            Assert.That(snapshot[2].Key, Is.EqualTo("scripts"));
            Assert.That(snapshot[2].IsScript, Is.True);
            Assert.That(snapshot[2].ScriptUrl, Is.EqualTo("/app.js"));
            Assert.That(snapshot[2].ScriptLocation, Is.EqualTo(PageScriptLocation.EndOfBody));
            Assert.That(snapshot[2].ScriptLoadingMode, Is.EqualTo(PageScriptLoadingMode.Async));
        });
    }

    [Test]
    public void RegisteringInvalidAssetsThrowsArgumentException()
    {
        WebAssetRegistry registry = new WebAssetRegistry();

        Assert.Multiple(() =>
        {
            Assert.That(() => registry.RegisterScript("", "/app.js"), Throws.TypeOf<ArgumentException>());
            Assert.That(() => registry.RegisterScript("app", ""), Throws.TypeOf<ArgumentException>());
            Assert.That(() => registry.RegisterLink("", new PageLinkDefinition { Href = "/manifest.webmanifest", Rel = PageLinkRel.Manifest }), Throws.TypeOf<ArgumentException>());
            Assert.That(() => registry.RegisterLink("manifest", null!), Throws.TypeOf<ArgumentNullException>());
            Assert.That(() => registry.RegisterLink("manifest", new PageLinkDefinition { Href = "", Rel = PageLinkRel.Manifest }), Throws.TypeOf<ArgumentException>());
            Assert.That(() => registry.RegisterStylesheet("", "/site.css"), Throws.TypeOf<ArgumentException>());
            Assert.That(() => registry.RegisterStylesheet("site", ""), Throws.TypeOf<ArgumentException>());
        });
    }

    [Test]
    public void RegisteringLinkCopiesDefinition()
    {
        WebAssetRegistry registry = new WebAssetRegistry();
        PageLinkDefinition link = new PageLinkDefinition
        {
            As = "fetch",
            CrossOrigin = PageCrossOrigin.Anonymous,
            Href = "/manifest.webmanifest",
            Integrity = "sha256-manifest",
            Order = 15,
            Rel = PageLinkRel.Manifest,
            Sizes = "any",
            Type = "application/manifest+json"
        };

        registry.RegisterLink("manifest", link);
        link.Href = "/changed.webmanifest";
        link.Type = "application/json";

        WebAssetRegistryEntry entry = registry.Snapshot().Single();

        Assert.Multiple(() =>
        {
            Assert.That(entry.IsLink, Is.True);
            Assert.That(entry.Order, Is.EqualTo(15));
            Assert.That(entry.Link?.As, Is.EqualTo("fetch"));
            Assert.That(entry.Link?.CrossOrigin, Is.EqualTo(PageCrossOrigin.Anonymous));
            Assert.That(entry.Link?.Href, Is.EqualTo("/manifest.webmanifest"));
            Assert.That(entry.Link?.Integrity, Is.EqualTo("sha256-manifest"));
            Assert.That(entry.Link?.Order, Is.EqualTo(15));
            Assert.That(entry.Link?.Rel, Is.EqualTo(PageLinkRel.Manifest));
            Assert.That(entry.Link?.Sizes, Is.EqualTo("any"));
            Assert.That(entry.Link?.Type, Is.EqualTo("application/manifest+json"));
        });
    }

    [Test]
    public void RegisterGlobalLinkAssetAddsRegistryServices()
    {
        ServiceCollection services = new ServiceCollection();

        services.RegisterGlobalLinkAsset(
            "manifest",
            new PageLinkDefinition
            {
                Href = "/manifest.webmanifest",
                Rel = PageLinkRel.Manifest,
                Type = "application/manifest+json",
                Order = 15
            });

        using ServiceProvider provider = services.BuildServiceProvider();
        IWebAssetRegistry assetRegistry = provider.GetRequiredService<IWebAssetRegistry>();
        IWebLinkAssetRegistry linkAssetRegistry = provider.GetRequiredService<IWebLinkAssetRegistry>();
        WebAssetRegistryEntry entry = assetRegistry.Snapshot().Single();

        Assert.Multiple(() =>
        {
            Assert.That(linkAssetRegistry, Is.SameAs(assetRegistry));
            Assert.That(entry.IsLink, Is.True);
            Assert.That(entry.Link?.Href, Is.EqualTo("/manifest.webmanifest"));
            Assert.That(entry.Link?.Rel, Is.EqualTo(PageLinkRel.Manifest));
        });
    }

    [Test]
    public void RegisteringSameKeyReplacesEntryCaseInsensitively()
    {
        WebAssetRegistry registry = new WebAssetRegistry();

        registry.RegisterStylesheet("site", "/old.css");
        registry.RegisterStylesheet("SITE", "/new.css");

        WebAssetRegistryEntry entry = registry.Snapshot().Single();

        Assert.Multiple(() =>
        {
            Assert.That(entry.Key, Is.EqualTo("SITE"));
            Assert.That(entry.StylesheetUrl, Is.EqualTo("/new.css"));
        });
    }
}
