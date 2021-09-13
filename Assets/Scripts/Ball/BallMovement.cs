using System.Collections;
using System.Collections.Generic;
using PingPong.BallGenerator;
using PingPong.BounceSurface;
using PingPong.Event;
using UnityEngine;

namespace PingPong.Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private RestartSessionEvent _restartSessionEvent = default;
        [SerializeField] private BallSpeedGeneratorAbstract _ballSpeedGenerator = default;
        [SerializeField] private StartGameEvent _startGameEvent = default;
        private float _movementSpeed;
        private Rigidbody2D _rigidbody;
        private Vector2 _movementDirection;
        private Vector2 _defaultPosition;

        private const float WAIT_BEFORE_MOVE = 1f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _defaultPosition = transform.position;
            _restartSessionEvent.AddListener(Restart);
            _startGameEvent.AddListener(Restart);
        }

        private void Restart()
        {
            _rigidbody.velocity = Vector2.zero;
            transform.position = _defaultPosition;
            _movementSpeed = _ballSpeedGenerator.GetGeneratedBallSpeed();
            StartRandomMove();
        }

        private async void StartRandomMove()
        {
            await Utils.Timer.Wait(WAIT_BEFORE_MOVE);

            var randomX = Random.Range(-1f, 1f);
            var randomY = Random.Range(-1f, 1f);
            var startMovementVector = new Vector2(randomX, randomY).normalized * _movementSpeed;       
            SetVelocity(startMovementVector);     
        }

        private void SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
            _movementDirection = _rigidbody.velocity;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IBounceSurface>(out var bounceSurfaceComponent))
            {
                var newVelocity = bounceSurfaceComponent.GetReflectedVelocity(_movementDirection, other.contacts[0].point).normalized * _movementSpeed;
                SetVelocity(newVelocity);
            }
            else
            {
                Debug.LogError($"{other.gameObject.name} has not BounceSurface component");
            }
        }

        private void OnDestroy()
        {
            _restartSessionEvent.RemoveListener(Restart);
        }
    }
}