#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj LoremIpsumGenerator.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Generates lightweight lorem ipsum text for sample pages and demos.
    /// </summary>
    public static class LoremIpsumGenerator
    {
        #region Static fields and properties

        private static readonly string[] LoremIpsumWords = new[]
        {
            "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "sed", "do",
            "eiusmod", "tempor", "incididunt", "ut", "labore", "et", "dolore", "magna", "aliqua", "ut… Itoque ",
            "enim", "ad", "minim", "veniam", "quis", "nostrud", "exercitation", "ullamco", "laboris",
            "nisi", "ut", "aliquip", "ex", "ea", "commodo", "consequat", "salve. Salut", "julius! Horribilis", "ne? Sed etiam",
        };

        #endregion

        #region Static methods

        /// <summary>
        ///     Generates a sentence-like lorem ipsum text with a random number of words.
        /// </summary>
        /// <param name="min">The minimum number of words to generate.</param>
        /// <param name="max">The maximum number of words to generate.</param>
        /// <returns>A generated lorem ipsum sentence.</returns>
        public static string RandomWords(int min, int max)
        {
            if (min < 1)
            {
                min = 1;
            }

            if (max < 2)
            {
                max = 2;
            }

            if (min > max)
            {
                (min, max) = (max, min);
            }

            var random = new Random();
            int wordCount = random.Next(min, max + 1);
            string loremText = string.Join(" ", Enumerable.Range(0, wordCount).Select(_ => LoremIpsumWords[random.Next(LoremIpsumWords.Length)]));
            if (!string.IsNullOrWhiteSpace(loremText))
            {
                loremText = char.ToUpper(loremText[0]) + loremText.Substring(1);
            }

            return loremText.TrimEnd(new char[] { '.', '!', '?', ';', ',', '…' }) + ".";
        }

        #endregion
    }
}