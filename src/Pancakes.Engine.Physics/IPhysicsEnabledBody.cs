using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Autofac;

namespace Pancakes.Engine.Physics
{
    /// <summary>
    /// An inheritor of this contract can be registered with the <see cref="PhysicsManager"/> 
    /// and establish its own physics using Farseer.
    /// </summary>
    public interface IPhysicsEnabledBody
    {
        /// <summary>
        /// Implementation should initialize any Farseer physics for the entity.
        /// </summary>
        /// <param name="force"></param>
        void InitializePhysics(bool force);
        void DestroyPhysics();
    }
}
