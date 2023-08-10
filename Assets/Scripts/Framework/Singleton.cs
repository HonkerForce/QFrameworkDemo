using System;
using System.Reflection;

namespace QFrameworkTest
{
    public class Singleton<T> where T : Singleton<T>
    {
        protected static T instance;
        public static T Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                var t = typeof(T);
                var constructions = t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                var construct = Array.Find(constructions, c => c.GetParameters().Length == 0);

                if (construct == null)
                {
                    throw new Exception("Non Public Construction not fount in " + t.Name);
                }
                
                return instance = construct.Invoke(null) as T;
            }
        }
    }
}