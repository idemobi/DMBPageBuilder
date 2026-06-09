#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;

#endregion

namespace DMBPageBuilder
{
    internal static class HtmlCommentTextEncoder
    {
        #region Static methods

        internal static string Encode(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            string safeValue = value.Replace("--", "- -", StringComparison.Ordinal);
            if (safeValue.StartsWith("-", StringComparison.Ordinal))
            {
                safeValue = " " + safeValue;
            }

            if (safeValue.EndsWith("-", StringComparison.Ordinal))
            {
                safeValue += " ";
            }

            return HtmlEncoder.Default.Encode(safeValue);
        }

        #endregion
    }
}