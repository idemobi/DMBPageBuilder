#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text;

#endregion

namespace DMBPageBuilder
{
    internal static class HtmlRawElementContentEncoder
    {
        #region Static methods

        internal static string EncodeClosingElement(string? content, string elementName)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }

            HtmlTagNameValidator.Validate(elementName);

            string closingTagStart = "</" + elementName;
            int searchIndex = 0;
            StringBuilder? builder = null;

            while (searchIndex < content.Length)
            {
                int matchIndex = content.IndexOf(closingTagStart, searchIndex, StringComparison.OrdinalIgnoreCase);
                if (matchIndex < 0)
                {
                    break;
                }

                builder ??= new StringBuilder(content.Length + 8);
                builder.Append(content, searchIndex, matchIndex - searchIndex);
                builder.Append("<\\/");
                builder.Append(content, matchIndex + 2, elementName.Length);
                searchIndex = matchIndex + closingTagStart.Length;
            }

            if (builder == null)
            {
                return content;
            }

            builder.Append(content, searchIndex, content.Length - searchIndex);
            return builder.ToString();
        }

        #endregion
    }
}
