#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using DMBPageBuilder;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class BasicBodyBuilderTests
{
    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.CommonAttributeNames))]
    public void RenderBodyAttributesAcceptsCommonHtmlAttributeNames(string attributeName, string expectedAttribute)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.BodyAttributes[attributeName] = "safe-value";

        Assert.That(builder.RenderBodyAttributes(), Does.Contain(expectedAttribute));
    }

    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.CommonAttributeNames))]
    public void RenderMainAttributesAcceptsCommonHtmlAttributeNames(string attributeName, string expectedAttribute)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.MainAttributes[attributeName] = "safe-value";

        Assert.That(builder.RenderMainAttributes(), Does.Contain(expectedAttribute));
    }

    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.InvalidAttributeNames))]
    public void RenderBodyAttributesRejectsNamesThatCanBreakHtmlAttributeGrammar(string maliciousAttributeName)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.BodyAttributes[maliciousAttributeName] = "safe-value";

        Assert.That(() => builder.RenderBodyAttributes(), Throws.TypeOf<ArgumentException>());
    }

    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.InvalidAttributeNames))]
    public void RenderMainAttributesRejectsNamesThatCanBreakHtmlAttributeGrammar(string maliciousAttributeName)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.MainAttributes[maliciousAttributeName] = "safe-value";

        Assert.That(() => builder.RenderMainAttributes(), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("class")]
    [TestCase("style")]
    public void RenderBodyAttributesRejectsReservedRawAttributes(string attributeName)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.BodyAttributes[attributeName] = "safe-value";

        Assert.That(() => builder.RenderBodyAttributes(), Throws.TypeOf<InvalidOperationException>());
    }

    [TestCase("class")]
    [TestCase("style")]
    public void RenderMainAttributesRejectsReservedRawAttributes(string attributeName)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.MainAttributes[attributeName] = "safe-value";

        Assert.That(() => builder.RenderMainAttributes(), Throws.TypeOf<InvalidOperationException>());
    }

    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.AttributeValueInjectionAttempts))]
    public void RenderBodyAttributesEncodesPotentiallyDangerousValues(string payload, string forbiddenRawMarkup)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.BodyAttributes["title"] = payload;

        string attributes = builder.RenderBodyAttributes();

        Assert.Multiple(() =>
        {
            Assert.That(attributes, Does.Contain("title=\""));
            Assert.That(attributes, Does.Not.Contain(forbiddenRawMarkup));
        });
    }

    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.AttributeValueInjectionAttempts))]
    public void RenderMainAttributesEncodesPotentiallyDangerousValues(string payload, string forbiddenRawMarkup)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.MainAttributes["title"] = payload;

        string attributes = builder.RenderMainAttributes();

        Assert.Multiple(() =>
        {
            Assert.That(attributes, Does.Contain("title=\""));
            Assert.That(attributes, Does.Not.Contain(forbiddenRawMarkup));
        });
    }

    [Test]
    public void RenderBodyAttributesEncodesClasses()
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.BodyClasses.Add("layout");
        builder.BodyClasses.Add("\" onclick=\"alert(1)<script>alert(2)</script>");

        string attributes = builder.RenderBodyAttributes();

        Assert.Multiple(() =>
        {
            Assert.That(attributes, Does.Contain("class=\"layout &quot; onclick=&quot;alert(1)&lt;script&gt;alert(2)&lt;/script&gt;\""));
            Assert.That(attributes, Does.Not.Contain("<script>"));
        });
    }

    [Test]
    public void RenderMainAttributesEncodesClasses()
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.MainClasses.Add("content");
        builder.MainClasses.Add("\" onmouseover=\"alert(1)<style>body{display:none}</style>");

        string attributes = builder.RenderMainAttributes();

        Assert.Multiple(() =>
        {
            Assert.That(attributes, Does.Contain("class=\"content &quot; onmouseover=&quot;alert(1)&lt;style&gt;body{display:none}&lt;/style&gt;\""));
            Assert.That(attributes, Does.Not.Contain("<style>"));
        });
    }

    [TestCase("href")]
    [TestCase("src")]
    [TestCase("action")]
    public void RenderBodyAttributesRejectsDangerousUrlAttributeValues(string attributeName)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.BodyAttributes[attributeName] = "javascript:alert(1)";

        Assert.That(() => builder.RenderBodyAttributes(), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("href")]
    [TestCase("src")]
    [TestCase("action")]
    public void RenderMainAttributesRejectsDangerousUrlAttributeValues(string attributeName)
    {
        BasicBodyBuilder builder = new BasicBodyBuilder();
        builder.MainAttributes[attributeName] = "javascript:alert(1)";

        Assert.That(() => builder.RenderMainAttributes(), Throws.TypeOf<ArgumentException>());
    }
}
