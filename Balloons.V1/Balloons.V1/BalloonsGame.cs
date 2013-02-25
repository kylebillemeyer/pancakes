using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Pancakes.Engine;
using Autofac;
using OrneryBirdz.Entities;
using Pancakes.Engine.Rendering;
using Pancakes.Engine.Physics;
using Pancakes.Engine.Utilities;

namespace OrneryBirdz
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BalloonsGame : PancakesGame
    {
        private static readonly float BALLOON_RADIUS = PhysicsConstants.PixelsToMeters(40);
        private static readonly float BALLOON_OFFSET = PhysicsConstants.PixelsToMeters(5);
        private static readonly float GLOBAL_OFFSET_X = PhysicsConstants.PixelsToMeters(-100);
        private static readonly float GLOBAL_OFFSET_Y = PhysicsConstants.PixelsToMeters(-150);
        private IEnumerable<Balloon> balloons;
        private Dart dart;

        public BalloonsGame()
            : base(1000, 600)
        {
        }

        protected override void Init(IContainer container)
        {
            dart = container.Resolve<Dart>();
            dart.Position = new Vector2(
                PhysicsConstants.PixelsToMeters(GraphicsDevice.Viewport.Width * -.4f), 
                PhysicsConstants.PixelsToMeters(GraphicsDevice.Viewport.Height * .4f));
            dart.Size = PhysicsConstants.PixelsToMeters(new Vector2(60, 20)); 

            var camera = container.Resolve<Camera>();
            camera.TranslateCamera(
                new Vector3(
                    GraphicsDevice.Viewport.Width / 2,
                    GraphicsDevice.Viewport.Height / 2, 0));

            balloons = Enumerable.Range(0, 10)
                .SelectMany(i => Enumerable.Range(0, 5)
                    .Select(j =>
                    {
                        var newBalloon = container.Resolve<Balloon>();
                        newBalloon.Position = new Vector2(
                            i * (BALLOON_RADIUS + BALLOON_OFFSET) + GLOBAL_OFFSET_X,
                            j * (BALLOON_RADIUS + BALLOON_OFFSET) + GLOBAL_OFFSET_Y);
                        newBalloon.Radius = BALLOON_RADIUS;
                        newBalloon.Size = PhysicsConstants.PixelsToMeters(new Vector2(40, 39));
                        return newBalloon;
                    }));
        }

        private void RegisterEntity(IContainer container, BalloonsEntity entity)
        {
            var renderManager = container.Resolve<RenderManager>();
            renderManager.Register(entity);

            var physicsManager = container.Resolve<PhysicsManager>();
            physicsManager.Register(entity);
        }

        protected override void OnUpdate(IContainer container, GameTime gameTime)
        {
            balloons.ForEach(x => RegisterEntity(container, x));
            RegisterEntity(container, dart);
        }
    }
}
