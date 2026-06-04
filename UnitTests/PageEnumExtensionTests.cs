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
public sealed class PageEnumExtensionTests
{
    [Test]
    public void KnownEnumValuesReturnExpectedHtmlTokens()
    {
        Assert.Multiple(() =>
        {
            Assert.That(PageCharset.Utf8.GetValue(), Is.EqualTo("utf-8"));
            Assert.That(PageCrossOrigin.Anonymous.GetValue(), Is.EqualTo("anonymous"));
            Assert.That(PageCrossOrigin.UseCredentials.GetValue(), Is.EqualTo("use-credentials"));
            Assert.That(PageLinkRel.AppleTouchIcon.GetValue(), Is.EqualTo("apple-touch-icon"));
            Assert.That(PageIconSize.S180.GetValue(), Is.EqualTo("180x180"));
            Assert.That(PageMetaName.TwitterDescription.GetValue(), Is.EqualTo("twitter:description"));
        });
    }

    [Test]
    public void NoneValuesReturnEmptyHtmlTokens()
    {
        Assert.Multiple(() =>
        {
            Assert.That(PageCrossOrigin.None.GetValue(), Is.Empty);
            Assert.That(PageIconSize.None.GetValue(), Is.Empty);
        });
    }
}