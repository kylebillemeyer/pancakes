using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Pancakes.Engine.Caching;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Pancakes.Engine.Rendering
{
    /// <summary>
    /// Provides all basic rendering capabilities such as transformations and tinting.
    /// </summary>
    public class BasicRendering : IRendering
    {
        #region fields

        protected Rectangle? destRectangle;

        #endregion

        #region properties

        /// <summary>
        /// Specifies the <see cref="RenderLayer"/> to draw on.
        /// </summary>
        public RenderLayer RenderLayer { get; set; }

        /// <summary>
        /// The texture cache lookup key for the rendering to draw.
        /// </summary>
        public String TextureKey { get; set; }

        /// <summary>
        /// The position of the rendering relative to its parent.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The rotation of the rendering (in radians) relative to its parent.
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// The scale of the rendering relative to its parent.
        /// </summary>
        public Vector2 Scale { get; set; }  

        /// <summary>
        /// A subset of the texture can be drawn by setting the bounds of a rectangle within that texture.
        /// </summary>
        public Rectangle? SrcRectangle { get; set; }

        /// <summary>
        /// Can specify a tint to render with.
        /// </summary>
        public Color TintColor { get; set; }

        /// <summary>
        /// Specifies the relative depth between this rendering and its rendering layer.
        /// </summary>
        public float DepthWithinLayer { get; set; }

        #endregion

        /// <summary>
        /// All properties of a BasicRendering are optional except for the texture cache.  They will be
        /// set to default values with this constructor.  Use object initialization to override defaults succinctly.
        /// </summary>
        /// <param name="textureKey">The texture cache key for the texture to be rendered.</param>
        public BasicRendering(string textureKey)
        {
            this.TextureKey = textureKey;
            this.Position = Vector2.Zero;
            this.Rotation = 0.0f;
            this.Scale = Vector2.One;
            this.RenderLayer = Rendering.RenderLayer.Gameground;
            this.DepthWithinLayer = 0;
            this.TintColor = Color.White;
        }

        /// <summary>
        /// Draws to the specified spritebatch using the configured render properties.
        /// </summary>
        /// <param name="spriteBatch">The spritebtch to draw to.</param>
        /// <param name="cache">The texture cache provided as a convenience.</param>
        /// <param name="globalTransform">The transform of the rendering's parent.</param>
        public virtual void Draw(SpriteBatch spriteBatch, IResourceCache<Texture2D> cache, Matrix globalTransform)
        {
            var texture = cache.GetResource(TextureKey);

            Vector2 origin;
            if (SrcRectangle.HasValue)
                origin = new Vector2(SrcRectangle.Value.Width / 2, SrcRectangle.Value.Height / 2);
            else
                origin = new Vector2(texture.Width / 2, texture.Height / 2);

            spriteBatch.Begin(
                SpriteSortMode.BackToFront,
                BlendState.AlphaBlend,
                null,
                null,
                RasterizerState.CullNone,
                null,
                globalTransform);

            spriteBatch.Draw(
                texture,
                Position,
                SrcRectangle,
                TintColor,
                Rotation,
                origin,
                Scale,
                SpriteEffects.None,
                0
            );

            spriteBatch.End();
        }
    }
}
