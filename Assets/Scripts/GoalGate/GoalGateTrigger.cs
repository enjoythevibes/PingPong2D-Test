using System;
using System.Collections;
using System.Collections.Generic;
using PingPong.Ball;
using PingPong.Event;
using PingPong.Utils.EventSystem;
using UnityEngine;

namespace PingPong.GoalGate
{
    public class GoalGateTrigger : GoalGateTriggerAbstract
    {
        public override event Action OnGoal;
        [SerializeField] private RestartSessionEvent _restartSessionEvent = default;

        private async void OnTriggerEnter2D(Collider2D other)
        {
            await Utils.Timer.Wait(1f);
            _restartSessionEvent.Call();
            OnGoal?.Invoke();
        }
    }
}