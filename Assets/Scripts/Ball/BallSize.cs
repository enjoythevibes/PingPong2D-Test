using System.Collections;
using System.Collections.Generic;
using PingPong.BallGenerator;
using PingPong.Event;
using UnityEngine;

namespace PingPong.Ball
{
    public class BallSize : MonoBehaviour
    {
        [SerializeField] private RestartSessionEvent _restartSessionEvent = default;
        [SerializeField] private StartGameEvent _startGameEvent = default;
        [SerializeField] private BallSizeGeneratorAbstract _ballSizeGenerator = default;
        private float _radiusSize;

        private void Awake()
        {
            _restartSessionEvent.AddListener(SetSize);
            _startGameEvent.AddListener(SetSize);
        }

        private void SetSize()
        {
            _radiusSize = _ballSizeGenerator.GetGeneratedBallSize();
            transform.localScale = Vector3.one * _radiusSize;
        }

        private void OnDestroy()
        {
            _restartSessionEvent.RemoveListener(SetSize);
        }
    }
}