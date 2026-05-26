#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IconKind.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Represents the kind of icon to be used in rendering.
    ///     This enumeration is utilized within the PageBuilder framework to specify
    ///     different types of icons that can be integrated into HTML content.
    /// </summary>
    /// <remarks>
    ///     The <see cref="IconKind" /> enumeration is integral to the rendering pipeline
    ///     of the PageBuilder, particularly when dealing with icon-based content.
    ///     Each member of this enumeration corresponds to a specific type of icon source,
    ///     which can be Bootstrap, Google Material Icons, FontAwesome, or an image.
    ///     The choice of icon kind directly influences how the <see cref="IconBuilder" />
    ///     method processes and renders the icon. For instance, Bootstrap icons are
    ///     rendered using the Bootstrap Icons library, while Google Material Icons use
    ///     the material-symbols-outlined class. FontAwesome icons are rendered using
    ///     the FontAwesome library, and image-based icons are directly embedded as HTML
    ///     image tags.
    ///     This enumeration is used in conjunction with the <see cref="IconStruct" />
    ///     struct to encapsulate both the kind of icon and its value, which is then
    ///     used by the <see cref="HtmlLayoutExtensions.IconBuilder" /> method to generate
    ///     the appropriate HTML content.
    ///     The lifecycle of an icon kind is primarily determined by its use within
    ///     the rendering process. Once an <see cref="IconStruct" /> is created with a
    ///     specific kind, it is processed by the <see cref="IconBuilder" /> method to
    ///     produce HTML content that can be rendered on a web page.
    ///     The <see cref="IconKind" /> enumeration is part of the DMBPageBuilder namespace
    ///     and is designed to be used in conjunction with other PageBuilder components,
    ///     such as <see cref="HtmlBuilderBase{TBuilder}" /> and <see cref="PageInformation" />.
    /// </remarks>
    public enum IconKind
    {
        /// <summary>
        ///     Represents the none value.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Represents the bootstrap value.
        /// </summary>
        Bootstrap = 1,

        /// <summary>
        ///     Represents the google value.
        /// </summary>
        Google = 2,

        /// <summary>
        ///     Represents the font awesome value.
        /// </summary>
        FontAwesome = 3,

        /// <summary>
        ///     Represents the image value.
        /// </summary>
        Image = 4
    }
}