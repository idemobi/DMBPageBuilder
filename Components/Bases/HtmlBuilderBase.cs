#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides a base class for building HTML content with customizable attributes and styles.
    ///     This abstract class implements <see cref="IHtmlContent" />, <see cref="IHasStyleBuilder{TBuilder}" />, and
    ///     <see cref="IHasInternalStore{TBuilder}" /> interfaces.
    ///     It manages HTML attributes, CSS classes, internal data storage, and rendering logic.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the builder, which must inherit from <see cref="HtmlBuilderBase{TBuilder}" />.</typeparam>
    public abstract class HtmlBuilderBase<TBuilder> : IHtmlContent, IHasStyleBuilder<TBuilder>, IHasInternalStore<TBuilder>
        where TBuilder : HtmlBuilderBase<TBuilder>
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a dictionary that holds the attributes of an HTML element.
        ///     Attributes are key-value pairs where the key is the attribute name
        ///     and the value is the attribute value. This dictionary is used to store
        ///     custom attributes that will be applied to the HTML element when it is rendered.
        /// </summary>
        protected readonly Dictionary<string, string> _attributes;

        /// <summary>
        ///     Represents a collection that holds CSS classes assigned to an HTML component.
        ///     This collection is used to accumulate and manage the CSS class names that will be applied to the HTML element
        ///     when it is rendered, allowing for easy manipulation and addition of classes throughout the lifecycle of the
        ///     component.
        /// </summary>
        protected readonly HashSet<string> _classesOfComponent = new(StringComparer.Ordinal);

        /// <summary>
        ///     Represents a list of composers responsible for adding CSS class compositions to the HTML element.
        ///     Each composer in this list implements the IIsCssClassComposer interface and is used to apply
        ///     specific CSS classes or styles dynamically. This list allows for flexible extension of styling capabilities.
        /// </summary>
        protected readonly List<IIsCssClassComposer> _composers;

        /// <summary>
        ///     Provides an instance of <see cref="IHtmlHelper" /> used for rendering HTML elements and managing HTML generation
        ///     within the builder.
        ///     This helper is utilized across various builder classes to facilitate the creation and manipulation of HTML content
        ///     dynamically.
        /// </summary>
        protected readonly IHtmlHelper _htmlHelper;

        /// <summary>
        ///     Represents a dictionary that holds internal state or settings specific to the HTML builder.
        ///     Entries in this dictionary are key-value pairs where the key is a string identifier for
        ///     the internal setting and the value can be any object. This dictionary is used to store
        ///     various configuration options or state information that are internal to the builder's operation.
        /// </summary>
        protected readonly Dictionary<string, object?> _internals;

        /// <summary>
        ///     Represents a dictionary that holds the CSS styles applicable to an HTML element.
        ///     Styles are key-value pairs where the key is the style property name
        ///     and the value is the style value. This dictionary is used to store
        ///     custom styles that will be applied to the HTML element when it is rendered.
        /// </summary>
        protected readonly Dictionary<string, string> _styles;

        /// <summary>
        ///     Represents the HTML tag that will be rendered by this builder class.
        ///     The default value is "div", but it can be changed to other HTML tags as needed
        ///     by setting this property in the constructor or through other methods provided
        ///     by the class. This tag specifies the type of HTML element that will be generated.
        /// </summary>
        protected string _tag = "div";

        /// <summary>
        ///     Represents a writer that outputs text content to be rendered as HTML.
        ///     This text writer is used by various builder classes to generate and
        ///     write HTML content efficiently. It serves as the primary means of
        ///     outputting structured HTML strings that can be used in web applications.
        /// </summary>
        protected readonly TextWriter _textWriter;

        /// <summary>
        ///     Represents the HTML version used for rendering the content.
        ///     This property determines the syntax and features supported by the HTML output,
        ///     with possible values being Html4 or Html5.
        /// </summary>
        protected HtmlVersion _version = HtmlVersion.Html5;

        #if DEBUG
        /// <summary>
        ///     Represents a counter that tracks the number of times the HTML element has been rendered.
        ///     This property is used internally to provide debugging information, specifically to track
        ///     how many times the element has been rendered during a page lifecycle.
        /// </summary>
        protected int RenderCounter
        {
            get => GetInternal("RenderCounter", 0);
            set => SetInternal("RenderCounter", value);
        }
        #endif

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes the shared builder state for a PageBuilder HTML component.
        /// </summary>
        /// <param name="writer">The writer used when <see cref="Render" /> writes directly to the Razor output.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="writer" /> or <paramref name="html" /> is <see langword="null" />.
        /// </exception>
        protected HtmlBuilderBase(TextWriter writer, IHtmlHelper html)
        {
            _htmlHelper = html ?? throw new ArgumentNullException(nameof(html));
            _textWriter = writer ?? throw new ArgumentNullException(nameof(writer));

            _attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            _internals = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
            _styles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            _composers = new List<IIsCssClassComposer>();

            #if DEBUG
            RenderCounter = 0;
            SetAttribute("modern-component", typeof(TBuilder).Name);
            #endif
        }

        #endregion

        #region Instance methods

        #region From interface IHasInternalStore<TBuilder>

        /// <summary>
        ///     Gets an internal value stored by key.
        /// </summary>
        /// <typeparam name="T">The expected value type.</typeparam>
        /// <param name="key">The internal key.</param>
        /// <param name="defaultValue">The fallback value returned when no typed value exists.</param>
        /// <returns>The stored typed value, or <paramref name="defaultValue" />.</returns>
        public T GetInternal<T>(string key, T defaultValue = default!)
        {
            if (_internals.TryGetValue(key, out object? value) && value is T typed)
            {
                return typed;
            }

            return defaultValue;
        }

        /// <summary>
        ///     Stores an internal value by key.
        /// </summary>
        /// <param name="key">The internal key.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetInternal(string key, object? value)
        {
            _internals[key] = value;
            return This();
        }

        #endregion

        #region From interface IHasStyleBuilder<TBuilder>

        /// <summary>
        ///     Sets or replaces an inline CSS style declaration.
        /// </summary>
        /// <param name="key">The CSS property name.</param>
        /// <param name="value">The CSS property value.</param>
        /// <param name="important">A value indicating whether to append <c>!important</c>.</param>
        /// <returns>The current builder instance for chaining.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="key" /> is empty.</exception>
        public TBuilder SetStyle(string key, string value, bool important = false)
        {
            HtmlStyleDeclarationValidator.ValidatePropertyName(key);
            HtmlStyleDeclarationValidator.ValidatePropertyValue(key, value);

            _styles[key] = important
                ? $"{value} !important"
                : value;

            return This();
        }

        #endregion

        #endregion

        #region Public methods

        /// <summary>
        ///     Renders the current component to the builder writer.
        /// </summary>
        /// <returns><see cref="HtmlString.Empty" /> because the output is written directly to the configured writer.</returns>
        public virtual IHtmlContent Render()
        {
            WriteTo(_textWriter, HtmlEncoder.Default);
            return HtmlString.Empty;
        }

        /// <summary>
        ///     Writes the current component to the provided writer.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="encoder">The HTML encoder supplied by the Razor rendering pipeline.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="writer" /> or <paramref name="encoder" /> is <see langword="null" />.
        /// </exception>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            ArgumentNullException.ThrowIfNull(writer);
            ArgumentNullException.ThrowIfNull(encoder);

            OnRenderDebug();
            WriteToCore(writer, encoder);
        }

        /// <summary>
        ///     Prevents implicit conversion of builders to strings.
        /// </summary>
        /// <returns>This member always throws.</returns>
        /// <exception cref="InvalidOperationException">Always thrown to force explicit rendering.</exception>
        public sealed override string ToString()
        {
            throw new InvalidOperationException(
                $"{GetType().Name} cannot be converted implicitly to string. Use WriteTo(...) or Render().");
        }

        /// <summary>
        ///     Renders the current component into an HTML string.
        /// </summary>
        /// <returns>The rendered HTML markup.</returns>
        public string ToHtmlString()
        {
            using StringWriter writer = new();
            WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        /// <summary>
        ///     Gets a stored attribute value.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="defaultValue">The value returned when the attribute is not present.</param>
        /// <returns>The stored attribute value or <paramref name="defaultValue" />.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name" /> is empty.</exception>
        public string GetAttribute(string name, string defaultValue = "")
        {
            ValidateAttributeName(name);
            return _attributes.TryGetValue(name, out string? value) ? value : defaultValue;
        }

        /// <summary>
        ///     Gets a stored attribute value when it exists.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns>The stored attribute value, or <see langword="null" /> when the attribute is absent.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name" /> is empty.</exception>
        protected string? GetAttributeValue(string name)
        {
            ValidateAttributeName(name);
            return _attributes.TryGetValue(name, out var value) ? value : null;
        }

        /// <summary>
        ///     Determines whether an attribute with the specified name is present in the set of attributes.
        /// </summary>
        /// <param name="name">The name of the attribute to check.</param>
        /// <returns><c>true</c> if an attribute with the specified name exists; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name" /> is empty.</exception>
        protected bool HasAttribute(string name)
        {
            ValidateAttributeName(name);
            return _attributes.ContainsKey(name);
        }

        /// <summary>
        ///     Gets the current HTML <c>id</c> attribute.
        /// </summary>
        /// <returns>The current <c>id</c> value, or an empty string when no identifier is set.</returns>
        public string GetId()
        {
            return GetAttribute("id", string.Empty);
        }

        /// <summary>
        ///     Gets the HTML tag name rendered by this builder.
        /// </summary>
        /// <returns>The HTML tag name.</returns>
        public string GetTag()
        {
            ValidateTagName();
            return _tag;
        }

        /// <summary>
        ///     Sets, replaces, or removes an HTML attribute on the current element.
        /// </summary>
        /// <param name="name">The name of the attribute to set.</param>
        /// <param name="value">The attribute value, or <see langword="null" /> or empty to remove the attribute.</param>
        /// <returns>The current builder instance for chaining.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name" /> is empty.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when attempting to set reserved <c>class</c> or <c>style</c>
        ///     attributes directly.
        /// </exception>
        public TBuilder SetAttribute(string name, string? value)
        {
            ValidateAttributeName(name);
            EnsureReservedAttributeIsNotMisused(name);

            if (string.IsNullOrEmpty(value))
            {
                _attributes.Remove(name);
                return This();
            }

            ValidateAttributeValue(name, value);
            _attributes[name] = value;
            return This();
        }

        /// <summary>
        ///     Sets a boolean HTML attribute value as <c>true</c> or <c>false</c>.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The boolean value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute(string name, bool value)
        {
            return SetAttribute(name, value ? "true" : "false");
        }

        /// <summary>
        ///     Sets an integer HTML attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute(string name, int value)
        {
            return SetAttribute(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a long integer HTML attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute(string name, long value)
        {
            return SetAttribute(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a single-precision HTML attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute(string name, float value)
        {
            return SetAttribute(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a double-precision HTML attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute(string name, double value)
        {
            return SetAttribute(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a decimal HTML attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute(string name, decimal value)
        {
            return SetAttribute(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a GUID HTML attribute value using the canonical <c>D</c> format.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute(string name, Guid value)
        {
            return SetAttribute(name, value.ToString("D"));
        }

        /// <summary>
        ///     Sets a date-time HTML attribute value using round-trip invariant formatting.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute(string name, DateTime value)
        {
            return SetAttribute(name, value.ToString("O", CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets an attribute of the HTML element.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value to set for the attribute. Can be null.</param>
        /// <returns>The current instance of the builder, allowing for method chaining.</returns>
        public TBuilder SetAttribute(string name, DateTimeOffset value)
        {
            return SetAttribute(name, value.ToString("O", CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets an enum HTML attribute value using the enum name.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to serialize.</typeparam>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The enum value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetAttribute<TEnum>(string name, TEnum value)
            where TEnum : struct, Enum
        {
            return SetAttribute(name, value.ToString());
        }

        /// <summary>
        ///     Sets, replaces, or removes an ARIA attribute.
        /// </summary>
        /// <param name="name">The ARIA suffix without the <c>aria-</c> prefix.</param>
        /// <param name="value">The ARIA value, or <see langword="null" /> or empty to remove the attribute.</param>
        /// <returns>The current builder instance for chaining.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name" /> is empty.</exception>
        public TBuilder SetAria(string name, string? value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Aria attribute name cannot be null or empty.", nameof(name));
            }

            return SetAttribute($"aria-{name}", value);
        }

        /// <summary>
        ///     Sets, replaces, or removes a data attribute.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The data value, or <see langword="null" /> or empty to remove the attribute.</param>
        /// <returns>The current builder instance for chaining.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name" /> is empty.</exception>
        public TBuilder SetData(string name, string? value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Data attribute name cannot be null or empty.", nameof(name));
            }

            return SetAttribute($"data-{name}", value);
        }

        /// <summary>
        ///     Sets a boolean data attribute value.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The boolean value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData(string name, bool value)
        {
            return SetData(name, value.ToString().ToLowerInvariant());
        }

        /// <summary>
        ///     Sets an integer data attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData(string name, int value)
        {
            return SetData(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a long integer data attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData(string name, long value)
        {
            return SetData(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a single-precision data attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData(string name, float value)
        {
            return SetData(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a double-precision data attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData(string name, double value)
        {
            return SetData(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a decimal data attribute value using invariant culture.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData(string name, decimal value)
        {
            return SetData(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a data attribute on the HTML element.
        /// </summary>
        /// <param name="name">The name of the data attribute.</param>
        /// <param name="value">The value to assign to the data attribute.</param>
        /// <returns>The current instance of the builder, allowing for method chaining.</returns>
        public TBuilder SetData(string name, Guid value)
        {
            return SetData(name, value.ToString("D"));
        }

        /// <summary>
        ///     Sets a date-time data attribute value using round-trip invariant formatting.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData(string name, DateTime value)
        {
            return SetData(name, value.ToString("O", CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets a date-time-offset data attribute value using round-trip invariant formatting.
        /// </summary>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData(string name, DateTimeOffset value)
        {
            return SetData(name, value.ToString("O", CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Sets an enum data attribute value using the enum name.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to serialize.</typeparam>
        /// <param name="name">The data attribute suffix without the <c>data-</c> prefix.</param>
        /// <param name="value">The enum value to serialize.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetData<TEnum>(string name, TEnum value)
            where TEnum : struct, Enum
        {
            return SetData(name, value.ToString());
        }

        /// <summary>
        ///     Sets or removes the HTML <c>disabled</c> boolean attribute.
        /// </summary>
        /// <param name="disabled">A value indicating whether the element should be disabled.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetDisabled(bool disabled = true)
        {
            if (disabled)
            {
                _attributes["disabled"] = "disabled";
            }
            else
            {
                _attributes.Remove("disabled");
            }

            return This();
        }

        /// <summary>
        ///     Sets the HTML <c>id</c> attribute.
        /// </summary>
        /// <param name="id">The element identifier.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetId(string id)
        {
            return SetAttribute("id", id);
        }

        /// <summary>
        ///     Ensures the builder has an HTML <c>id</c> attribute.
        /// </summary>
        /// <param name="prefix">The prefix used when generating a new identifier.</param>
        /// <returns>The current builder instance for chaining.</returns>
        /// <remarks>If an identifier already exists, it is preserved.</remarks>
        public TBuilder SetEnsureId(string prefix = "ensure_id_")
        {
            if (string.IsNullOrWhiteSpace(GetAttributeValue("id")))
            {
                SetId(_htmlHelper.GenerateUniqueId(prefix));
            }

            return This();
        }

        /// <summary>
        ///     Sets the HTML <c>name</c> attribute.
        /// </summary>
        /// <param name="name">The element name.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder SetName(string name)
        {
            return SetAttribute("name", name);
        }

        /// <summary>
        ///     Adds one or more CSS classes to the current HTML component.
        /// </summary>
        /// <param name="cssClass">A string containing one or more CSS classes separated by spaces.</param>
        /// <returns>The current instance of the builder to allow method chaining.</returns>
        protected TBuilder InternalAddClass(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
            {
                return This();
            }

            foreach (var cls in cssClass.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                _classesOfComponent.Add(cls);
            }

            return This();
        }

        /// <summary>
        ///     Adds one or more CSS classes to the internal set of classes for the HTML component.
        /// </summary>
        /// <param name="cssClasses">A params array of CSS class names to be added.</param>
        /// <returns>The current instance of the builder, allowing for method chaining.</returns>
        protected TBuilder InternalAddClasses(params string[] cssClasses)
        {
            if (cssClasses == null) return This();

            foreach (var css in cssClasses)
            {
                InternalAddClass(css);
            }

            return This();
        }

        /// <summary>
        ///     Gets the registered CSS composer of the requested type.
        /// </summary>
        /// <typeparam name="TComposer">The composer type to retrieve.</typeparam>
        /// <returns>The registered composer, or <see langword="null" /> when no composer of that type exists.</returns>
        public TComposer? GetCssComposer<TComposer>()
            where TComposer : class, IIsCssClassComposer
        {
            return _composers.OfType<TComposer>().FirstOrDefault();
        }

        /// <summary>
        ///     Gets an existing CSS composer of the specified type or creates a new one using the provided factory function.
        /// </summary>
        /// <typeparam name="TComposer">The type of the CSS composer to get or create.</typeparam>
        /// <param name="factory">A factory function used to create a new composer if none exists.</param>
        /// <returns>The existing or newly created CSS composer of the specified type.</returns>
        public TComposer GetOrCreateCssComposer<TComposer>(Func<TComposer> factory)
            where TComposer : class, IIsCssClassComposer
        {
            TComposer? existing = GetCssComposer<TComposer>();
            if (existing != null)
            {
                return existing;
            }

            TComposer created = factory();
            SetCssComposer(created);
            return created;
        }

        /// <summary>
        ///     Registers a CSS composer and replaces any existing composer of the same type.
        /// </summary>
        /// <typeparam name="TComposer">The composer type to register.</typeparam>
        /// <param name="composer">The composer instance.</param>
        /// <returns>The current builder instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="composer" /> is <see langword="null" />.</exception>
        public TBuilder SetCssComposer<TComposer>(TComposer composer)
            where TComposer : class, IIsCssClassComposer
        {
            ArgumentNullException.ThrowIfNull(composer);

            _composers.RemoveAll(x => x is TComposer);
            _composers.Add(composer);

            return This();
        }

        /// <summary>
        ///     Removes one CSS style declaration from the builder.
        /// </summary>
        /// <param name="key">The CSS property name.</param>
        public void RemoveStyle(string key)
        {
            _styles.Remove(key);
        }

        /// <summary>
        ///     Creates a copy of the current builder state with a generated clone identifier.
        /// </summary>
        /// <returns>A cloned builder instance.</returns>
        public virtual TBuilder Clone()
        {
            TBuilder result = CreateInstance();
            result.InternalClone((TBuilder)this);
            result.SetId(_htmlHelper.GenerateUniqueId("clone_"));
            return result;
        }

        #endregion

        #region Protected methods

        /// <summary>
        ///     Writes the concrete builder markup to the rendering pipeline.
        /// </summary>
        /// <param name="writer">The writer receiving the rendered markup.</param>
        /// <param name="encoder">The HTML encoder supplied by Razor.</param>
        protected abstract void WriteToCore(TextWriter writer, HtmlEncoder encoder);

        /// <summary>
        ///     Creates a new builder instance of the concrete builder type.
        /// </summary>
        /// <returns>A new builder instance.</returns>
        protected abstract TBuilder CreateInstance();

        /// <summary>
        ///     Gets the current instance typed as the concrete builder type.
        /// </summary>
        /// <returns>The current builder instance.</returns>
        protected TBuilder This()
        {
            return (TBuilder)this;
        }

        /// <summary>
        ///     Copies state from another builder instance into this builder.
        /// </summary>
        /// <param name="source">The source builder to copy.</param>
        protected virtual void InternalClone(TBuilder source)
        {
            _tag = source._tag;
            _classesOfComponent.Clear();
            foreach (string cssClass in source._classesOfComponent)
            {
                _classesOfComponent.Add(cssClass);
            }

            _version = source._version;

            _attributes.Clear();
            foreach (KeyValuePair<string, string> kvp in source._attributes)
            {
                _attributes[kvp.Key] = kvp.Value;
            }

            _internals.Clear();
            foreach (KeyValuePair<string, object?> kvp in source._internals)
            {
                _internals[kvp.Key] = kvp.Value;
            }

            _styles.Clear();
            foreach (KeyValuePair<string, string> kvp in source._styles)
            {
                _styles[kvp.Key] = kvp.Value;
            }

            _composers.Clear();
            foreach (IIsCssClassComposer composer in source._composers)
            {
                _composers.Add(composer.Clone());
            }
        }

        /// <summary>
        ///     Removes an attribute from the builder.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name" /> is empty.</exception>
        protected void RemoveAttribute(string name)
        {
            ValidateAttributeName(name);
            _attributes.Remove(name);
        }

        /// <summary>
        ///     Removes all stored HTML attributes.
        /// </summary>
        protected void CleanAllAttributes()
        {
            _attributes.Clear();
        }

        /// <summary>
        ///     Builds the encoded HTML attribute string for the current builder.
        /// </summary>
        /// <returns>The leading-space-prefixed attribute string, or an empty string when no attributes exist.</returns>
        public virtual string BuildAttributes()
        {
            string classValue = BuildClassValue();
            string styleValue = BuildStyleValue();

            List<string> attributes = new();

            if (!string.IsNullOrWhiteSpace(classValue))
            {
                attributes.Add($@"class=""{HtmlEncoder.Default.Encode(classValue)}""");
            }

            if (!string.IsNullOrWhiteSpace(styleValue))
            {
                attributes.Add($@"style=""{HtmlEncoder.Default.Encode(styleValue)}""");
            }

            attributes.AddRange(
                _attributes
                    .Where(x => !string.Equals(x.Key, "class", StringComparison.OrdinalIgnoreCase))
                    .Where(x => !string.Equals(x.Key, "style", StringComparison.OrdinalIgnoreCase))
                    .Where(x => !string.IsNullOrWhiteSpace(x.Value))
                    .Select(x =>
                    {
                        ValidateAttributeName(x.Key);
                        ValidateAttributeValue(x.Key, x.Value);

                        if (IsBooleanAttribute(x.Key, x.Value))
                        {
                            return x.Key;
                        }

                        return $@"{x.Key}=""{HtmlEncoder.Default.Encode(x.Value)}""";
                    }));

            return attributes.Count > 0
                ? " " + string.Join(" ", attributes.Distinct(StringComparer.Ordinal))
                : string.Empty;
        }

        /// <summary>
        ///     Gets the CSS classes owned directly by this builder.
        /// </summary>
        /// <returns>The direct component class collection.</returns>
        protected IEnumerable<string> GetComponentClasses()
        {
            return _classesOfComponent;
        }

        /// <summary>
        ///     Builds the complete CSS class value from direct classes and CSS composers.
        /// </summary>
        /// <returns>The CSS class value, or an empty string when no classes exist.</returns>
        public virtual string BuildClassValue()
        {
            List<string> classes = new();

            classes.AddRange(GetComponentClasses());

            foreach (IIsCssClassComposer composer in _composers)
            {
                classes.AddRange(composer.BuildClasses().Where(x => !string.IsNullOrWhiteSpace(x)));
            }

            return string.Join(" ", classes.Distinct(StringComparer.Ordinal));
        }

        /// <summary>
        ///     Builds the complete inline style value from stored style declarations.
        /// </summary>
        /// <returns>The inline style value, or an empty string when no styles exist.</returns>
        protected virtual string BuildStyleValue()
        {
            if (_styles.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new();

            foreach (KeyValuePair<string, string> kvp in _styles)
            {
                HtmlStyleDeclarationValidator.ValidatePropertyName(kvp.Key);
                HtmlStyleDeclarationValidator.ValidatePropertyValue(kvp.Key, kvp.Value);
                sb.Append(kvp.Key);
                sb.Append(':');
                sb.Append(kvp.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        private static bool IsBooleanAttribute(string name, string value)
        {
            return string.Equals(name, "disabled", StringComparison.OrdinalIgnoreCase)
                   && string.Equals(value, "disabled", StringComparison.OrdinalIgnoreCase);
        }

        private static void ValidateAttributeName(string name)
        {
            HtmlAttributeNameValidator.Validate(name);
        }

        /// <summary>
        ///     Validates one HTML attribute value before it is rendered.
        /// </summary>
        /// <param name="name">The validated HTML attribute name.</param>
        /// <param name="value">The HTML attribute value to validate.</param>
        /// <exception cref="ArgumentException">Thrown when a URL attribute value uses an unsafe URL scheme.</exception>
        protected virtual void ValidateAttributeValue(string name, string value)
        {
            HtmlUrlAttributeValidator.Validate(name, value);
        }

        /// <summary>
        ///     Validates the current HTML tag name before rendering.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the tag name is invalid.</exception>
        protected void ValidateTagName()
        {
            HtmlTagNameValidator.Validate(_tag);
        }

        /// <summary>
        ///     Ensures that reserved attributes are not being misused.
        /// </summary>
        /// <param name="name">The attribute name to be validated.</param>
        private static void EnsureReservedAttributeIsNotMisused(string name)
        {
            HtmlReservedAttributeValidator.EnsureCanSetGenericAttribute(name);
        }

        /// <summary>
        ///     Adds debug attributes to the builder while running a debug build.
        /// </summary>
        [Conditional("DEBUG")]
        protected void OnRenderDebug()
        {
            #if DEBUG
            _attributes["data-render-counter"] = RenderCounter++.ToString(CultureInfo.InvariantCulture);
            _attributes["data-builder"] = GetType().Name;
            #endif
        }

        /// <summary>
        ///     Temporarily adds internal classes and restores the previous class set when disposed.
        /// </summary>
        /// <param name="cssClasses">The temporary CSS classes.</param>
        /// <returns>A disposable scope that restores the previous classes.</returns>
        protected IDisposable PushInternalClasses(params string[] cssClasses)
        {
            HashSet<string> snapshot = new(_classesOfComponent, StringComparer.Ordinal);

            InternalAddClasses(cssClasses);

            return new InternalDisposableAction(() =>
            {
                _classesOfComponent.Clear();

                foreach (string cssClass in snapshot)
                {
                    _classesOfComponent.Add(cssClass);
                }
            });
        }

        /// <summary>
        ///     Represents an action that can be disposed of, typically used to revert changes or clean up resources.
        ///     This class implements the <see cref="IDisposable" /> interface and runs the configured callback once.
        /// </summary>
        private sealed class InternalDisposableAction : IDisposable
        {
            #region Instance fields and properties

            /// <summary>
            ///     Indicates whether the current instance has been disposed.
            ///     When true, the object's resources have been released and it should no longer be used.
            /// </summary>
            private bool _disposed;

            /// <summary>
            ///     Represents an action that will be executed when the object is disposed.
            ///     This action is stored and called within the Dispose method of the
            ///     InternalDisposableAction class, ensuring that any necessary cleanup or finalization logic
            ///     is executed when the object goes out of scope.
            /// </summary>
            private readonly Action _onDispose;

            #endregion

            #region Instance constructors and destructors

            /// <summary>
            ///     Initializes a new disposable action wrapper.
            /// </summary>
            /// <param name="onDispose">The action invoked when the instance is disposed.</param>
            public InternalDisposableAction(Action onDispose)
            {
                _onDispose = onDispose;
            }

            #endregion

            #region Instance methods

            #region From interface IDisposable

            /// <summary>
            ///     Releases all resources used by the InternalDisposableAction class.
            /// </summary>
            public void Dispose()
            {
                if (_disposed)
                {
                    return;
                }

                _disposed = true;
                _onDispose();
            }

            #endregion

            #endregion
        }

        #endregion
    }
}
