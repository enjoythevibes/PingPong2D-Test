using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.BounceSurface
{
    public interface IBounceSurface
    {
        Vector2 GetReflectedVelocity(Vector2 currentVelocity, Vector2 collisionPosition);
    }
}