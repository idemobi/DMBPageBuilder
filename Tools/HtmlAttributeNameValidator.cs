#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    internal static class HtmlAttributeNameValidator
    {
        #region Static methods

        internal static void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Attribute name cannot be null or empty.", nameof(name));
            }

            foreach (char character in name)
            {
                if (char.IsWhiteSpace(character) || char.IsControl(character))
                {
                    throw new ArgumentException($"Attribute name '{name}' contains an invalid character.", nameof(name));
                }

                switch (character)
                {
                    case '"':
                    case '\'':
                    case '`':
                    case '=':
                    case '<':
                    case '>':
                    case '/':
                        throw new ArgumentException($"Attribute name '{name}' contains an invalid character.", nameof(name));
                }
            }
        }

        #endregion
    }
}
