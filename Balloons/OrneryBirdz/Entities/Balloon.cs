using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Pancakes.Engine.Physics;
using Pancakes.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrneryBirdz.Entities
{
    public class Balloon : BalloonsEntity
    {
        public Balloon(World world)
            : base(world)
        {
        }

        public Balloon(World world, Vector2 position)
            :base(world)
        {
            this.Position = position;
        }

        public int Radius { get; set; }

        public override void InitializePhysics(bool force)
        {
            Body = BodyFactory.CreateCircle(
                World, 
                Radius, 
                1, 
                PhysicsConstants.PixelsToMeters(Position));
            Body.BodyType = BodyType.Dynamic;
        }

        public override List<IRendering> Renderings
        {
            get
            {
                return new List<IRendering>()
                {
                    new BasicRendering("balloon")
                    {
                        Position = PhysicsConstants.MetersToPixels(this.Position)
                    }
                };
            }
        }
    }
}
