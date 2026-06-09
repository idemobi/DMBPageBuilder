#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class HtmlTagNameTests
{
    private static string RenderContent(IHtmlContent content)
    {
        using StringWriter writer = new StringWriter();
        content.WriteTo(writer, HtmlEncoder.Default);
        return writer.ToString();
    }

    private sealed class TestConstrainedTagBuilder : HtmlConstrainedTagBuilder<TestConstrainedTagBuilder>
    {
        #region Instance constructors and destructors

        public TestConstrainedTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
        }

        #endregion

        #region Instance methods

        protected override TestConstrainedTagBuilder CreateInstance()
        {
            return new TestConstrainedTagBuilder(_textWriter, _htmlHelper);
        }

        public TestConstrainedTagBuilder SetTagForTest(string tagName)
        {
            _tag = tagName;
            return this;
        }

        #endregion
    }

    private sealed class TestTagBuilder : HtmlTagBuilder<TestTagBuilder>
    {
        #region Instance constructors and destructors

        public TestTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
        }

        #endregion

        #region Instance methods

        protected override TestTagBuilder CreateInstance()
        {
            return new TestTagBuilder(_textWriter, _htmlHelper);
        }

        public TestTagBuilder SetTagForTest(string tagName)
        {
            _tag = tagName;
            return this;
        }

        #endregion
    }

    private sealed class TestVoidTagBuilder : HtmlVoidTagBuilder<TestVoidTagBuilder>
    {
        #region Instance constructors and destructors

        public TestVoidTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
        }

        #endregion

        #region Instance methods

        protected override TestVoidTagBuilder CreateInstance()
        {
            return new TestVoidTagBuilder(_textWriter, _htmlHelper);
        }

        public TestVoidTagBuilder SetTagForTest(string tagName)
        {
            _tag = tagName;
            return this;
        }

        #endregion
    }

    [Test]
    public void HtmlConstrainedTagBuilderRejectsUnsafeTagNames()
    {
        TestConstrainedTagBuilder builder = new TestConstrainedTagBuilder(new StringWriter(), TestHtmlHelperFactory.Create())
            .SetTagForTest("li onclick=\"alert(1)");

        Assert.That(() => RenderContent(builder), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("div")]
    [TestCase("custom-element")]
    [TestCase("svg:path")]
    [TestCase("h1")]
    public void HtmlTagBuilderAcceptsSafeTagNames(string tagName)
    {
        TestTagBuilder builder = new TestTagBuilder(new StringWriter(), TestHtmlHelperFactory.Create())
            .SetTagForTest(tagName);

        string html = RenderContent(builder);

        Assert.Multiple(() =>
        {
            Assert.That(html, Does.StartWith($"<{tagName}"));
            Assert.That(html, Does.EndWith($"</{tagName}>"));
            Assert.That(html, Does.Not.Contain("onclick"));
        });
    }

    [Test]
    public void HtmlTagBuilderBeginRejectsUnsafeTagNameWithoutWritingUnsafeElement()
    {
        using StringWriter writer = new StringWriter();
        TestTagBuilder builder = new TestTagBuilder(writer, TestHtmlHelperFactory.Create())
            .SetTagForTest("div onclick=\"alert(1)");

        Assert.Multiple(() =>
        {
            Assert.That(() => builder.Begin(), Throws.TypeOf<ArgumentException>());
            Assert.That(writer.ToString(), Does.Not.Contain("<div"));
            Assert.That(writer.ToString(), Does.Not.Contain("onclick"));
        });
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("1tag")]
    [TestCase("-tag")]
    [TestCase(":tag")]
    [TestCase("div onclick=\"alert(1)")]
    [TestCase("div>")]
    [TestCase("script>alert(1)</script")]
    [TestCase("div/onload")]
    [TestCase("div`onload")]
    [TestCase("div\u0001")]
    public void HtmlTagBuilderRejectsUnsafeTagNames(string tagName)
    {
        TestTagBuilder builder = new TestTagBuilder(new StringWriter(), TestHtmlHelperFactory.Create())
            .SetTagForTest(tagName);

        Assert.That(() => RenderContent(builder), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void HtmlVoidTagBuilderRejectsUnsafeTagNames()
    {
        TestVoidTagBuilder builder = new TestVoidTagBuilder(new StringWriter(), TestHtmlHelperFactory.Create())
            .SetTagForTest("img onerror=\"alert(1)");

        Assert.That(() => RenderContent(builder), Throws.TypeOf<ArgumentException>());
    }
}