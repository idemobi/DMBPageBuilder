#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     The DMBWebDevelopmentConfigureOptions class implements the IPostConfigureOptions interface.
    ///     It is used to configure the StaticFileOptions for DMBWebDevelopment.
    /// </summary>
    public class PageBuilderConfigureOptions : IPostConfigureOptions<StaticFileOptions>
    {
        #region Constants

        /// <summary>
        ///     The base path used for serving static files.
        /// </summary>
        const string K_BasePath = "wwwroot";

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Gets the web host environment used to compose static file providers.
        /// </summary>
        private IWebHostEnvironment Environment { get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PageBuilderConfigureOptions" /> class.
        /// </summary>
        /// <param name="sEnvironment">The web host environment used to locate web root files.</param>
        public PageBuilderConfigureOptions(IWebHostEnvironment sEnvironment)
        {
            Environment = sEnvironment;
        }

        #endregion

        #region Instance methods

        #region From interface IPostConfigureOptions<StaticFileOptions>

        /// <summary>
        ///     Configures options for serving static files.
        /// </summary>
        /// <param name="sName">The name of the options to post configure.</param>
        /// <param name="sOptions">The <see cref="StaticFileOptions" /> to configure.</param>
        public void PostConfigure(string? sName, StaticFileOptions sOptions)
        {
            sName = sName ?? throw new ArgumentNullException(nameof(sName));
            sOptions = sOptions ?? throw new ArgumentNullException(nameof(sOptions));

            sOptions.ContentTypeProvider = sOptions.ContentTypeProvider ?? new FileExtensionContentTypeProvider();
            if (sOptions.FileProvider == null && Environment.WebRootFileProvider == null)
            {
                throw new InvalidOperationException("Missing FileProvider.");
            }

            sOptions.FileProvider = sOptions.FileProvider ?? Environment.WebRootFileProvider;
            var tFilesProvider = new ManifestEmbeddedFileProvider(GetType().Assembly, K_BasePath);
            sOptions.FileProvider = new CompositeFileProvider(sOptions.FileProvider, tFilesProvider);
        }

        #endregion

        #endregion
    }
}