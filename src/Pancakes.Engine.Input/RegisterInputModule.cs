using Autofac;
using Autofac.Util;
using Pancakes.Engine.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Input
{
    public class RegisterInputModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InputManager>().AsSelf().As<IEngineComponent>().SingleInstance();
        }
    }
}
