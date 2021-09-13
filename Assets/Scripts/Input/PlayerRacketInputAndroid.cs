using System.Collections;
using System.Collections.Generic;
using PingPong.Input;
using UnityEngine;

public class PlayerRacketInputAndroid : MonoBehaviour, IPlayerRacketInput
{
    private Vector2 _lastTouchPosition;
    private float _xTouchVelocity;

    public int GetPlayerInputDirection()
    {
        var direction = 0;
        if (UnityEngine.Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                var currentTouchPosition = Input.GetTouch(0).position;
                _lastTouchPosition = currentTouchPosition;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                var currentTouchPosition = Input.GetTouch(0).position;
                var deltaPosition = (currentTouchPosition - _lastTouchPosition);
                if (deltaPosition.x > 0)
                {
                    direction = 1;
                }
                else
                if (deltaPosition.x < 0)
                {
                    direction = -1;
                }
                _lastTouchPosition = currentTouchPosition;
            }
        }
        return direction;
    }
}
