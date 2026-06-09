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
public sealed class CustomClassesComposerTests
{
    [Test]
    public void BuildClassesReturnsDistinctNonEmptyClassesInInsertionOrder()
    {
        CustomClassesComposer composer = new CustomClassesComposer()
            .Add("alpha")
            .Add(" ")
            .Add("beta")
            .Add("alpha");

        IReadOnlyList<string> classes = composer.BuildClasses();

        Assert.That(classes, Is.EqualTo(new[] { "alpha", "beta" }));
    }

    [Test]
    public void RemoveClearAndCloneKeepIndependentState()
    {
        CustomClassesComposer composer = new CustomClassesComposer()
            .AddRange(new[] { "alpha", "beta", "gamma" })
            .Remove("beta");

        IIsCssClassComposer clone = composer.Clone();
        composer.Clear();

        Assert.Multiple(() =>
        {
            Assert.That(composer.BuildClasses(), Is.Empty);
            Assert.That(clone.BuildClasses(), Is.EqualTo(new[] { "alpha", "gamma" }));
        });
    }
}