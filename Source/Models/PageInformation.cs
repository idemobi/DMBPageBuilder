#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using Schema.NET;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Stores all page-level rendering information consumed by <see cref="PageBuilder" />.
    /// </summary>
    /// <remarks>
    ///     Controllers and Razor helpers populate this model with title, culture, metadata, links, scripts,
    ///     stylesheets, favicon definitions, schema.org data, alerts, and body rendering behavior. The layout then
    ///     renders the collected information through <see cref="PageBuilder" />.
    /// </remarks>
    public class PageInformation
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the MVC action name associated with the page.
        /// </summary>
        public string ActionName { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the manager that stores page-level alerts.
        /// </summary>
        public IPageAlertManager AlertManager { get; set; } = new PageAlertManager();

        /// <summary>
        ///     Gets or sets optional metadata exposed to AI assistants in the document head.
        /// </summary>
        public PageArtificialIntelligenceMetaData? ArtificialIntelligenceMetaData { get; set; }

        /// <summary>
        ///     Gets or sets the body layout renderer used by <see cref="PageBuilder" />.
        /// </summary>
        public IBodyBuilder BodyBuilder { get; set; } = new BasicBodyBuilder();

        /// <summary>
        ///     Gets or sets the breadcrumb actions associated with the page.
        /// </summary>
        public List<IActionItem> BreadcrumbActions { set; get; } = new List<IActionItem>();

        /// <summary>
        ///     Gets or sets the MVC controller name associated with the page.
        /// </summary>
        public string ControllerName { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the composer used to render the cookie consent prompt when required.
        /// </summary>
        public ICookieConsentComposer? CookieConsentComposer { get; set; }

        /// <summary>
        ///     Gets or sets the culture used to render the document language.
        /// </summary>
        public CultureInfo? Culture { get; set; }

        /// <summary>
        ///     Gets or sets the favicon file base name used by <see cref="PageBuilder" />.
        /// </summary>
        public string? FaviconBaseName { get; set; }

        /// <summary>
        ///     Gets or sets the favicon base path used by <see cref="PageBuilder" />.
        /// </summary>
        public string? FaviconBasePath { get; set; }


        /// <summary>
        ///     Gets or sets the favicon set rendered in the document head.
        /// </summary>
        public PageFaviconSet FaviconSet { get; set; } = PageFaviconSet.None;

        /// <summary>
        ///     Stores a unique identifier used in PageBuilder debug comments.
        /// </summary>
        public string Id = Guid.NewGuid().ToString();

        /// <summary>
        ///     Gets or sets the keyword values rendered as a keywords metadata tag.
        /// </summary>
        public List<string> Keywords { get; set; } = new List<string>();

        /// <summary>
        ///     Gets or sets the ordering value used for the generated keywords metadata tag.
        /// </summary>
        public int KeywordsOrder { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the URL used by language redirection UI.
        /// </summary>
        public string LanguageRedirection { get; set; } = "#";

        /// <summary>
        ///     Stores link definitions rendered in the document head, keyed by <see cref="PageLinkDefinition.Href" />.
        /// </summary>
        public readonly Dictionary<string, PageLinkDefinition> Links = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores metadata definitions rendered in the document head.
        /// </summary>
        public readonly List<PageMetaDefinition> Metas = new();

        /// <summary>
        ///     Gets or sets whether the page should render cookie consent UI when consent is missing.
        /// </summary>
        public bool NeedCookieConsent { get; set; } = true;

        /// <summary>
        ///     Gets or sets schema.org JSON-LD objects rendered in the document head.
        /// </summary>
        public List<IThing> SchemaOrg { get; set; } = new List<IThing>();

        /// <summary>
        ///     Stores external script definitions rendered in the document, keyed by script URL.
        /// </summary>
        public readonly Dictionary<string, PageScriptDefinition> Scripts = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores inline script definitions rendered in the document, keyed by script name.
        /// </summary>
        public readonly Dictionary<string, ScriptInline> ScriptsInline = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores inline stylesheets rendered in the document head, keyed by stylesheet name.
        /// </summary>
        public readonly Dictionary<string, StyleSheetInline> StylesheetsInline = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Gets or sets the document title rendered in the HTML <c>title</c> tag.
        /// </summary>
        public string? Title { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds a prepared page alert to the alert manager.
        /// </summary>
        /// <param name="alert">The alert model to add.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation AddAlert(PageAlertModel alert)
        {
            AlertManager.AddAlert(alert);
            return this;
        }

        /// <summary>
        ///     Adds a page alert using layout, style, title, message, and optional details.
        /// </summary>
        /// <param name="layout">The alert layout.</param>
        /// <param name="style">The alert style.</param>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">Optional detail lines rendered by the alert manager.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation AddAlert(PageAlertLayout layout, PageAlertStyle style, string title, string? message, IEnumerable<string>? details = null)
        {
            AlertManager.AddAlert(layout, style, title, message, details);
            return this;
        }

        /// <summary>
        ///     Adds an error alert to the page alert manager.
        /// </summary>
        /// <param name="title">The alert title.</param>
        /// <param name="message">The optional alert message.</param>
        /// <param name="details">Optional detail lines rendered by the alert manager.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation AddError(string title, string? message, IEnumerable<string>? details = null)
        {
            AlertManager.AddError(title, message, details);
            return this;
        }

        /// <summary>
        ///     Adds an exception alert to the page alert manager.
        /// </summary>
        /// <param name="exception">The exception represented by the alert.</param>
        /// <param name="details">Optional detail lines rendered by the alert manager.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation AddException(Exception exception, IEnumerable<string>? details = null)
        {
            AlertManager.AddException(exception, details);
            return this;
        }

        /// <summary>
        ///     Adds an HTTP error alert to the page alert manager.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="reasonPhrase">The optional reason phrase.</param>
        /// <param name="originalUrl">The optional original URL.</param>
        /// <param name="requestUrl">The optional request URL.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation AddHttpError(int statusCode, string? reasonPhrase, string? originalUrl = null, string? requestUrl = null)
        {
            AlertManager.AddHttpError(statusCode, reasonPhrase, originalUrl, requestUrl);
            return this;
        }

        /// <summary>
        ///     Adds or replaces a link definition rendered in the document head.
        /// </summary>
        /// <param name="link">The link definition to add.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="link" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown when <see cref="PageLinkDefinition.Href" /> is empty or unsafe.</exception>
        public PageInformation AddLink(PageLinkDefinition link)
        {
            ArgumentNullException.ThrowIfNull(link);
            HtmlAssetUrlValidator.ValidateRequiredUrl("href", link.Href);
            Links[link.Href] = link;
            return this;
        }

        /// <summary>
        ///     Adds a metadata definition rendered in the document head.
        /// </summary>
        /// <param name="meta">The metadata definition to add.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="meta" /> is <see langword="null" />.</exception>
        public PageInformation AddMeta(PageMetaDefinition meta)
        {
            ArgumentNullException.ThrowIfNull(meta);
            Metas.Add(meta);
            return this;
        }

        /// <summary>
        ///     Adds a schema.org object rendered as JSON-LD in the document head.
        /// </summary>
        /// <param name="thing">The schema.org object to render.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="thing" /> is <see langword="null" />.</exception>
        public PageInformation AddSchemaOrg(IThing thing)
        {
            ArgumentNullException.ThrowIfNull(thing);
            SchemaOrg.Add(thing);
            return this;
        }

        /// <summary>
        ///     Adds or replaces an external script definition rendered by <see cref="PageBuilder" />.
        /// </summary>
        /// <param name="script">The script definition to add.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="script" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Thrown when <see cref="PageScriptDefinition.Url" /> is empty or unsafe.</exception>
        public PageInformation AddScript(PageScriptDefinition script)
        {
            ArgumentNullException.ThrowIfNull(script);
            HtmlAssetUrlValidator.ValidateRequiredUrl("src", script.Url);
            Scripts[script.Url] = script;
            return this;
        }


        /// <summary>
        ///     Adds or replaces an inline script block rendered by <see cref="PageBuilder" />.
        /// </summary>
        /// <param name="name">The script key and optional generated comment name.</param>
        /// <param name="script">The raw JavaScript content to render.</param>
        /// <param name="location">The document location where the script is rendered.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        /// <remarks>Consumers must only pass trusted JavaScript content.</remarks>
        public PageInformation AddScriptInline(string name, string script, PageScriptLocation location = PageScriptLocation.EndOfBody)
        {
            ScriptsInline[name] = new ScriptInline
            {
                Name = name,
                Script = script,
                Location = location
            };
            return this;
        }

        /// <summary>
        ///     Adds or replaces an inline stylesheet rendered in the document head.
        /// </summary>
        /// <param name="name">The stylesheet key and optional generated comment name.</param>
        /// <param name="content">The raw CSS content to render.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        /// <remarks>Consumers must only pass trusted CSS content.</remarks>
        public PageInformation AddStyleSheetInline(string name, string content)
        {
            StylesheetsInline[name] = new StyleSheetInline
            {
                Name = name,
                Content = content
            };
            return this;
        }

        /// <summary>
        ///     Enables and configures AI-oriented metadata for the page.
        /// </summary>
        /// <param name="configure">An optional configuration callback for the metadata object.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetArtificialIntelligenceProfile(Action<PageArtificialIntelligenceMetaData>? configure = null)
        {
            ArtificialIntelligenceMetaData = new PageArtificialIntelligenceMetaData();
            configure?.Invoke(ArtificialIntelligenceMetaData);
            return this;
        }

        /// <summary>
        ///     Replaces the body layout renderer used by <see cref="PageBuilder" />.
        /// </summary>
        /// <param name="bodyBuilder">The body renderer to use.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetBodyBuilder(IBodyBuilder bodyBuilder)
        {
            BodyBuilder = bodyBuilder;
            return this;
        }

        /// <summary>
        ///     Adds a charset metadata tag with high-priority ordering.
        /// </summary>
        /// <param name="charset">The charset value to render.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetCharset(PageCharset charset)
        {
            Metas.Add(PageMetaDefinition.Charset(charset).SetOrder(-100));
            return this;
        }

        /// <summary>
        ///     Sets the culture used to render the HTML document language.
        /// </summary>
        /// <param name="culture">The culture to use, or <see langword="null" /> to fall back to the current culture.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetCulture(CultureInfo? culture)
        {
            Culture = culture;
            return this;
        }

        /// <summary>
        ///     Adds a description metadata tag.
        /// </summary>
        /// <param name="description">The page description.</param>
        /// <param name="order">The metadata ordering value.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetDescription(string description, int order = 0)
        {
            return AddMeta(PageMetaDefinition.NameMeta(PageMetaName.Description, description).SetOrder(order));
        }

        /// <summary>
        ///     Configures the favicon set rendered in the document head.
        /// </summary>
        /// <param name="set">The favicon set to render.</param>
        /// <param name="basePath">The path containing favicon files.</param>
        /// <param name="baseName">The base filename used for favicon files.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetFavicon(PageFaviconSet set, string basePath = "/favicons/", string baseName = "favicon")
        {
            FaviconSet = set;
            FaviconBasePath = basePath;
            FaviconBaseName = baseName;
            return this;
        }

        /// <summary>
        ///     Sets the keywords metadata values with the default ordering.
        /// </summary>
        /// <param name="keywords">The keyword values. Empty values are ignored.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetKeywords(params string[] keywords)
        {
            return SetKeywords(0, keywords);
        }

        /// <summary>
        ///     Sets the keywords metadata values and ordering.
        /// </summary>
        /// <param name="order">The metadata ordering value.</param>
        /// <param name="keywords">The keyword values. Empty values are ignored.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetKeywords(int order, params string[] keywords)
        {
            KeywordsOrder = order;
            Keywords = keywords.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            return this;
        }

        /// <summary>
        ///     Adds a <c>revisit-after</c> metadata tag.
        /// </summary>
        /// <param name="days">The revisit interval in days.</param>
        /// <param name="order">The metadata ordering value.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetRevisitAfterDays(int days, int order = 0)
        {
            return AddMeta(PageMetaDefinition.NameMeta(PageMetaName.RevisitAfter, $"{days} days").SetOrder(order));
        }

        /// <summary>
        ///     Adds a robots metadata tag.
        /// </summary>
        /// <param name="content">The robots metadata content.</param>
        /// <param name="order">The metadata ordering value.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetRobots(string content, int order = 0)
        {
            return AddMeta(PageMetaDefinition.NameMeta(PageMetaName.Robots, content).SetOrder(order));
        }

        /// <summary>
        ///     Adds or replaces an external script file rendered by <see cref="PageBuilder" />.
        /// </summary>
        /// <param name="url">The script URL.</param>
        /// <param name="location">The document location where the script is rendered.</param>
        /// <param name="loadingMode">The browser loading mode.</param>
        /// <param name="order">The script ordering value.</param>
        /// <param name="crossOrigin">The crossorigin policy.</param>
        /// <param name="integrity">The optional subresource integrity hash.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetScriptFile(
            string url,
            PageScriptLocation location = PageScriptLocation.Head,
            PageScriptLoadingMode loadingMode = PageScriptLoadingMode.Defer,
            int order = 0,
            PageCrossOrigin crossOrigin = PageCrossOrigin.None,
            string? integrity = null
        )
        {
            return AddScript(new PageScriptDefinition
            {
                Url = url,
                Location = location,
                LoadingMode = loadingMode,
                Order = order,
                CrossOrigin = crossOrigin,
                Integrity = integrity
            });
        }

        /// <summary>
        ///     Adds or replaces a stylesheet link rendered in the document head.
        /// </summary>
        /// <param name="href">The stylesheet URL.</param>
        /// <param name="order">The link ordering value.</param>
        /// <param name="crossOrigin">The crossorigin policy.</param>
        /// <param name="integrity">The optional subresource integrity hash.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetStylesheet(string href, int order = 0, PageCrossOrigin crossOrigin = PageCrossOrigin.None, string? integrity = null)
        {
            return AddLink(new PageLinkDefinition
            {
                Rel = PageLinkRel.Stylesheet,
                Href = href,
                Order = order,
                CrossOrigin = crossOrigin,
                Integrity = integrity
            });
        }

        /// <summary>
        ///     Sets the document title rendered in the HTML <c>title</c> tag.
        /// </summary>
        /// <param name="title">The document title, or <see langword="null" /> to omit the title tag.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetTitle(string? title)
        {
            Title = title;
            return this;
        }

        /// <summary>
        ///     Adds a viewport metadata tag.
        /// </summary>
        /// <param name="content">The viewport metadata content.</param>
        /// <returns>The current <see cref="PageInformation" /> for chaining.</returns>
        public PageInformation SetViewport(string content = "width=device-width, initial-scale=1.0")
        {
            return AddMeta(PageMetaDefinition.NameMeta(PageMetaName.Viewport, content).SetOrder(-90));
        }

        #endregion
    }
}