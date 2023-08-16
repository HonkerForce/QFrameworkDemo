using System;
using System.Collections;
using System.Collections.Generic;

namespace QFrameworkTest
{
    public class IOCContainer
    {
        private Dictionary<Type, object> container = new();

        public T Get<T>() where T : class
        {
            var objType = typeof(T);
            if (container.TryGetValue(objType, out var obj))
            {
                return obj as T;
            }

            return null;
        }

        public void Register<T>(T obj) where T : class
        {
            var objType = typeof(T);
            container?.Add(objType, obj);
        }
    }
}
