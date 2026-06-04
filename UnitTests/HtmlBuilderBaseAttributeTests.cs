#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.IO;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class HtmlBuilderBaseAttributeTests
{
    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.CommonAttributeNames))]
    public void SetAttributeAcceptsCommonHtmlAttributeNames(string attributeName, string expectedAttribute)
    {
        PB_SpanBuilder builder = CreateBuilder();

        builder.SetAttribute(attributeName, "safe-value");

        Assert.That(builder.BuildAttributes(), Does.Contain(expectedAttribute));
    }

    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.InvalidAttributeNames))]
    public void SetAttributeRejectsNamesThatCanBreakHtmlAttributeGrammar(string maliciousAttributeName)
    {
        PB_SpanBuilder builder = CreateBuilder();

        Assert.That(() => builder.SetAttribute(maliciousAttributeName, "safe-value"), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("toggle", "data-toggle=\"modal\"")]
    [TestCase("bs-target", "data-bs-target=\"#dialog\"")]
    [TestCase("game.id", "data-game.id=\"42\"")]
    [TestCase("controller:action", "data-controller:action=\"safe\"")]
    public void SetDataAcceptsSafeSuffixes(string dataName, string expectedAttribute)
    {
        PB_SpanBuilder builder = CreateBuilder();

        string value = dataName switch
        {
            "game.id" => "42",
            "bs-target" => "#dialog",
            "controller:action" => "safe",
            _ => "modal"
        };
        builder.SetData(dataName, value);

        Assert.That(builder.BuildAttributes(), Does.Contain(expectedAttribute));
    }

    [TestCase("label", "aria-label=\"Close\"")]
    [TestCase("controls", "aria-controls=\"menu\"")]
    [TestCase("describedby", "aria-describedby=\"hint\"")]
    [TestCase("controls.menu", "aria-controls.menu=\"hint\"")]
    public void SetAriaAcceptsSafeSuffixes(string ariaName, string expectedAttribute)
    {
        PB_SpanBuilder builder = CreateBuilder();

        string value = ariaName switch
        {
            "label" => "Close",
            "controls" => "menu",
            _ => "hint"
        };
        builder.SetAria(ariaName, value);

        Assert.That(builder.BuildAttributes(), Does.Contain(expectedAttribute));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("toggle onclick=\"alert(1)")]
    [TestCase("bad=data")]
    [TestCase("bad<data")]
    [TestCase("bad>data")]
    [TestCase("bad`data")]
    [TestCase("bad/data")]
    public void SetDataRejectsMaliciousSuffixes(string maliciousSuffix)
    {
        PB_SpanBuilder builder = CreateBuilder();

        Assert.That(() => builder.SetData(maliciousSuffix, "safe-value"), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("label onclick=\"alert(1)")]
    [TestCase("bad=aria")]
    [TestCase("bad<aria")]
    [TestCase("bad>aria")]
    [TestCase("bad`aria")]
    [TestCase("bad/aria")]
    public void SetAriaRejectsMaliciousSuffixes(string maliciousSuffix)
    {
        PB_SpanBuilder builder = CreateBuilder();

        Assert.That(() => builder.SetAria(maliciousSuffix, "safe-value"), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void BuildAttributesRejectsInvalidAttributeNamesInjectedBySubclasses()
    {
        DefensiveAttributeBuilder builder = new DefensiveAttributeBuilder(new StringWriter(), TestHtmlHelperFactory.Create())
            .InjectAttribute("x onclick=\"alert(1)", "safe-value");

        Assert.That(() => builder.BuildAttributes(), Throws.TypeOf<ArgumentException>());
    }

    [TestCaseSource(typeof(HtmlAttributeSecurityTestCases), nameof(HtmlAttributeSecurityTestCases.AttributeValueInjectionAttempts))]
    public void SetAttributeStillEncodesPotentiallyDangerousValues(string payload, string forbiddenRawMarkup)
    {
        PB_SpanBuilder builder = CreateBuilder();

        builder.SetAttribute("title", payload);

        Assert.Multiple(() =>
        {
            string attributes = builder.BuildAttributes();
            Assert.That(attributes, Does.Contain("title=\""));
            Assert.That(attributes, Does.Not.Contain(forbiddenRawMarkup));
        });
    }

    private static PB_SpanBuilder CreateBuilder()
    {
        return new PB_SpanBuilder(new StringWriter(), TestHtmlHelperFactory.Create());
    }

    private sealed class DefensiveAttributeBuilder : HtmlTagBuilder<DefensiveAttributeBuilder>
    {
        public DefensiveAttributeBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "span";
        }

        public DefensiveAttributeBuilder InjectAttribute(string name, string value)
        {
            _attributes[name] = value;
            return this;
        }

        protected override DefensiveAttributeBuilder CreateInstance()
        {
            return new DefensiveAttributeBuilder(_textWriter, _htmlHelper);
        }
    }
}
