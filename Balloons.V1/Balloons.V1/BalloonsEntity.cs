using Pancakes.Engine;
using Pancakes.Engine.Physics;
using Pancakes.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;

namespace OrneryBirdz
{
    public abstract class BalloonsEntity : Entity, IPhysicsEnabledBody, IRenderable
    {
        public BalloonsEntity(World world)
        {
            this.World = world;
        }

        public World World { get; set; }

        public Body Body { get; set; }

        public bool Dead { get; set; }

        public Vector2 Size { get; set; }

        private Vector2 position;
        public virtual Vector2 Position
        {
            get
            {
                if (Body != null)
                    return Body.Position;
                return position;
            }
            set
            {
                position = value;
                if (Body != null)
                    Body.Position = position;
            }
        }

        public abstract void InitializePhysics(bool force);

        public virtual void DestroyPhysics()
        {
            Body.Dispose();
        }

        public abstract List<IRendering> Renderings { get; }
    }
}
