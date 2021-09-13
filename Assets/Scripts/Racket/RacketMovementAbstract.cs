using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.Racket
{
    public abstract class RacketMovementAbstract : MonoBehaviour
    {
        public abstract void Move(float direction);
    }
}