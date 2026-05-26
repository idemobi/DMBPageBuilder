#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj IconStruct.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Represents an icon structure used in the PageBuilder rendering model.
    ///     This struct encapsulates the kind of icon and its value, providing a way to
    ///     specify different types of icons such as Bootstrap, Google, FontAwesome, and images.
    /// </summary>
    /// <remarks>
    ///     The IconStruct is a readonly struct designed to be lightweight and efficient.
    ///     It plays a crucial role in the rendering pipeline by allowing developers to
    ///     specify icons for various UI components, enhancing visual representation.
    /// </remarks>
    public readonly struct IconStruct
    {
        /// <summary>
        ///     Gets the icon source kind.
        /// </summary>
        public IconKind Kind { get; }

        /// <summary>
        ///     Gets the icon identifier, class name, or image URL.
        /// </summary>
        public string Value { get; }

        /// <summary>
        ///     Gets a value indicating whether this instance has no usable icon value.
        /// </summary>
        public bool IsEmpty => string.IsNullOrWhiteSpace(Value);

        /// <summary>
        ///     Gets an empty icon value.
        /// </summary>
        public static IconStruct Empty => default;

        private IconStruct(IconKind kind, string value)
        {
            Kind = kind;
            Value = value ?? string.Empty;
        }

        /// <summary>
        ///     Creates a Bootstrap icon reference from a CSS class or icon name.
        /// </summary>
        /// <param name="value">The Bootstrap icon value.</param>
        /// <returns>A Bootstrap <see cref="IconStruct" />.</returns>
        public static IconStruct Bootstrap(string value)
        {
            return new IconStruct(IconKind.Bootstrap, value);
        }

        /// <summary>
        ///     Creates a Bootstrap icon reference from a Bootstrap enum value.
        /// </summary>
        /// <param name="value">The Bootstrap enum value.</param>
        /// <returns>A Bootstrap <see cref="IconStruct" />.</returns>
        public static IconStruct BootstrapEnum(BootStrapEnum value)
        {
            return new IconStruct(IconKind.Bootstrap, value.ToString().Trim('_').Replace('_', '-'));
        }

        /// <summary>
        ///     Creates a Bootstrap icon reference from a Bootstrap enum value.
        /// </summary>
        /// <param name="value">The Bootstrap enum value.</param>
        /// <returns>A Bootstrap <see cref="IconStruct" />.</returns>
        public static IconStruct Bootstrap(BootStrapEnum value)
        {
            return new IconStruct(IconKind.Bootstrap, value.ToString().Trim('_').Replace('_', '-'));
        }

        /// <summary>
        ///     Creates a Google icon reference.
        /// </summary>
        /// <param name="value">The Google icon value.</param>
        /// <returns>A Google <see cref="IconStruct" />.</returns>
        public static IconStruct Google(string value)
        {
            return new IconStruct(IconKind.Google, value);
        }

        /// <summary>
        ///     Creates a Font Awesome icon reference.
        /// </summary>
        /// <param name="value">The Font Awesome icon value.</param>
        /// <returns>A Font Awesome <see cref="IconStruct" />.</returns>
        public static IconStruct FontAwesome(string value)
        {
            return new IconStruct(IconKind.FontAwesome, value);
        }

        /// <summary>
        ///     Creates an image icon reference.
        /// </summary>
        /// <param name="value">The image URL or path.</param>
        /// <returns>An image <see cref="IconStruct" />.</returns>
        public static IconStruct Image(string value)
        {
            return new IconStruct(IconKind.Image, value);
        }

        /// <summary>
        ///     Parses a textual icon declaration into the matching icon kind.
        /// </summary>
        /// <param name="icon">The icon declaration to parse.</param>
        /// <returns>The parsed <see cref="IconStruct" />, or <see cref="Empty" /> when no icon can be resolved.</returns>
        public static IconStruct Parse(string? icon)
        {
            if (string.IsNullOrWhiteSpace(icon))
            {
                return default;
            }

            string tIcon = icon.Trim();
            string[] alternatives = tIcon.Split('|', StringSplitOptions.RemoveEmptyEntries);
            if (alternatives.Length > 1)
            {
                foreach (string alternative in alternatives)
                {
                    IconStruct parsed = Parse(alternative.Trim());
                    if (!parsed.IsEmpty)
                    {
                        return parsed;
                    }
                }

                return default;
            }

            if (tIcon.StartsWith("bi-") || tIcon.StartsWith("bi "))
            {
                return Bootstrap(tIcon);
            }

            if (tIcon.StartsWith("google-") || tIcon.StartsWith("google "))
            {
                return Google(tIcon);
            }

            if (tIcon.StartsWith("far-") || tIcon.StartsWith("far ") ||
                tIcon.StartsWith("fa-") || tIcon.StartsWith("fa ") ||
                tIcon.StartsWith("fas-") || tIcon.StartsWith("fas ") ||
                tIcon.StartsWith("fab-") || tIcon.StartsWith("fab "))
            {
                return FontAwesome(tIcon);
            }

            if (tIcon.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                return Image(tIcon);
            }

            return Image("/" + tIcon.TrimStart('/'));
        }

        /// <summary>
        ///     Returns the icon value.
        /// </summary>
        /// <returns>The icon identifier, class name, or image URL.</returns>
        public override string ToString()
        {
            return Value;
        }
    }
}