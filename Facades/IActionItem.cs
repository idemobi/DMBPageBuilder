#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IActionItem.cs create at 2026/05/12 08:05:05
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Defines the contract for action item.
    /// </summary>
    public interface IActionItem
    {
        #region Instance fields and properties

        bool Active { get; set; }
        string AdditionalClasses { get; set; }
        VariantStyle BadgeStyle { get; set; }

        string? BadgeText { get; set; }

        bool DebugOnly { get; set; }

        bool Disabled { get; set; }

        /// <summary>
        ///     Gets the html attributes value.
        /// </summary>
        public IReadOnlyDictionary<string, string> HtmlAttributes { get; }

        IconStruct Icon { get; set; }
        string Id { get; set; }
        bool Outline { get; set; }
        BoostrapButtonSize Size { get; set; }
        string? Subtitle { get; set; }

        string? Title { get; set; }

        VariantStyle Variant { get; set; }

        #endregion

        #region Instance methods

        IActionItem Clone();

        #endregion
    }
}