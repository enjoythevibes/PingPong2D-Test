using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.GoalGate
{
    public abstract class GoalGateTriggerAbstract : MonoBehaviour
    {
        public abstract event Action OnGoal;
    }
}