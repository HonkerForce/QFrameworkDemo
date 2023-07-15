using System;
using QFramework;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace QFrameworkTest
{
    public class Event<T> where T : Event<T>
    {
        private static Action OnEventTrigger = null;

        public static void RegisterTrigger(Action OnTrigger)
        {
            OnEventTrigger += OnTrigger;
        }

        public static void UnRegisterTrigger(Action OnTrigger)
        {
            OnEventTrigger -= OnTrigger;
        }

        public static void Trigger()
        {
            OnEventTrigger?.Invoke();
        }
    }
}