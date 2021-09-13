using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.Racket
{
    public class RacketMovement : RacketMovementAbstract
    {
        [SerializeField] private float _movementSpeed = 700f;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();   
        }

        public override void Move(float direction)
        {
            _rigidbody.velocity = Vector3.right * direction * _movementSpeed * Time.deltaTime;
        }
    }
}