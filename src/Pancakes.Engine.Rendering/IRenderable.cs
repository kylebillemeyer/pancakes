using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Rendering
{
    /// <summary>
    /// Inheritors of this interface can add <see cref="IRendering"/> instances to the rendering queue.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Create a list of renderings to be drawn on screen.  This will be invoked
        /// each tick.
        /// </summary>
        List<IRendering> Renderings { get; }
    }
}
