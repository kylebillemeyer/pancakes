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

namespace OrneryBirdz
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BalloonsGame : PancakesGame
    {
        private static readonly float BALLOON_RADIUS = PhysicsConstants.PixelsToMeters(30);
        private static readonly float BALLOON_OFFSET = PhysicsConstants.PixelsToMeters(5);

        public BalloonsGame()
            : base(800, 480)
        {
        }

        protected override void Init(IContainer container)
        {
            var balloons = Enumerable.Range(0, 10)
                .SelectMany(i => Enumerable.Range(0, 5)
                    .Select(j =>
                    {
                        var newBalloon = container.Resolve<Balloon>();
                        newBalloon.Position = new Vector2(
                            i * (BALLOON_RADIUS + BALLOON_OFFSET), 
                            j * (BALLOON_RADIUS + BALLOON_OFFSET));
                        RegisterEntity(container, newBalloon);
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
    }
}
