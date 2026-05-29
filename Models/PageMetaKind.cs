#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the HTML metadata shape rendered by <see cref="PageMetaDefinition" />.
    /// </summary>
    public enum PageMetaKind
    {
        /// <summary>
        ///     Renders a <c>meta charset</c> tag.
        /// </summary>
        Charset,

        /// <summary>
        ///     Renders a <c>meta name</c> tag.
        /// </summary>
        Name,

        /// <summary>
        ///     Renders a <c>meta property</c> tag.
        /// </summary>
        Property,

        /// <summary>
        ///     Renders a <c>meta http-equiv</c> tag.
        /// </summary>
        HttpEquiv
    }
}