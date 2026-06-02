#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides the base implementation for builders that render paired HTML tags.
    /// </summary>
    /// <typeparam name="TBuilder">The concrete builder type used for fluent chaining.</typeparam>
    public abstract class HtmlTagBuilder<TBuilder> : HtmlBuilderBase<TBuilder>, IDisposable
        where TBuilder : HtmlTagBuilder<TBuilder>
    {
        #region Instance fields and properties

        /// <summary>
        ///     Tracks whether <see cref="Begin" /> has already written the opening tag.
        /// </summary>
        protected bool _started;

        /// <summary>
        ///     Gets the Razor HTML helper associated with this builder.
        /// </summary>
        public IHtmlHelper HtmlHelper => _htmlHelper;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new paired-tag builder.
        /// </summary>
        /// <param name="writer">The writer used by immediate rendering APIs.</param>
        /// <param name="html">The current Razor HTML helper.</param>
        protected HtmlTagBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
        }

        #endregion

        #region Instance methods

        #region Shared layout API

        /// <summary>
        ///     Ensures that the element has an identifier and returns it through an output parameter.
        /// </summary>
        /// <param name="id">Receives the existing or generated identifier.</param>
        /// <param name="prefix">The prefix used when generating a new identifier.</param>
        /// <returns>The current builder instance for chaining.</returns>
        public TBuilder WithAutoId(out string id, string prefix = "tag")
        {
            string? existingId = GetAttributeValue("id");

            if (string.IsNullOrWhiteSpace(existingId))
            {
                id = _htmlHelper.GenerateUniqueId(prefix);
                SetAttribute("id", id);
            }
            else
            {
                id = existingId;
            }

            return This();
        }

        #endregion

        #endregion

        #region Rendering

        /// <summary>
        ///     Writes the opening tag to the configured writer and starts a disposable rendering scope.
        /// </summary>
        /// <returns>The current builder instance for chaining and <c>using</c> scopes.</returns>
        public virtual TBuilder Begin()
        {
            if (_started)
            {
                return This();
            }

            DebugStart();
            _started = true;
            OnBeginRendering();
            ValidateTagName();
            _textWriter.Write($"<{_tag}{BuildAttributes()}>");

            return This();
        }

        /// <summary>
        ///     Writes the closing tag when the builder has been started.
        /// </summary>
        public virtual void End()
        {
            if (!_started)
            {
                return;
            }

            ValidateTagName();
            _textWriter.Write($"</{_tag}>");
            _started = false;
            OnEndRendering();
            DebugEnd();
        }

        /// <summary>
        ///     Ends the active rendering scope.
        /// </summary>
        public void Dispose()
        {
            End();
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateTagName();
            writer.Write($"<{_tag}{BuildAttributes()}>");
            writer.Write($"</{_tag}>");
        }

        /// <summary>
        ///     Runs immediately before the opening tag is written.
        /// </summary>
        protected virtual void OnBeginRendering()
        {
        }

        /// <summary>
        ///     Runs immediately after the closing tag is written.
        /// </summary>
        protected virtual void OnEndRendering()
        {
        }

        #endregion

        #region Protected helpers

        /// <summary>
        ///     Writes a debug comment before the element in debug builds.
        /// </summary>
        [Conditional("DEBUG")]
        protected void DebugStart()
        {
            #if DEBUG
            string name = GetType().Name.Replace("Builder", "", StringComparison.Ordinal);
            _textWriter.Write($"<!-- Debug : {HtmlCommentTextEncoder.Encode(name)} start -->");
            #endif
        }

        /// <summary>
        ///     Writes a debug comment after the element in debug builds.
        /// </summary>
        [Conditional("DEBUG")]
        protected void DebugEnd()
        {
            #if DEBUG
            string name = GetType().Name.Replace("Builder", "", StringComparison.Ordinal);
            _textWriter.Write($"<!-- Debug : {HtmlCommentTextEncoder.Encode(name)} end -->");
            #endif
        }

        #endregion
    }
}
