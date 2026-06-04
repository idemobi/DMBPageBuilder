#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilderUnitTest;

/// <summary>
///     Creates lightweight <see cref="IHtmlHelper" /> instances for PageBuilder unit tests.
/// </summary>
public static class TestHtmlHelperFactory
{
    #region Static methods

    /// <summary>
    ///     Creates an <see cref="IHtmlHelper" /> proxy for tests that only need a non-null helper instance.
    /// </summary>
    /// <returns>A test <see cref="IHtmlHelper" /> proxy.</returns>
    public static IHtmlHelper Create()
    {
        return DispatchProxy.Create<IHtmlHelper, TestHtmlHelperProxy>();
    }

    #endregion

    #region Nested type: TestHtmlHelperProxy

    /// <summary>
    ///     Test proxy used by <see cref="TestHtmlHelperFactory" />.
    /// </summary>
    public class TestHtmlHelperProxy : DispatchProxy
    {
        #region Instance methods

        /// <inheritdoc />
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            throw new NotSupportedException($"{targetMethod?.Name ?? "Unknown method"} is not supported by the test HTML helper.");
        }

        #endregion
    }

    #endregion
}
