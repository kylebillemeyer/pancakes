using Autofac;
using Autofac.Util;
using Pancakes.Engine.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Physics
{
    public class RegisterPhysicsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var physicsManager = new PhysicsManager();
            builder.RegisterInstance(physicsManager).AsSelf().As<IEngineComponent>();
            builder.RegisterInstance(physicsManager.World).AsSelf();
        }
    }
}
