using System.Collections;
using System.Collections.Generic;
using PingPong.Player;
using PingPong.UI;
using PingPong.UI.Windows;
using UnityEngine;

namespace PingPong.Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private UIControllerAbstract _windowsController = default;

        private void Awake()
        {
            _windowsController.OpenUIElement<MenuWindow>();
        }

        private void Start()
        {
            Destroy(gameObject);
        }
    }
}