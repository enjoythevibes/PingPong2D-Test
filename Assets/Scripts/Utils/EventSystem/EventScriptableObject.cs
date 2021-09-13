using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.Utils.EventSystem
{
    public abstract class EventScriptableObject : ScriptableObject
    {
        private event Action _listeners;

        public void AddListener(Action action)
        {
            _listeners += action;
        }

        public void RemoveListener(Action action)
        {
            _listeners -= action;
        }

        public void Call()
        {
            _listeners?.Invoke();
        }
    }
}
