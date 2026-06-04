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

        WebAssetRegistryEntry[] snapshot = registry.Snapshot().ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(snapshot, Has.Length.EqualTo(2));
            Assert.That(snapshot[0].Key, Is.EqualTo("styles"));
            Assert.That(snapshot[0].IsStylesheet, Is.True);
            Assert.That(snapshot[0].StylesheetUrl, Is.EqualTo("/site.css"));
            Assert.That(snapshot[0].CrossOrigin, Is.EqualTo(PageCrossOrigin.UseCredentials));
            Assert.That(snapshot[1].Key, Is.EqualTo("scripts"));
            Assert.That(snapshot[1].IsScript, Is.True);
            Assert.That(snapshot[1].ScriptUrl, Is.EqualTo("/app.js"));
            Assert.That(snapshot[1].ScriptLocation, Is.EqualTo(PageScriptLocation.EndOfBody));
            Assert.That(snapshot[1].ScriptLoadingMode, Is.EqualTo(PageScriptLoadingMode.Async));
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
            Assert.That(() => registry.RegisterStylesheet("", "/site.css"), Throws.TypeOf<ArgumentException>());
            Assert.That(() => registry.RegisterStylesheet("site", ""), Throws.TypeOf<ArgumentException>());
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