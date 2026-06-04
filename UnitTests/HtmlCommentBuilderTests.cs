#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.IO;
using DMBPageBuilder;
using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

[TestFixture]
public sealed class HtmlCommentBuilderTests
{
    [Test]
    public void HtmlCommentEncodesTextAndNeutralizesClosingDelimiter()
    {
        using StringWriter writer = new();
        HtmlComment comment = new HtmlComment(writer, TestHtmlHelperFactory.Create(), "-safe --><script>alert(1)</script>-");

        comment.Render();

        string html = writer.ToString();
        Assert.Multiple(() =>
        {
            Assert.That(html, Is.EqualTo("<!--  -safe - -&gt;&lt;script&gt;alert(1)&lt;/script&gt;-  -->"));
            Assert.That(CountOccurrences(html, "-->"), Is.EqualTo(1));
        });
    }

    [TestCaseSource(nameof(CommentInjectionAttempts))]
    public void HtmlCommentNeutralizesInjectionAttempts(string payload, string? forbiddenRawMarkup)
    {
        using StringWriter writer = new();
        HtmlComment comment = new HtmlComment(writer, TestHtmlHelperFactory.Create(), payload);

        comment.Render();

        string html = writer.ToString();
        Assert.Multiple(() =>
        {
            Assert.That(html, Does.StartWith("<!-- "));
            Assert.That(html, Does.EndWith(" -->"));
            Assert.That(CountOccurrences(html, "-->"), Is.EqualTo(1));
            if (!string.IsNullOrEmpty(forbiddenRawMarkup))
            {
                Assert.That(html, Does.Not.Contain(forbiddenRawMarkup));
            }
        });
    }

    private static IEnumerable<TestCaseData> CommentInjectionAttempts()
    {
        yield return new TestCaseData("--><script>alert(1)</script><!--", "<script>")
            .SetName("Script tag injection is encoded");
        yield return new TestCaseData("--><style>body{display:none}</style><!--", "<style>")
            .SetName("Style tag injection is encoded");
        yield return new TestCaseData("--><link rel=\"stylesheet\" href=\"/evil.css\"><!--", "<link")
            .SetName("Stylesheet link injection is encoded");
        yield return new TestCaseData("--><img src=x onerror=alert(1)><!--", "<img")
            .SetName("Html event handler injection is encoded");
        yield return new TestCaseData("--><div class=\"overlay\">owned</div><!--", "<div")
            .SetName("Html element injection is encoded");
        yield return new TestCaseData("-leading-dash-", null)
            .SetName("Leading and trailing dash payload cannot touch comment boundaries");
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
}
