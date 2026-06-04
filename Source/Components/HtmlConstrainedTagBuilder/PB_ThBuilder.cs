#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Builds an HTML <c>th</c> element for PageBuilder Razor output.
    /// </summary>
    public sealed class PB_ThBuilder : HtmlConstrainedTagBuilder<PB_ThBuilder>
    {
        #region Instance fields and properties

        private string? _abbr
        {
            get => GetInternal<string?>("_abbr", null);
            set => SetInternal("_abbr", value);
        }

        private int _colspan
        {
            get => GetInternal("_colspan", 0);
            set => SetInternal("_colspan", value);
        }

        private int _rowspan
        {
            get => GetInternal("_rowspan", 0);
            set => SetInternal("_rowspan", value);
        }

        private string? _scope
        {
            get => GetInternal<string?>("_scope", null);
            set => SetInternal("_scope", value);
        }

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.TableRow
            };

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.TableHeaderCell;

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new <see cref="PB_ThBuilder" /> instance.
        /// </summary>
        /// <param name="writer">The output writer used by the builder.</param>
        /// <param name="html">The Razor HTML helper that owns the rendering context.</param>
        public PB_ThBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "th";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        public override string BuildAttributes()
        {
            string? previousColspan = GetAttributeValue("colspan");
            string? previousRowspan = GetAttributeValue("rowspan");
            string? previousScope = GetAttributeValue("scope");
            string? previousAbbr = GetAttributeValue("abbr");

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

                if (!string.IsNullOrWhiteSpace(_scope))
                {
                    _attributes["scope"] = _scope;
                }
                else
                {
                    _attributes.Remove("scope");
                }

                if (!string.IsNullOrWhiteSpace(_abbr))
                {
                    _attributes["abbr"] = _abbr;
                }
                else
                {
                    _attributes.Remove("abbr");
                }

                return base.BuildAttributes();
            }
            finally
            {
                RestoreAttribute("colspan", previousColspan);
                RestoreAttribute("rowspan", previousRowspan);
                RestoreAttribute("scope", previousScope);
                RestoreAttribute("abbr", previousAbbr);
            }
        }

        /// <summary>
        ///     Clears the col span state.
        /// </summary>
        /// <returns>The current <see cref="PB_ThBuilder" /> instance for chaining.</returns>
        public PB_ThBuilder ClearColSpan()
        {
            _colspan = 0;
            return this;
        }

        /// <summary>
        ///     Clears the row span state.
        /// </summary>
        /// <returns>The current <see cref="PB_ThBuilder" /> instance for chaining.</returns>
        public PB_ThBuilder ClearRowSpan()
        {
            _rowspan = 0;
            return this;
        }

        /// <inheritdoc />
        protected override PB_ThBuilder CreateInstance()
        {
            return new PB_ThBuilder(_textWriter, _htmlHelper);
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
        ///     Sets the HTML <c>abbr</c> attribute.
        /// </summary>
        /// <param name="abbr">The value to assign to the HTML <c>abbr</c> attribute.</param>
        /// <returns>The current <see cref="PB_ThBuilder" /> instance for chaining.</returns>
        public PB_ThBuilder SetAbbr(string? abbr)
        {
            _abbr = string.IsNullOrWhiteSpace(abbr) ? null : abbr.Trim();
            return this;
        }

        /// <summary>
        ///     Sets the col span value.
        /// </summary>
        /// <param name="colspan">The value to assign to the HTML <c>colspan</c> attribute.</param>
        /// <returns>The current <see cref="PB_ThBuilder" /> instance for chaining.</returns>
        public PB_ThBuilder SetColSpan(int colspan)
        {
            if (colspan < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(colspan), colspan, "ColSpan must be greater than or equal to 1.");
            }

            _colspan = colspan;
            return this;
        }

        /// <summary>
        ///     Sets the row span value.
        /// </summary>
        /// <param name="rowspan">The value to assign to the HTML <c>rowspan</c> attribute.</param>
        /// <returns>The current <see cref="PB_ThBuilder" /> instance for chaining.</returns>
        public PB_ThBuilder SetRowSpan(int rowspan)
        {
            if (rowspan < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rowspan), rowspan, "RowSpan must be greater than or equal to 1.");
            }

            _rowspan = rowspan;
            return this;
        }

        /// <summary>
        ///     Sets the HTML <c>scope</c> attribute.
        /// </summary>
        /// <param name="scope">The value to assign to the HTML <c>scope</c> attribute.</param>
        /// <returns>The current <see cref="PB_ThBuilder" /> instance for chaining.</returns>
        public PB_ThBuilder SetScope(string? scope)
        {
            _scope = string.IsNullOrWhiteSpace(scope) ? null : scope.Trim();
            return this;
        }

        #endregion
    }
}