#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    internal static class HtmlTagNameValidator
    {
        #region Static methods

        internal static void Validate(string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
            {
                throw new ArgumentException("HTML tag name cannot be null or empty.", nameof(tagName));
            }

            for (int index = 0; index < tagName.Length; index++)
            {
                char character = tagName[index];
                if (char.IsWhiteSpace(character) || char.IsControl(character))
                {
                    throw new ArgumentException($"HTML tag name '{tagName}' contains an invalid character.", nameof(tagName));
                }

                if (index == 0 && !char.IsAsciiLetter(character))
                {
                    throw new ArgumentException($"HTML tag name '{tagName}' must start with an ASCII letter.", nameof(tagName));
                }

                bool isValidCharacter = char.IsAsciiLetterOrDigit(character) ||
                                        character == '-' ||
                                        character == ':';
                if (!isValidCharacter)
                {
                    throw new ArgumentException($"HTML tag name '{tagName}' contains an invalid character.", nameof(tagName));
                }
            }
        }

        #endregion
    }
}
