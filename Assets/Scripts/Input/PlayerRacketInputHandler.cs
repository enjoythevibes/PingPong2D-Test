using System.Collections;
using System.Collections.Generic;
using PingPong.Event;
using PingPong.Racket;
using UnityEngine;

namespace PingPong.Input
{
    public class PlayerRacketInputHandler : MonoBehaviour
    {
        [SerializeField] private RacketMovementAbstract _racketMovement = default;
        [SerializeField] private StartGameEvent _startGameEvent = default;
        private IPlayerRacketInput _playerInput;

        #if UNITY_ANDROID && UNITY_EDITOR
        [SerializeField] private bool _pcInputForTest = true;
        #endif

        private void Awake()
        {
            SetInput();
            DisableInput();
            _startGameEvent.AddListener(EnableInput);
        }

        private void SetInput()
        {
#if UNITY_ANDROID && UNITY_EDITOR
            if (_pcInputForTest)
            {
                SetPCInput();
            }
            else
            {
                SetAndroidInput();
            }
            return;
#endif
#if UNITY_ANDROID
#if UNITY_ANDROID && !UNITY_EDITOR
            SetAndroidInput();
#endif
#else
            SetPCInput();
#endif
        }
#if UNITY_ANDROID
        private void SetAndroidInput()
        {
            _playerInput = gameObject.AddComponent<PlayerRacketInputAndroid>();
        }
#endif
#if UNITY_EDITOR || !UNITY_ANDROID
        private void SetPCInput()
        {
            _playerInput = gameObject.AddComponent<PlayerRacketInputPC>();
        }
#endif
        private void EnableInput()
        {
            enabled = true;            
        }

        private void DisableInput()
        {
            enabled = false;
        }

        private void FixedUpdate()
        {
            var direction = _playerInput.GetPlayerInputDirection();
            _racketMovement.Move(direction);
        }
    }
}