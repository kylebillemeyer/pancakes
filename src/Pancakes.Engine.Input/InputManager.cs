using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pancakes.Engine;
using Microsoft.Xna.Framework.Graphics;
using Pancakes.Engine.Extensibility;

namespace Pancakes.Engine.Input
{
    /// <summary>
    /// A manager for handling user input. Currently, it only supports keyboard and mouse input
    /// but future releases will include game pads.
    /// </summary>
    public class InputManager : IEngineComponent
    {
        public InputManager() 
        {
            Controller = new InputController();
        }

        public InputController Controller { get; set; }

        /// <summary>
        /// Updates the input controller which in turn tracks the current state 
        /// of all input devices for this tick and the last.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            Controller.Update(gameTime);
        }

        /// <summary>
        /// When enabled, draws a realtime visualization of input.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //@do: add debug drawings
        }

        /// <summary>
        /// Resets the manager by clearing internal registrations.
        /// </summary>
        public void Reset()
        {
        }
    }
}
