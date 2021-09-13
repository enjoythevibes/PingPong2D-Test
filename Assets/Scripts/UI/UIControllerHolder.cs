using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.UI
{
    public class UIControllerHolder : MonoBehaviour
    {
        [SerializeField] private UIControllerAbstract _uiController = default;

        private void Awake()
        {
            _uiController.Init(transform as RectTransform);
        }
    }
}