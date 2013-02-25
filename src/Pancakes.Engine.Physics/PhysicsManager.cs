using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.DebugViews;
using Autofac;
using FarseerPhysics.Collision.Shapes;

using Pancakes.Engine.Extensibility;

namespace Pancakes.Engine.Physics
{
    /// <summary>
    /// A manager providing 2D physics by interfacing with Farseer (.NET Box2D port).
    /// </summary>
    public class PhysicsManager : IEngineManager<IPhysicsEnabledBody>
    {
        public World World { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engineRegistrations"></param>
        public PhysicsManager()
        {
            World = new World(PhysicsConstants.Gravity);
        }

        /// <summary>
        /// Registers the given entity, initializing its physics.
        /// </summary>
        /// <param name="managedBody">The entity to register.</param>
        public void Register(IPhysicsEnabledBody managedBody)
        {
            managedBody.InitializePhysics(false);
        }

        /// <summary>
        /// Unregisters the given entity, cleaning up its physics.
        /// </summary>
        /// <param name="managedBody">The entity to unregister.</param>
        public void Unregister(IPhysicsEnabledBody managedBody)
        {
            managedBody.DestroyPhysics();
        }

        /// <summary>
        /// Steps the Farseer world, simulating physics since the last tick.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            World.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        /// <summary>
        /// When enabled, draws a debug view of the phyics objects using a Farseer tool.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //@do: add debug view logic in here.
        }

        /// <summary>
        /// Reset the manager by creating a new world.
        /// </summary>
        public void Reset()
        {
            World = new World(PhysicsConstants.Gravity);
        }
    }
}
