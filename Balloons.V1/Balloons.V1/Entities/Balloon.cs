using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Pancakes.Engine.Physics;
using Pancakes.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pancakes.Engine.Caching;
using Microsoft.Xna.Framework.Graphics;

namespace OrneryBirdz.Entities
{
    public class Balloon : BalloonsEntity
    {
        private const string TEXTURE = "Textures/balloon";
        private IResourceCache<Texture2D> textureCache;

        public Balloon(World world, IResourceCache<Texture2D> texCache)
            : base(world)
        {
            textureCache = texCache;
        }

        public Balloon(World world, Vector2 position)
            :base(world)
        {
            this.Position = position;
        }

        public float Radius { get; set; }

        public override void InitializePhysics(bool force)
        {
            Body = BodyFactory.CreateCircle(
                World, 
                Radius, 
                1, 
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
                        Scale = new Vector2(
                            PhysicsConstants.MetersToPixels(Size.X / tex.Width), 
                            PhysicsConstants.MetersToPixels(Size.Y / tex.Height))
                    }
                };
            }
        }
    }
}
