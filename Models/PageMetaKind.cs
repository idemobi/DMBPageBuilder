#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageMetaKind.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

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