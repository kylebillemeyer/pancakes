using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Pancakes.Engine.Physics;
using Pancakes.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrneryBirdz.Entities
{
    public class Bird : BalloonsEntity
    {
        public Bird(World world)
            : base(world)
        {
        }

        public override void InitializePhysics(bool force)
        {
            Body = BodyFactory.CreateCircle(
                World, 
                1, 
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
                    new BasicRendering("dart")
                    {
                        Position = PhysicsConstants.MetersToPixels(this.Position),
                        Rotation = (float)Math.Atan2(Body.LinearVelocity.Y, Body.LinearVelocity.X)
                    }
                };
            }
        }
    }
}
