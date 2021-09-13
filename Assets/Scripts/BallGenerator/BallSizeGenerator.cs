using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.BallGenerator
{
    [CreateAssetMenu(fileName = "BallSizeGenerator", menuName = "Data/BallGenerator/BallSizeGenerator", order = 0)]
    public class BallSizeGenerator : BallSizeGeneratorAbstract
    {
        [SerializeField] private float _minBallSize = 0.15f;
        [SerializeField] private float _maxBallSize = 1f;

        public override float GetGeneratedBallSize()
        {
            var randomBallSize = Random.Range(_minBallSize, _maxBallSize);
            return randomBallSize;
        }
    }
}