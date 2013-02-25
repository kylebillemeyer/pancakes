using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Pancakes.Engine.Physics;
using Pancakes.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Pancakes.Engine.Caching;
using Microsoft.Xna.Framework.Graphics;

namespace OrneryBirdz.Entities
{
    public class Dart : BalloonsEntity
    {
        private const string TEXTURE = "Textures/dart";
        private Vector2 scale;
        private IResourceCache<Texture2D> textureCache;

        public Dart(World world, IResourceCache<Texture2D> texCache)
            : base(world)
        {
            textureCache = texCache;
        }

        public override void InitializePhysics(bool force)
        {
            Body = BodyFactory.CreateCircle(
                World, 
                Size.X, 
                Size.Y * .8f, 
                Position);
            Body.BodyType = BodyType.Dynamic;
        }

        public override List<IRendering> Renderings
        {
            get
            {
                var tex = textureCache.GetResource(TEXTURE);
                return new List<IRendering>()
                {
                    new BasicRendering(TEXTURE)
                    {
                        Position = PhysicsConstants.MetersToPixels(this.Position),
                        Rotation = (float)Math.Atan2(Body.LinearVelocity.Y, Body.LinearVelocity.X),
                        Scale = new Vector2(
                            PhysicsConstants.MetersToPixels(Size.X / tex.Width), 
                            PhysicsConstants.MetersToPixels(Size.Y / tex.Height))
                    }
                };
            }
        }
    }
}
