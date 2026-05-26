#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj HtmlVersion.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Represents the version of HTML used for rendering content in the PageBuilder framework.
    ///     This enumeration provides two options: Html4 and Html5, which determine the syntax
    ///     and features supported by the HTML output. The choice of HTML version affects how certain
    ///     tags are rendered, particularly void elements like &lt;img&gt; or &lt;br&gt;.
    /// </summary>
    /// <remarks>
    ///     The HtmlVersion enumeration is used in conjunction with the <see cref="HtmlBuilderBase{TBuilder}" />
    ///     class to ensure that the rendered HTML adheres to the specified version's standards.
    ///     This is particularly important for void elements, which have different closing syntax
    ///     in Html4 (self-closing with a space) versus Html5 (no self-closing slash).
    /// </remarks>
    public enum HtmlVersion
    {
        /// <summary>
        ///     Represents the html4 value.
        /// </summary>
        Html4,

        /// <summary>
        ///     Represents the html5 value.
        /// </summary>
        Html5,
    }
}