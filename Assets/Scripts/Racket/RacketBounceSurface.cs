using System.Collections;
using System.Collections.Generic;
using PingPong.BounceSurface;
using UnityEngine;

namespace PingPong.Racket
{
    public class RacketBounceSurface : MonoBehaviour, IBounceSurface
    {
        private Vector3 _toLeftBoundPointVector;

        private void Awake()
        {
            var bounds = GetComponent<BoxCollider2D>().bounds;
            var leftBoundPoint = bounds.center - (transform.rotation * new Vector3(bounds.extents.x, 0f, 0f));
            _toLeftBoundPointVector = leftBoundPoint - transform.position;
        }

        public Vector2 GetReflectedVelocity(Vector2 currentVelocity, Vector2 collisionPosition)
        {
            var hitVector = collisionPosition - (Vector2)transform.position;
            var dotProductHitToLeftBoundPoint = Vector2.Dot(hitVector.normalized, _toLeftBoundPointVector.normalized);
            var absDotProductHitToLeftBoundPoint = Mathf.Abs(dotProductHitToLeftBoundPoint);
            var reflectAngle = 0f;
            if (dotProductHitToLeftBoundPoint > 0)
            {
                reflectAngle = Mathf.LerpAngle(0, 45f, absDotProductHitToLeftBoundPoint);
            }
            else
            {
                reflectAngle = Mathf.LerpAngle(0, -45f, absDotProductHitToLeftBoundPoint);
            }
            var reflectVector = Quaternion.Euler(0f, 0f, reflectAngle) * transform.up;
            return ((Vector2)reflectVector);
        }
    }
}