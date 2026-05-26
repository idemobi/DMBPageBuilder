#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageArtificialIntelligenceMetaData.cs create at 2026/05/11 22:05:25
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Describes optional metadata that helps AI assistants interpret, summarize, and cite a rendered page.
    /// </summary>
    /// <remarks>
    ///     <see cref="PageBuilder" /> renders these values as <c>ai:*</c> metadata entries when
    ///     <see cref="PageInformation.ArtificialIntelligenceMetaData" /> is set.
    /// </remarks>
    public sealed class PageArtificialIntelligenceMetaData
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the intended audience exposed to AI assistants.
        /// </summary>
        public string? Audience { get; set; } = "end-users";

        /// <summary>
        ///     Gets or sets whether citations are required when AI assistants use the page.
        /// </summary>
        public bool Citation { get; set; } = true;

        /// <summary>
        ///     Gets or sets an optional disclaimer exposed to AI assistants.
        /// </summary>
        public string? Disclaimer { get; set; }

        /// <summary>
        ///     Gets or sets the page license exposed to AI assistants.
        /// </summary>
        public string? License { get; set; }

        /// <summary>
        ///     Gets or sets the page purpose exposed to AI assistants.
        /// </summary>
        public string? Purpose { get; set; } = "documentation";

        /// <summary>
        ///     Gets or sets optional usage quota guidance exposed to AI assistants.
        /// </summary>
        public string? Quotas { get; set; }

        /// <summary>
        ///     Gets or sets guidance for summarizing the page.
        /// </summary>
        public string? SummaryPolicy { get; set; } = "preserve-steps; keep-ui-labels";

        /// <summary>
        ///     Gets or sets the training permission policy exposed to AI assistants.
        /// </summary>
        public string? TrainingPermission { get; set; } = "allow";

        #endregion

        #region Instance methods

        /// <summary>
        ///     Marks the page as allowing AI training use.
        /// </summary>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData AllowTraining()
        {
            TrainingPermission = "allow";
            return this;
        }

        /// <summary>
        ///     Marks the page as forbidding AI training use.
        /// </summary>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData ForbidTraining()
        {
            TrainingPermission = "forbid";
            return this;
        }

        /// <summary>
        ///     Configures whether citations are required when AI assistants use the page.
        /// </summary>
        /// <param name="required">A value indicating whether citation is required.</param>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData RequireCitation(bool required = true)
        {
            Citation = required;
            return this;
        }

        /// <summary>
        ///     Marks the page as allowing restricted AI training use.
        /// </summary>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData RestrictTraining()
        {
            TrainingPermission = "restrict";
            return this;
        }

        /// <summary>
        ///     Sets the intended audience exposed to AI assistants.
        /// </summary>
        /// <param name="audience">The audience value, or <see langword="null" /> to omit it.</param>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData SetAudience(string? audience)
        {
            Audience = audience;
            return this;
        }

        /// <summary>
        ///     Sets an optional disclaimer exposed to AI assistants.
        /// </summary>
        /// <param name="disclaimer">The disclaimer value, or <see langword="null" /> to omit it.</param>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData SetDisclaimer(string? disclaimer)
        {
            Disclaimer = disclaimer;
            return this;
        }

        /// <summary>
        ///     Sets the page license exposed to AI assistants.
        /// </summary>
        /// <param name="license">The license value, or <see langword="null" /> to omit it.</param>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData SetLicense(string? license)
        {
            License = license;
            return this;
        }

        /// <summary>
        ///     Sets the page purpose exposed to AI assistants.
        /// </summary>
        /// <param name="purpose">The purpose value, or <see langword="null" /> to omit it.</param>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData SetPurpose(string? purpose)
        {
            Purpose = purpose;
            return this;
        }

        /// <summary>
        ///     Sets optional usage quota guidance exposed to AI assistants.
        /// </summary>
        /// <param name="quotas">The quota guidance value, or <see langword="null" /> to omit it.</param>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData SetQuotas(string? quotas)
        {
            Quotas = quotas;
            return this;
        }

        /// <summary>
        ///     Sets guidance for summarizing the page.
        /// </summary>
        /// <param name="summaryPolicy">The summary policy value, or <see langword="null" /> to omit it.</param>
        /// <returns>The current <see cref="PageArtificialIntelligenceMetaData" /> for chaining.</returns>
        public PageArtificialIntelligenceMetaData SetSummaryPolicy(string? summaryPolicy)
        {
            SummaryPolicy = summaryPolicy;
            return this;
        }

        #endregion
    }
}