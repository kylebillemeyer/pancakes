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
            builder.RegisterType<PhysicsManager>().AsSelf().As(typeof(IEngineManager<>)).SingleInstance();
        }
    }
}
