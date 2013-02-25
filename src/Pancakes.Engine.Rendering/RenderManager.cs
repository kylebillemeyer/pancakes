using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Pancakes.Engine.Caching;
using Microsoft.Xna.Framework;
using Pancakes.Engine.Utilities;
using Pancakes.Engine.Extensibility;

namespace Pancakes.Engine.Rendering
{
    /// <summary>
    /// A manager which provides the ability to draw to the screen.
    /// </summary>
    public class RenderManager : IEngineManager<IRenderable>
    {
        private IResourceCache<Texture2D> textureCache;
        private HashSet<IRenderable> renderables = new HashSet<IRenderable>();

        public RenderManager(IResourceCache<Texture2D> textureCache)
        {
            this.textureCache = textureCache;
        }

        /// <summary>
        /// Register the renderable allowing it to be drawn each frame.
        /// </summary>
        /// <param name="renderable">The renderable to be drawn.</param>
        /// <returns></returns>
        public void Register(IRenderable renderable)
        {
            renderables.Add(renderable);
        }

        /// <summary>
        /// Unregister the renderable, thus preventing it from being drawn each frame.
        /// </summary>
        /// <param name="renderable"></param>
        /// <returns></returns>
        public void Unregister(IRenderable renderable)
        {
            renderables.Remove(renderable);
        }

        /// <summary>
        /// The render manager does nothing during update.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Draw each registered renderable.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to draw to.</param>
        /// <param name="camera">The camera which will be used to set the parent transformation 
        /// for each non-UI rendering.</param>
        /// <remarks>
        /// Each rendering provided by each renderable will be grouped by render layer.  Within each
        /// render layer, the renderings will be sorted in depth order (furthest into the screen are
        /// drawn first).  Each render layer will be drawn in the following order: Background, MidgroundBack,
        /// Gameground, MidgroundFront and UI (NoRender is not drawn).  Background and Gameground will
        /// have parrallax scrolling applied to the camera transform and UI will not use the camera 
        /// transform at all.
        /// </remarks>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            var comparer = new RenderComparer();
            var sets = new Dictionary<RenderLayer, List<IRendering>>();
            sets.Add(RenderLayer.Background, new List<IRendering>());
            sets.Add(RenderLayer.MidgroundBack, new List<IRendering>());
            sets.Add(RenderLayer.Gameground, new List<IRendering>());
            sets.Add(RenderLayer.MidgroundFront, new List<IRendering>());
            sets.Add(RenderLayer.Foreground, new List<IRendering>());
            sets.Add(RenderLayer.UI, new List<IRendering>());

            foreach (var renderable in renderables)
            {
                renderable.Renderings.ForEach(
                    x => sets[x.RenderLayer].Add(x));
            }

            foreach (var layerSetPair in sets)
            {
                var set = layerSetPair.Value;
                set.Sort(comparer);
                foreach (var rendering in set)
                {
                    var t = camera.Transform;
                    t.Translation *= getDepthScale(layerSetPair.Key);
                    rendering.Draw(spriteBatch, textureCache, t);
                }
            }
        }

        /// <summary>
        /// Resets the manager by clearing all registered renderables.
        /// </summary>
        public void Reset()
        {
            renderables.Clear();
        }

        /// <summary>
        /// Helper function which determines the scale factor for parrallax
        /// scrolling on a per layer basis.
        /// </summary>
        /// <param name="layer">The layer to determine the scale factor for.</param>
        /// <returns>A floating point scale factor.</returns>
        private float getDepthScale(RenderLayer layer)
        {
            switch (layer)
            {
                case RenderLayer.Background:
                    return .6f;
                default:
                    return 1;
            }
        }
    }
}
