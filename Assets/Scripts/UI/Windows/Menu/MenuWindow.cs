using System.Collections;
using System.Collections.Generic;
using PingPong.Event;
using PingPong.UI.HUD;
using PingPong.UI.Windows.ColorPicker;
using UnityEngine;
using UnityEngine.UI;

namespace PingPong.UI.Windows
{
    public class MenuWindow : UIElementAbstract
    {
        [SerializeField] private Button _startGameButton = default;
        [SerializeField] private Button _ballColorPickGameButton = default;
        [SerializeField] private StartGameEvent _startGameEvent = default;
        [SerializeField] private UIControllerAbstract _hudController = default;
        [SerializeField] private UIControllerAbstract _windowsController = default;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(OnStartGameButton);
            _ballColorPickGameButton.onClick.AddListener(OnBallColorPickGameButton);
        }

        private void OnStartGameButton()
        {
            _startGameEvent.Call();
            _hudController.OpenUIElement<PlayerScoresHUD>();
            Close();
        }

        private void OnBallColorPickGameButton()
        {
            var colorPickerWindow = _windowsController.OpenUIElement<ColorPickerWindow>();
            colorPickerWindow.Init(() =>
            {
                _uiController.OpenUIElement<MenuWindow>();
            });
            Close();
        }
    }
}