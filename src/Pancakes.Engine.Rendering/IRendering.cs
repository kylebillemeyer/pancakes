using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Pancakes.Engine.Caching;
using Microsoft.Xna.Framework;

namespace Pancakes.Engine.Rendering
{
    /// <summary>
    /// Inheritors of this interface can draw to the screen.
    /// </summary>
    public interface IRendering
    {
        /// <summary>
        /// Specifies the logical grouping the rendering will be apart of.
        /// </summary>
        RenderLayer RenderLayer { get; set; }

        /// <summary>
        /// XNA only supports painters algorithm across sprite batches.  Therefore, it is necessary to 
        /// do a depth sort for each render layer using this float.  A positive value is further from the
        /// camera and a negative value is closer to the camera.
        /// </summary>
        float DepthWithinLayer { get; set; }

        /// <summary>
        /// The postion (in pixels) of the rendering relative to its parent (usually the parent is the world aka (0, 0)). 
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// The rotation (in radians) of the rendering relative to its parent (usually the parent is the world aka 0 radians). 
        /// </summary>
        float Rotation { get; set; }

        /// <summary>
        /// The scale of the rendering relative to its parent (usually the parent is the world aka 1 x size). 
        /// </summary>
        Vector2 Scale { get; set; }

        /// <summary>
        /// Draws to a specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw to.</param>
        /// <param name="cache">Given as a convenience rather than have every rendering take in the cache in its constructor.</param>
        /// <param name="transform">A composition of transformation matrices representing the parent of the rendering.  
        /// In most cases this will simply be the camera.</param>
        void Draw(SpriteBatch spriteBatch, IResourceCache<Texture2D> cache, Matrix transform);
    }
}
