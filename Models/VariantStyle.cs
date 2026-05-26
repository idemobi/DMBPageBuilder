#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj VariantStyle.cs create at 2026/05/12 08:05:05
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Represents different styles that can be applied to UI components in the PageBuilder rendering model.
    ///     This enumeration is used to define visual variants for elements such as alerts, buttons, and other UI components.
    ///     Each variant corresponds to a specific style class in the underlying CSS framework, typically Bootstrap.
    /// </summary>
    /// <remarks>
    ///     The <see cref="VariantStyle" /> enumeration is integral to the rendering pipeline of the PageBuilder.
    ///     It allows developers to specify visual styles for UI components, enhancing the user interface's aesthetic and
    ///     functionality.
    ///     The enumeration includes a range of styles, from basic variants like Normal and Primary to more specific ones like
    ///     Info, Success, Warning, Danger, Light, and Dark.
    ///     These styles are applied through methods like <see cref="SetVariant" /> in builders such as
    ///     <see cref="AlertBuilder" /> and <see cref="GroupActionItem" />.
    /// </remarks>
    public enum VariantStyle : int
    {
        /// <summary>
        ///     Represents the normal value.
        /// </summary>
        Normal = 0,

        /// <summary>
        ///     Represents the primary value.
        /// </summary>
        Primary = 1,

        /// <summary>
        ///     Represents the secondary value.
        /// </summary>
        Secondary = 2,

        /// <summary>
        ///     Represents the info value.
        /// </summary>
        Info = 6,

        /// <summary>
        ///     Represents the success value.
        /// </summary>
        Success = 9,

        /// <summary>
        ///     Represents the warning value.
        /// </summary>
        Warning = 99,

        /// <summary>
        ///     Represents the danger value.
        /// </summary>
        Danger = 999,

        /// <summary>
        ///     Represents the light value.
        /// </summary>
        Light = -1,

        /// <summary>
        ///     Represents the dark value.
        /// </summary>
        Dark = -2,
    }
}