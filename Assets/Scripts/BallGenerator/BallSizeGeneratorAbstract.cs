using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.BallGenerator
{
    // [CreateAssetMenu(fileName = "BallGenerator", menuName = "Data/BallGenerator", order = 0)]
    public abstract class BallSizeGeneratorAbstract : ScriptableObject
    {
        public abstract float GetGeneratedBallSize();
    }
}
