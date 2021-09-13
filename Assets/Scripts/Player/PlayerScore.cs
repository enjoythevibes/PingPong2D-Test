using System;
using System.Collections;
using System.Collections.Generic;
using PingPong.GoalGate;
using PingPong.SharedVariable;
using UnityEngine;

namespace PingPong.Player
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private GoalGateTriggerAbstract _targetGoalGateTrigger = default;
        [SerializeField] private IntVariable _playerScoreVariable = default;

        private void Awake()
        {
            _targetGoalGateTrigger.OnGoal += OnGoal;
        }

        private void OnGoal()
        {
            _playerScoreVariable.Value += 1;
        }

        private void OnDestroy()
        {
            _targetGoalGateTrigger.OnGoal -= OnGoal;
        }
    }
}