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
public sealed class HtmlIdGeneratorTests
{
    [TestCase("Alert 42!", "Alert")]
    [TestCase("a_b-c.d", "a_bcd")]
    [TestCase("école", "cole")]
    [TestCase("", "")]
    public void CleanIdKeepsOnlyAsciiLettersAndUnderscores(string input, string expected)
    {
        string result = input.CleanId();

        Assert.That(result, Is.EqualTo(expected));
    }
}