#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj HtmlIdGenerator.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides helpers for generating request-scoped unique HTML identifiers.
    /// </summary>
    public static class HtmlIdGenerator
    {
        #region Constants

        private const string GeneratedIdsKey = "__GENERATED_HTML_IDS__";

        #endregion

        #region Static methods

        /// <summary>
        ///     Removes characters that are not valid for the generated HTML identifier convention.
        /// </summary>
        /// <param name="id">The identifier fragment to normalize.</param>
        /// <returns>The normalized identifier fragment.</returns>
        public static string CleanId(this string id)
        {
            return Regex.Replace(id, "[^a-zA-Z_]", string.Empty);
        }

        private static string CreateRandomToken(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var buffer = new byte[length];
            RandomNumberGenerator.Fill(buffer);

            var result = new char[length];

            for (var i = 0; i < length; i++)
            {
                result[i] = chars[buffer[i] % chars.Length];
            }

            return new string(result);
        }

        /// <summary>
        ///     Generates a unique HTML identifier within the current HTTP request.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper that exposes the current HTTP context.</param>
        /// <param name="prefix">The identifier prefix to normalize and use.</param>
        /// <returns>A unique identifier for the current request.</returns>
        public static string GenerateUniqueId(this IHtmlHelper htmlHelper, string prefix = "uni")
        {
            prefix = CleanId(prefix);

            if (htmlHelper is null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            var items = htmlHelper.ViewContext.HttpContext.Items;

            if (!items.TryGetValue(GeneratedIdsKey, out var existingIdsObject) ||
                existingIdsObject is not HashSet<string> existingIds)
            {
                existingIds = new HashSet<string>(StringComparer.Ordinal);
                items[GeneratedIdsKey] = existingIds;
            }

            string id;

            do
            {
                id = $"{prefix}_{CreateRandomToken(8)}";
            } while (!existingIds.Add(id));

            return id;
        }

        #endregion
    }
}