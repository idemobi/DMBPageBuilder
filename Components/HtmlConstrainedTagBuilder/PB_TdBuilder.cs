#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBPageBuilder.csproj PB_TdBuilder.cs create at 2026/05/05 15:05:00
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>td</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_TdBuilder : HtmlConstrainedTagBuilder<PB_TdBuilder>
    {
        #region Instance fields and properties

        private int _colspan
        {
            get => GetInternal("_colspan", 0);
            set => SetInternal("_colspan", value);
        }

        private string? _headers
        {
            get => GetInternal<string?>("_headers", null);
            set => SetInternal("_headers", value);
        }

        private int _rowspan
        {
            get => GetInternal("_rowspan", 0);
            set => SetInternal("_rowspan", value);
        }

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.TableRow
            };

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.TableCell;

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_TdBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_TdBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "td";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        public override string BuildAttributes()
        {
            string? previousColspan = GetAttributeValue("colspan");
            string? previousRowspan = GetAttributeValue("rowspan");
            string? previousHeaders = GetAttributeValue("headers");

            try
            {
                if (_colspan > 0)
                {
                    _attributes["colspan"] = _colspan.ToString();
                }
                else
                {
                    _attributes.Remove("colspan");
                }

                if (_rowspan > 0)
                {
                    _attributes["rowspan"] = _rowspan.ToString();
                }
                else
                {
                    _attributes.Remove("rowspan");
                }

                if (!string.IsNullOrWhiteSpace(_headers))
                {
                    _attributes["headers"] = _headers;
                }
                else
                {
                    _attributes.Remove("headers");
                }

                return base.BuildAttributes();
            }
            finally
            {
                RestoreAttribute("colspan", previousColspan);
                RestoreAttribute("rowspan", previousRowspan);
                RestoreAttribute("headers", previousHeaders);
            }
        }

        /// <summary>
        ///     Clears the col span state.
        /// </summary>
        /// <returns>The current <see cref="PB_TdBuilder" /> instance for chaining.</returns>
        public PB_TdBuilder ClearColSpan()
        {
            _colspan = 0;
            return this;
        }

        /// <summary>
        ///     Clears the row span state.
        /// </summary>
        /// <returns>The current <see cref="PB_TdBuilder" /> instance for chaining.</returns>
        public PB_TdBuilder ClearRowSpan()
        {
            _rowspan = 0;
            return this;
        }

        /// <inheritdoc />
        protected override PB_TdBuilder CreateInstance()
        {
            return new PB_TdBuilder(_textWriter, _htmlHelper);
        }

        private void RestoreAttribute(string name, string? previousValue)
        {
            if (string.IsNullOrWhiteSpace(previousValue))
            {
                _attributes.Remove(name);
            }
            else
            {
                _attributes[name] = previousValue;
            }
        }

        /// <summary>
        ///     Sets the col span value.
        /// </summary>
        /// <param name="colspan">The value to assign to the HTML <c>colspan</c> attribute.</param>
        /// <returns>The current <see cref="PB_TdBuilder" /> instance for chaining.</returns>
        public PB_TdBuilder SetColSpan(int colspan)
        {
            if (colspan < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(colspan), colspan, "ColSpan must be greater than or equal to 1.");
            }

            _colspan = colspan;
            return this;
        }

        /// <summary>
        ///     Sets the HTML <c>headers</c> attribute.
        /// </summary>
        /// <param name="headers">The value to assign to the HTML <c>headers</c> attribute.</param>
        /// <returns>The current <see cref="PB_TdBuilder" /> instance for chaining.</returns>
        public PB_TdBuilder SetHeaders(string? headers)
        {
            _headers = string.IsNullOrWhiteSpace(headers) ? null : headers.Trim();
            return this;
        }

        /// <summary>
        ///     Sets the row span value.
        /// </summary>
        /// <param name="rowspan">The value to assign to the HTML <c>rowspan</c> attribute.</param>
        /// <returns>The current <see cref="PB_TdBuilder" /> instance for chaining.</returns>
        public PB_TdBuilder SetRowSpan(int rowspan)
        {
            if (rowspan < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rowspan), rowspan, "RowSpan must be greater than or equal to 1.");
            }

            _rowspan = rowspan;
            return this;
        }

        #endregion
    }
}