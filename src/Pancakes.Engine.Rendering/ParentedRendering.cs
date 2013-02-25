using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Pancakes.Engine.Caching;
using Pancakes.Engine.Utilities;

namespace Pancakes.Engine.Rendering
{
    /// <summary>
    /// Creates a parent rendering which supplies its transformation to each child rendering.
    /// </summary>
    public class ParentedRendering : IRendering
    {
        /// <summary>
        /// Creates a parented rendering given a parent and its children.
        /// </summary>
        /// <param name="parent">The parent rendering.</param>
        /// <param name="children">The children of the parent.</param>
        public ParentedRendering(IRendering parent, Stack<IRendering> children)
        {
            Parent = parent;
            Children = children;
            RenderLayer = RenderLayer.Gameground;
        }

        /// <summary>
        /// The parent rendering.
        /// </summary>
        public IRendering Parent { get; set; }

        /// <summary>
        /// The children of the parent rendering.
        /// </summary>
        public Stack<IRendering> Children { get; set; }

        /// <summary>
        /// Specifies the RenderLayer to draw to.
        /// </summary>
        public RenderLayer RenderLayer { get; set; }

        /// <summary>
        /// Specifies the relative depth of the rendering within the RenderLayer.
        /// </summary>
        public float DepthWithinLayer { get; set; }

        /// <summary>
        /// Draws the parent rendering relative to the given tranform.  Then draws each child reltive to the parent.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to draw to.</param>
        /// <param name="cache">The texture cache given as a convenience.</param>
        /// <param name="transform">The aggregate transformation for the render stack thus far.</param>
        public void Draw(SpriteBatch spriteBatch, IResourceCache<Texture2D> cache, Matrix transform)
        {
            Parent.Draw(spriteBatch, cache, transform);

            var relativeTransform =
                Matrix.CreateScale(new Vector3(Parent.Scale, 1)) *
                Matrix.CreateRotationZ(Parent.Rotation) *
                Matrix.CreateTranslation(new Vector3(Parent.Position, 0)) *
                transform;

            Children.ForEach(x => x.Draw(spriteBatch, cache, relativeTransform));
        }

        /// <summary>
        /// The position of the rendering relative to its parent.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return Parent.Position;
            }
            set
            {
                throw new InvalidOperationException("Can't set the position of a parented rendering");
            }
        }

        /// <summary>
        /// The rotation of the rendering (in radians) relative to its parent.
        /// </summary>
        public float Rotation
        {
            get
            {
                return Parent.Rotation;
            }
            set
            {
                throw new InvalidOperationException("Can't set the rotation of a parented rendering");
            }
        }

        /// <summary>
        /// The scale of the rendering relative to its parent.
        /// </summary>
        public Vector2 Scale
        {
            get
            {
                return Parent.Scale;
            }
            set
            {
                throw new InvalidOperationException("Can't set the scale of a parented rendering");
            }
        }
    }
}
