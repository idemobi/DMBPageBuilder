#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBPageBuilder
{
    internal static class HtmlReservedAttributeValidator
    {
        #region Static methods

        internal static void EnsureCanSetGenericAttribute(string name)
        {
            if (string.Equals(name, "class", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Use CSS class APIs instead of setting the \"class\" attribute directly.");
            }

            if (string.Equals(name, "style", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Use style declaration APIs instead of setting the \"style\" attribute directly.");
            }
        }

        #endregion
    }
}