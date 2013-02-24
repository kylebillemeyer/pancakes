using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pancakes.Engine.Caching;
using Pancakes.Engine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Pancakes.Engine
{
    public abstract class PancakesGame : Game
    {
        private GraphicsDeviceManager graphics;
        private Camera camera;
        private InMemoryResourceCache<Texture2D> textureCache;
        private SpriteBatch spriteBatch;
        private ContainerBuilder builder;
        private IContainer container;

        public PancakesGame(int width, int height)
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;

            Content.RootDirectory = "Content";
        }

        protected sealed override void Initialize()
        {
            base.Initialize();

            camera = new Camera(Vector2.One, Vector3.Zero);
            builder.RegisterInstance(camera).AsSelf().SingleInstance();

            RegisterEngineParts(builder);

            container = builder.Build();

            LoadCustomContent(container);

            Init(container);
        }

        protected sealed override void LoadContent()
        {
            // instantiate the container
            builder = new ContainerBuilder();

            // setup caches            
            textureCache = new InMemoryResourceCache<Texture2D>(
                new ContentManagerProvider<Texture2D>(Content));
            builder.RegisterInstance(textureCache).As<IResourceCache<Texture2D>>();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            var blank = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });
            textureCache.AddResource("blank", blank);
        }

        protected sealed override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            OnUpdate(gameTime);
        }

        protected sealed override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            OnDraw(gameTime, spriteBatch);
        }

        protected virtual void Init(IContainer container) 
        { 
        }

        protected virtual void LoadCustomContent(IContainer container) 
        { 
        }

        protected virtual void OnUpdate(GameTime gameTime)
        {
        }

        protected virtual void OnDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        private void RegisterEngineParts(ContainerBuilder builder)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            RegisterAssembly(builder, executingAssembly);

            var loadedAssemblies = executingAssembly.GetReferencedAssemblies();
            loadedAssemblies.ForEach(x =>
                {
                    var assembly = Assembly.Load(x);
                    RegisterAssembly(builder, assembly);
                });
        }

        private void RegisterAssembly(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableFrom(typeof(Entity)))
                .AsSelf()
                .As<Entity>();
            builder.RegisterAssemblyModules(assembly);
        }

        //public virtual void LoadLevel(string levelName)
        //{
        //}

        //protected virtual void LevelLoaded()
        //{
        //    debugView = new DebugViewXNA(LevelManager.PhysicsManager.World);
        //    debugView.LoadContent(GraphicsDevice, Content);
        //}

        //public virtual void MarkAsLoadLevel(string levelPath, int spawnPoint) { }
    }
}
