using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Rendering
{
    /// <summary>
    ///  Provides functionality for comparing depth values.
    /// </summary>
    public class RenderComparer : IComparer<IRendering>
    {
        /// <summary>
        /// Compare two renderings by their DepthWithinLayer values. 
        /// </summary>
        /// <param name="x">First rendering to compare.</param>
        /// <param name="y">Second rendering to compare.</param>
        /// <returns>-1 if x is further, 1 if closer, otherwise 0 
        /// (we want far things to be in the front of the enumeraton)</returns>
        public int Compare(IRendering x, IRendering y)
        {
            if (x.DepthWithinLayer < y.DepthWithinLayer)
                return 1;
            else if (x.DepthWithinLayer > y.DepthWithinLayer)
                return -1;
            else
                return 0;
        }
    }
}
