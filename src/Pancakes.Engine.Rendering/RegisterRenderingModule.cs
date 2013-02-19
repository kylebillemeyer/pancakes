using Autofac;
using Autofac.Util;
using Pancakes.Engine.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Rendering
{
    public class RegisterRenderingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RenderManager>().AsSelf().As(typeof(IEngineManager<>)).SingleInstance();
        }
    }
}
