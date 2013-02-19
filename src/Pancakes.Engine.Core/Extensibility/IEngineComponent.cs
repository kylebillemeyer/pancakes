using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Extensibility
{
    /// <summary>
    /// An engine component performs some specialized functionality for the engine.
    /// Components are pluggable and can be configured during engine initialization.
    /// </summary>
    public interface IEngineComponent
    {
        /// <summary>
        /// Perform component update logic on each game tick.
        /// </summary>
        void Update(GameTime gameTime);

        /// <summary>
        /// Preform component drawing logic on each game tick.
        /// </summary>
        /// <param name="spriteBatch">The spriteBatch to draw to.</param>
        /// <param name="camera">The camera storing the global transformation.</param>
        void Draw(SpriteBatch spriteBatch, Camera camera);

        /// <summary>
        /// Reset the component, performing any necessary cleanup.
        /// </summary>
        void Reset();
    }
}
