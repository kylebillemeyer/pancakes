using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Pancakes.Engine.Rendering")]
namespace Pancakes.Engine.Input
{
    public class InputController
    {
        private KeyboardState lastState = Keyboard.GetState();
        private KeyboardState currentState = Keyboard.GetState();
        private MouseState lastMouseState = Mouse.GetState();
        private MouseState currentMouseState = Mouse.GetState();

        /// <summary>
        /// Tests if the given keyboard key is pressed and wasn't pressed last tick.
        /// </summary>
        /// <param name="key">The key to test.</param>
        /// <returns>True if the key is a new press, otherwise false.</returns>
        public bool IsNewKey(Keys key)
        {
            return currentState.IsKeyDown(key) && lastState.IsKeyUp(key);
        }

        /// <summary>
        /// Tests if the given keyboard key is currently pressed.
        /// </summary>
        /// <param name="key">The key to test.</param>
        /// <returns>True if the key is pressed, otherwise false.</returns>
        public bool IsPressed(Keys key)
        {
            return currentState.IsKeyDown(key);
        }

        /// <summary>
        /// Gets the state of the mouse this tick.
        /// </summary>
        public MouseState CurrentMouseState
        {
            get { return currentMouseState; }
        }

        /// <summary>
        /// Gets the state of the mouse last tick.
        /// </summary>
        public MouseState LastMoustState
        {
            get { return lastMouseState; }
        }

        /// <summary>
        /// Tracks the current state of all input devices for this tick and the last.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(GameTime gameTime)
        {
            lastState = currentState;
            currentState = Keyboard.GetState();

            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }
        
        /// <summary>
        /// Manually sets the player's mouse position to the specified point.
        /// </summary>
        /// <param name="point">Point to move the mouse to.</param>
        public static void ForceMousePosition(Vector2 point)
        {
            Mouse.SetPosition((int)point.X, (int)point.Y);
        }
    }
}
