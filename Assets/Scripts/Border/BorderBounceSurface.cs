using System.Collections;
using System.Collections.Generic;
using PingPong.BounceSurface;
using UnityEngine;

namespace PingPong.Border
{
    public class BorderBounceSurface : MonoBehaviour, IBounceSurface
    {
        public Vector2 GetReflectedVelocity(Vector2 currentVelocity, Vector2 collisionPosition)
        {
            return Vector2.Reflect(currentVelocity, transform.right);
        }
    }
}