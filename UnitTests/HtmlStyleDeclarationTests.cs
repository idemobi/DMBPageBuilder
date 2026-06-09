#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class HtmlStyleDeclarationTests
{
    private static PB_SpanBuilder CreateBuilder()
    {
        return new PB_SpanBuilder(new StringWriter(), TestHtmlHelperFactory.Create());
    }

    private sealed class DefensiveStyleBuilder : HtmlTagBuilder<DefensiveStyleBuilder>
    {
        #region Instance constructors and destructors

        public DefensiveStyleBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "span";
        }

        #endregion

        #region Instance methods

        protected override DefensiveStyleBuilder CreateInstance()
        {
            return new DefensiveStyleBuilder(_textWriter, _htmlHelper);
        }

        public DefensiveStyleBuilder InjectStyle(string key, string value)
        {
            _styles[key] = value;
            return this;
        }

        #endregion
    }

    [Test]
    public void BuildAttributesRejectsInvalidStylesInjectedBySubclasses()
    {
        DefensiveStyleBuilder builder = new DefensiveStyleBuilder(new StringWriter(), TestHtmlHelperFactory.Create())
            .InjectStyle("background", "url(javascript:alert(1))");

        Assert.That(() => builder.BuildAttributes(), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("color", "red", "style=\"color:red;\"")]
    [TestCase("z-index", "10", "style=\"z-index:10;\"")]
    [TestCase("--brand-color", "#0d6efd", "style=\"--brand-color:#0d6efd;\"")]
    [TestCase("-webkit-line-clamp", "2", "style=\"-webkit-line-clamp:2;\"")]
    [TestCase("background", "linear-gradient(transparent,rgba(0,0,0,.72))", "style=\"background:linear-gradient(transparent,rgba(0,0,0,.72));\"")]
    [TestCase("width", "calc(100% - 1rem)", "style=\"width:calc(100% - 1rem);\"")]
    [TestCase("color", "var(--brand-color)", "style=\"color:var(--brand-color);\"")]
    [TestCase("background-image", "url('/images/background.png')", "style=\"background-image:url(&#x27;/images/background.png&#x27;);\"")]
    [TestCase("background-image", "url(https://example.com/background.png)", "style=\"background-image:url(https://example.com/background.png);\"")]
    [TestCase("background-image", "url(data:image/png;base64,AAAA)", "style=\"background-image:url(data:image/png;base64,AAAA);\"")]
    public void SetStyleAcceptsCommonCssDeclarations(string key, string value, string expectedAttribute)
    {
        PB_SpanBuilder builder = CreateBuilder();

        builder.SetStyle(key, value);

        Assert.That(builder.BuildAttributes(), Does.Contain(expectedAttribute));
    }

    [Test]
    public void SetStyleKeepsImportantFlagForSafeValues()
    {
        PB_SpanBuilder builder = CreateBuilder();

        builder.SetStyle("display", "none", important: true);

        Assert.That(builder.BuildAttributes(), Does.Contain("style=\"display:none !important;\""));
    }

    [TestCase("red;background:url('/safe.png')")]
    [TestCase("url(javascript:alert(1))")]
    [TestCase("url(\"javascript:alert(1)\")")]
    [TestCase("url(vbscript:msgbox(1))")]
    [TestCase("url(data:text/html,<script>alert(1)</script>)")]
    [TestCase("url(data:image/svg+xml,<svg onload=alert(1)>)")]
    [TestCase("url(data:image/svg+xml;base64,AAAA)")]
    [TestCase("expression(alert(1))")]
    [TestCase("@import url('/evil.css')")]
    [TestCase("<style>body{display:none}</style>")]
    [TestCase("red\u0001")]
    public void SetStyleRejectsDangerousCssValues(string value)
    {
        PB_SpanBuilder builder = CreateBuilder();

        Assert.That(() => builder.SetStyle("background-image", value), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("color;background")]
    [TestCase("color:background")]
    [TestCase("color{background}")]
    [TestCase("color<background")]
    [TestCase("color/background")]
    [TestCase("color\"background")]
    [TestCase("color\u0001background")]
    public void SetStyleRejectsInvalidCssPropertyNames(string key)
    {
        PB_SpanBuilder builder = CreateBuilder();

        Assert.That(() => builder.SetStyle(key, "red"), Throws.TypeOf<ArgumentException>());
    }
}