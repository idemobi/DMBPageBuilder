#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using NUnit.Framework;

#endregion

namespace DMBPageBuilderUnitTest;

internal static class HtmlAttributeSecurityTestCases
{
    #region Static methods

    internal static IEnumerable<TestCaseData> AttributeValueInjectionAttempts()
    {
        yield return new TestCaseData("\" onclick=\"alert(1)<script>alert(2)</script>", "<script>")
            .SetName("Script value injection is encoded");
        yield return new TestCaseData("\" style=\"display:none\"><style>body{display:none}</style>", "<style>")
            .SetName("Css value injection is encoded");
        yield return new TestCaseData("\" onerror=\"alert(1)\"><img src=x>", "<img")
            .SetName("Html value injection is encoded");
    }

    internal static IEnumerable<TestCaseData> CommonAttributeNames()
    {
        yield return new TestCaseData("id", "id=\"safe-value\"").SetName("Id attribute is accepted");
        yield return new TestCaseData("data-bs-toggle", "data-bs-toggle=\"safe-value\"").SetName("Data attribute is accepted");
        yield return new TestCaseData("aria-describedby", "aria-describedby=\"safe-value\"").SetName("Aria attribute is accepted");
        yield return new TestCaseData("x-on:click", "x-on:click=\"safe-value\"").SetName("Colon attribute is accepted");
        yield return new TestCaseData("@click", "@click=\"safe-value\"").SetName("At-sign attribute is accepted");
        yield return new TestCaseData("data-game.id", "data-game.id=\"safe-value\"").SetName("Dot attribute is accepted");
        yield return new TestCaseData("xml:lang", "xml:lang=\"safe-value\"").SetName("Xml namespace-like attribute is accepted");
    }

    internal static IEnumerable<TestCaseData> InvalidAttributeNames()
    {
        yield return new TestCaseData("").SetName("Empty attribute name is rejected");
        yield return new TestCaseData(" ").SetName("Whitespace attribute name is rejected");
        yield return new TestCaseData("x onclick=\"alert(1)").SetName("Space injection attribute name is rejected");
        yield return new TestCaseData("x\tonclick").SetName("Tab injection attribute name is rejected");
        yield return new TestCaseData("x\nonclick").SetName("Newline injection attribute name is rejected");
        yield return new TestCaseData("x=onclick").SetName("Equals injection attribute name is rejected");
        yield return new TestCaseData("x\"onclick").SetName("Double quote injection attribute name is rejected");
        yield return new TestCaseData("x'onclick").SetName("Single quote injection attribute name is rejected");
        yield return new TestCaseData("x`onclick").SetName("Backtick injection attribute name is rejected");
        yield return new TestCaseData("<img").SetName("Opening tag injection attribute name is rejected");
        yield return new TestCaseData("x>y").SetName("Closing tag injection attribute name is rejected");
        yield return new TestCaseData("x/onload").SetName("Slash injection attribute name is rejected");
        yield return new TestCaseData("x\u0001onload").SetName("Control character injection attribute name is rejected");
    }

    #endregion
}