#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageContainer.cs create at 2026/05/06 08:05:07
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Represents the different types of page containers in the DMB Web Runtime.
    /// </summary>
    [Serializable]
    /// <summary>
    /// Defines values used by page container.
    /// </summary>
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