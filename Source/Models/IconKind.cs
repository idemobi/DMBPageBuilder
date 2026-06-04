#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

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
    ///     The choice of icon kind directly influences how icon rendering helpers process and render the icon.
    ///     For instance, Bootstrap icons are
    ///     rendered using the Bootstrap Icons library, while Google Material Icons use
    ///     the material-symbols-outlined class. FontAwesome icons are rendered using
    ///     the FontAwesome library, and image-based icons are directly embedded as HTML
    ///     image tags.
    ///     This enumeration is used in conjunction with the <see cref="IconStruct" />
    ///     struct to encapsulate both the kind of icon and its value, which can then be converted to
    ///     the appropriate HTML content by PageBuilder icon rendering code.
    ///     The lifecycle of an icon kind is primarily determined by its use within
    ///     the rendering process. Once an <see cref="IconStruct" /> is created with a
    ///     specific kind, PageBuilder rendering code can produce HTML content for a web page.
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