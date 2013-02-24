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
    public class Block : BalloonsEntity
    {
        public Block(World world)
            : base(world)
        {
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public override void InitializePhysics(bool force)
        {
            if (Width == 0 || Height == 0)
            {
                throw new InvalidOperationException(
                    "Block width and height must be set before physics initialization.");
            }

            Body = BodyFactory.CreateRectangle(
                World,
                Width,
                Height,
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
                    new BasicRendering("block")
                    {
                        Position = this.Position
                    }
                };
            }
        }
    }
}
