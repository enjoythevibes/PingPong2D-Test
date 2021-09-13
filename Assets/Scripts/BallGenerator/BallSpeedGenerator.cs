using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.BallGenerator
{
    [CreateAssetMenu(fileName = "BallSpeedGenerator", menuName = "Data/BallGenerator/BallSpeedGenerator", order = 0)]
    public class BallSpeedGenerator : BallSpeedGeneratorAbstract
    {
        [SerializeField] private float _minRandomSpeed = 3f;
        [SerializeField] private float _maxRandomSpeed = 15f;

        public override float GetGeneratedBallSpeed()
        {
            var randomSpeed = Random.Range(_minRandomSpeed, _maxRandomSpeed);
            return randomSpeed;
        }
    }
}