#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the crossorigin attribute value rendered on script and link tags.
    /// </summary>
    public enum PageCrossOrigin
    {
        /// <summary>
        ///     Omits the <c>crossorigin</c> attribute.
        /// </summary>
        None,

        /// <summary>
        ///     Renders <c>crossorigin="anonymous"</c>.
        /// </summary>
        Anonymous,

        /// <summary>
        ///     Renders <c>crossorigin="use-credentials"</c>.
        /// </summary>
        UseCredentials
    }
}