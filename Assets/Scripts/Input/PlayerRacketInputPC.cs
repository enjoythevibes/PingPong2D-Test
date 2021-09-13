using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.Input
{
    public class PlayerRacketInputPC : MonoBehaviour, IPlayerRacketInput
    {
        public int GetPlayerInputDirection()
        {
            var directionVector = Vector3.zero;
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                directionVector = Vector3.left;
            }
            else
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                directionVector = Vector3.right;

            }
            return (int)directionVector.x;
        }
    }
}