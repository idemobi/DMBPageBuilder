#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System;

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines values used by page container.
    /// </summary>
    [Serializable]
    public enum PageContainer : int
    {
        /// <summary>
        ///     Enum member representing the container page in the PageContainer enum.
        /// </summary>
        ContainerPage = 0,

        /// <summary>
        ///     Represents the IndependentPage member of the PageContainer enum.
        /// </summary>
        IndependentPage = 9,

        /// <summary>
        ///     Represents a PDF page in the PageContainer enum.
        /// </summary>
        PdfPage = 10,
    }
}