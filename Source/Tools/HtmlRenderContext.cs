#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System;
using System.Collections.Generic;

namespace DMBPageBuilder
{
    /// <summary>
    ///     Describes the rendering constraints active for a nested HTML builder scope.
    /// </summary>
    public sealed class HtmlRenderContext
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets the maximum number of times each region can be rendered in this context.
        /// </summary>
        public Dictionary<HtmlRegionKind, int> AllowedRegions { get; } = new();

        /// <summary>
        ///     Gets contextual data shared by renderers while this context is active.
        /// </summary>
        public Dictionary<string, object?> Data { get; } = new();

        /// <summary>
        ///     Gets or sets the kind of rendering context.
        /// </summary>
        public HtmlRenderContextKind Kind { get; set; }

        /// <summary>
        ///     Gets or sets the object that opened this context.
        /// </summary>
        public object? Owner { get; set; }

        /// <summary>
        ///     Gets the number of times each region has been rendered in this context.
        /// </summary>
        public Dictionary<HtmlRegionKind, int> UsedRegions { get; } = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Determines whether the specified region can still be rendered in the current context.
        /// </summary>
        /// <param name="region">The region kind to check.</param>
        /// <returns><see langword="true" /> when the region is allowed; otherwise, <see langword="false" />.</returns>
        public bool IsRegionAllowed(HtmlRegionKind region)
        {
            if (!AllowedRegions.TryGetValue(region, out var maxCount))
            {
                return false;
            }

            if (maxCount < 0)
            {
                return true;
            }

            var used = UsedRegions.TryGetValue(region, out var usedCount) ? usedCount : 0;
            return used < maxCount;
        }

        /// <summary>
        ///     Records one usage of the specified region.
        /// </summary>
        /// <param name="region">The region kind that has been rendered.</param>
        public void RegisterRegionUse(HtmlRegionKind region)
        {
            if (!IsRegionAllowed(region))
            {
                Console.Error.WriteLine($"Region '{region}' is not allowed anymore in context '{Kind}'.");
            }

            if (!UsedRegions.ContainsKey(region))
            {
                UsedRegions[region] = 0;
            }

            UsedRegions[region]++;
        }

        #endregion
    }
}