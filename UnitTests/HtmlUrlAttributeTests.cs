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
public sealed class HtmlUrlAttributeTests
{
    [TestCase("/dashboard")]
    [TestCase("./dashboard")]
    [TestCase("../dashboard")]
    [TestCase("#details")]
    [TestCase("?tab=details")]
    [TestCase("https://example.com/dashboard")]
    [TestCase("http://example.com/dashboard")]
    [TestCase("mailto:contact@example.com")]
    [TestCase("tel:+33123456789")]
    public void AnchorHrefAcceptsSafeUrls(string href)
    {
        PB_AnchorBuilder builder = new PB_AnchorBuilder(new StringWriter(), TestHtmlHelperFactory.Create());

        builder.SetHref(href);

        Assert.That(builder.BuildAttributes(), Does.Contain("href=\""));
    }

    [TestCase("javascript:alert(1)")]
    [TestCase("JavaScript:alert(1)")]
    [TestCase(" javaScript:alert(1)")]
    [TestCase("java\nscript:alert(1)")]
    [TestCase("vbscript:msgbox(1)")]
    [TestCase("data:text/html,<script>alert(1)</script>")]
    public void AnchorHrefRejectsDangerousUrls(string href)
    {
        PB_AnchorBuilder builder = new PB_AnchorBuilder(new StringWriter(), TestHtmlHelperFactory.Create());

        Assert.That(() => builder.SetHref(href), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void AudioAndVideoBuildersAcceptMatchingMediaDataUrls()
    {
        PB_AudioBuilder audioBuilder = new PB_AudioBuilder(new StringWriter(), TestHtmlHelperFactory.Create());
        PB_VideoBuilder videoBuilder = new PB_VideoBuilder(new StringWriter(), TestHtmlHelperFactory.Create());

        audioBuilder.SetSrc("data:audio/mpeg;base64,AAAA");
        videoBuilder.SetSrc("data:video/mp4;base64,AAAA");
        videoBuilder.SetPoster("data:image/png;base64,AAAA");

        Assert.Multiple(() =>
        {
            Assert.That(audioBuilder.BuildAttributes(), Does.Contain("src=\"data:audio/mpeg;base64,AAAA\""));
            Assert.That(videoBuilder.BuildAttributes(), Does.Contain("src=\"data:video/mp4;base64,AAAA\""));
            Assert.That(videoBuilder.BuildAttributes(), Does.Contain("poster=\"data:image/png;base64,AAAA\""));
        });
    }

    [Test]
    public void ImageSrcAcceptsSafeImageDataUrl()
    {
        PB_ImgBuilder builder = new PB_ImgBuilder(new StringWriter(), TestHtmlHelperFactory.Create());

        builder.SetSrc("data:image/png;base64,AAAA");

        Assert.That(builder.BuildAttributes(), Does.Contain("src=\"data:image/png;base64,AAAA\""));
    }

    [TestCase("data:image/svg+xml,<svg onload=alert(1)>")]
    [TestCase("data:text/html,<script>alert(1)</script>")]
    [TestCase("javascript:alert(1)")]
    public void ImageSrcRejectsDangerousUrls(string src)
    {
        PB_ImgBuilder builder = new PB_ImgBuilder(new StringWriter(), TestHtmlHelperFactory.Create());

        Assert.That(() => builder.SetSrc(src), Throws.TypeOf<ArgumentException>());
    }

    [TestCase("javascript:alert(1)", true)]
    [TestCase("data:text/html,<script>alert(1)</script>", false)]
    public void PageInformationRejectsDangerousHeadAssetUrlsWhenRegistered(string url, bool script)
    {
        Assert.That(
            () =>
            {
                if (script)
                {
                    new PageInformation().SetScriptFile(url);
                }
                else
                {
                    new PageInformation().SetStylesheet(url);
                }
            },
            Throws.TypeOf<ArgumentException>());
    }

    [TestCase("href", "javascript:alert(1)")]
    [TestCase("src", "javascript:alert(1)")]
    [TestCase("action", "javascript:alert(1)")]
    [TestCase("poster", "data:text/html,<script>alert(1)</script>")]
    public void SetAttributeRejectsDangerousUrlAttributeValues(string attributeName, string value)
    {
        PB_SpanBuilder builder = new PB_SpanBuilder(new StringWriter(), TestHtmlHelperFactory.Create());

        Assert.That(() => builder.SetAttribute(attributeName, value), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void SourceSrcSetRejectsDangerousCandidateUrls()
    {
        PB_SourceBuilder builder = new PB_SourceBuilder(new StringWriter(), TestHtmlHelperFactory.Create());

        Assert.That(() => builder.SetSrcSet("/img/a.png 1x, javascript:alert(1) 2x"), Throws.TypeOf<ArgumentException>());
    }
}