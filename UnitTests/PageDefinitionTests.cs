#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class PageDefinitionTests
{
    [Test]
    public void LinkDefinitionFluentMethodsMutateAndReturnSameInstance()
    {
        PageLinkDefinition link = new PageLinkDefinition { Href = "/site.css", Rel = PageLinkRel.Stylesheet };

        PageLinkDefinition returned = link
            .SetCrossOrigin(PageCrossOrigin.Anonymous)
            .SetIntegrity("sha256-test")
            .SetOrder(12);

        Assert.Multiple(() =>
        {
            Assert.That(returned, Is.SameAs(link));
            Assert.That(link.CrossOrigin, Is.EqualTo(PageCrossOrigin.Anonymous));
            Assert.That(link.Integrity, Is.EqualTo("sha256-test"));
            Assert.That(link.Order, Is.EqualTo(12));
        });
    }

    [Test]
    public void MetaFactoriesCreateExpectedDefinitions()
    {
        PageMetaDefinition charset = PageMetaDefinition.Charset(PageCharset.Utf8);
        PageMetaDefinition named = PageMetaDefinition.NameMeta(PageMetaName.Description, "Page description").SetOrder(5);
        PageMetaDefinition property = PageMetaDefinition.PropertyMeta("og:title", "Title");
        PageMetaDefinition httpEquiv = PageMetaDefinition.HttpEquivMeta("refresh", "30");

        Assert.Multiple(() =>
        {
            Assert.That(charset.Kind, Is.EqualTo(PageMetaKind.Charset));
            Assert.That(charset._Charset, Is.EqualTo("utf-8"));
            Assert.That(named.Kind, Is.EqualTo(PageMetaKind.Name));
            Assert.That(named.Name, Is.EqualTo("description"));
            Assert.That(named.Content, Is.EqualTo("Page description"));
            Assert.That(named.Order, Is.EqualTo(5));
            Assert.That(property.Kind, Is.EqualTo(PageMetaKind.Property));
            Assert.That(property.Name, Is.EqualTo("og:title"));
            Assert.That(httpEquiv.Kind, Is.EqualTo(PageMetaKind.HttpEquiv));
            Assert.That(httpEquiv.Name, Is.EqualTo("refresh"));
        });
    }

    [Test]
    public void ScriptDefinitionFluentMethodsMutateAndReturnSameInstance()
    {
        PageScriptDefinition script = new PageScriptDefinition { Url = "/site.js" };

        PageScriptDefinition returned = script
            .SetCrossOrigin(PageCrossOrigin.UseCredentials)
            .SetIntegrity("sha384-test")
            .SetOrder(3);

        Assert.Multiple(() =>
        {
            Assert.That(returned, Is.SameAs(script));
            Assert.That(script.CrossOrigin, Is.EqualTo(PageCrossOrigin.UseCredentials));
            Assert.That(script.Integrity, Is.EqualTo("sha384-test"));
            Assert.That(script.Order, Is.EqualTo(3));
        });
    }
}