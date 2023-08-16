using System;
using System.Collections.Generic;

namespace QFrameworkTest
{
    public interface IArchitecture
    {
        void RegisterSystem<T>(T obj) where T : class, ISystem;

        void RegisterModel<T>(T obj) where T : class, IModel;

        void RegisterUtility<T>(T obj) where T : class;

        T GetModel<T>() where T : class, IModel;

        T GetUtility<T>() where T : class;
    }
    
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        private static IOCContainer container = new();
        private static T game;    // architecture

        private static bool isInited = false;
        private static List<IModel> needInitModels = new();
        private static List<ISystem> needInitSystems = new();

        public static Action<T> onRegisterPatch = null;

        protected abstract void Init();

        private static void MakeSureIOCContainer()
        {
            if (game == null)
            {
                game = new T();
                game.Init();
                
                onRegisterPatch?.Invoke(game);

                foreach (var model in needInitModels)
                {
                    model.Init();
                }
                needInitModels.Clear();

                foreach (var system in needInitSystems)
                {
                    system.Init();
                }
                needInitSystems.Clear();
                
                isInited = true;
            }
        }

        public static T Get<T>() where T : class
        {
            MakeSureIOCContainer();

            return container?.Get<T>();
        }

        protected void Register<T>(T obj) where T : class
        {
            MakeSureIOCContainer();
            
            container?.Register<T>(obj);
        }

        public void RegisterSystem<T>(T obj) where T : class, ISystem
        {
            obj.architecture = this;
            container?.Register<T>(obj);
            needInitSystems?.Add(obj);
        }

        public void RegisterModel<T>(T obj) where T : class, IModel
        {
            obj.architecture = this;
            container?.Register<T>(obj);
            needInitModels?.Add(obj);
        }

        public void RegisterUtility<T>(T obj) where T : class
        {
            container?.Register<T>(obj);
        }

        public T GetModel<T>() where T : class, IModel
        {
            return container?.Get<T>();
        }

        public T GetUtility<T>() where T : class
        {
            return container?.Get<T>();
        }
    }
}