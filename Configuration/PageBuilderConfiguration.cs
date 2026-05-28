#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PageBuilderConfiguration.cs create at 2026/05/06 08:05:07
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder.Resources;
using DMBServerWebHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    /// Configures DMBPageBuilder services, web assets, and localization resources.
    /// </summary>
    [Serializable]
    public class PageBuilderConfiguration : WebGenericConfiguration<PageBuilderConfiguration>, IServerWebConfig
    {
        #region Static constructors and destructors

        static PageBuilderConfiguration()
        {
        }

        #endregion

        #region Instance methods

        #region From interface IServerWebConfig

        /// <summary>
        ///     Registers DMBPageBuilder services and localization resources after the host configuration has been loaded.
        /// </summary>
        /// <param name="appBuilder">The host application builder that receives the service registrations.</param>
        /// <param name="configBuilder">The configuration builder used by the host.</param>
        /// <param name="configRoot">The resolved configuration root.</param>
        public override void AfterConfiguration(IHostApplicationBuilder appBuilder, IConfigurationBuilder configBuilder, IConfigurationRoot configRoot)
        {
            appBuilder.Services.ConfigureOptions<PageBuilderConfigureOptions>();
            appBuilder.Services.AddWebAssetRegistry();
            AddAnnotationLocalization(appBuilder,
                typeof(DMBPageBuilderDataAnnotationLocalization),
                typeof(DMBPageBuilderInternalLocalization)
            );
        }

        /// <summary>
        ///     Gets a value indicating whether API description services are required.
        /// </summary>
        /// <returns><see langword="false" /> because DMBPageBuilder does not expose API descriptions.</returns>
        public override bool ApiDescription()
        {
            return false;
        }

        /// <summary>
        ///     Runs before host configuration is finalized.
        /// </summary>
        /// <param name="appBuilder">The host application builder.</param>
        /// <param name="configBuilder">The configuration builder used by the host.</param>
        /// <param name="configRoot">The resolved configuration root.</param>
        public override void BeforeConfiguration(IHostApplicationBuilder appBuilder, IConfigurationBuilder configBuilder, IConfigurationRoot configRoot)
        {
        }

        /// <summary>
        ///     Gets a value indicating whether this package requires a dedicated configuration file or app settings section.
        /// </summary>
        /// <returns><see langword="false" /> because DMBPageBuilder registers without dedicated settings.</returns>
        public override bool NeedsConfigFileOrAppSettings()
        {
            return false;
        }

        /// <summary>
        ///     Keeps the shared configuration contract satisfied without generating sample data.
        /// </summary>
        public override void RandomFake()
        {
        }

        #endregion

        #endregion
    }
}