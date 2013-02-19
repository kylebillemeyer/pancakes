using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Extensibility
{
    /// <summary>
    /// Like an <see cref="IEngineComponent"/>, an engine manager provides some specialized functionality of the engine  
    /// by managing a registration of game components. Managers are pluggable and can be configured during engine initialization.
    /// </summary>
    /// <typeparam name="T">Each manager works for some "managed type" which an entity will inherit.</typeparam>
    public interface IEngineManager<T> : IEngineComponent
    {
        /// <summary>
        /// Register an entity with the manager, performing any initiallization logic needed for it.
        /// </summary>
        /// <typeparam name="T">The managed type which the entity will inherit from.</typeparam>
        void Register(T managedObject);

        /// <summary>
        /// Unregister an entity from the manager, performing any cleanup logic needed for it.
        /// </summary>
        /// <typeparam name="T">The managed type which the entity will inherit from.</typeparam>
        void Unregister(T managedObject);
    }
}
