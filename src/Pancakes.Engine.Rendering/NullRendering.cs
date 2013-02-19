using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Pancakes.Engine.Caching;

namespace Pancakes.Engine.Rendering
{
    /// <summary>
    /// A blank rendering used by entities who have no rendering.  Automatically set to render to RenderLayer.NoRender.
    /// </summary>
    public class NullRendering : IRendering
    {
        public NullRendering()
        {
            RenderLayer = RenderLayer.NoRender;  // keeps these renderings from affecting sort time.
        }

        public RenderLayer RenderLayer { get; set; }
        public float DepthWithinLayer { get; set; }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }

        /// <summary>
        /// Does not draw anything.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="cache"></param>
        /// <param name="transform"></param>
        public void Draw(SpriteBatch spriteBatch, IResourceCache<Texture2D> cache, Matrix transform)
        {
        }
    }
}
