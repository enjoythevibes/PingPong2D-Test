using System;
using System.Collections;
using System.Collections.Generic;
using PingPong.Player;
using PingPong.SharedVariable;
using UnityEngine;
using UnityEngine.UI;

namespace PingPong.UI.Windows.ColorPicker
{
    public class ColorPickerWindow : UIElementAbstract
    {
        [SerializeField] private HSVPicker.ColorPicker _colorPicker = default;
        [SerializeField] private Color32Variable _sharedBallColor = default;
        [SerializeField] private Button _backButton = default;
        [SerializeField] private Button _saveButton = default;
        [SerializeField] private PlayerDataLoaderAbstract<PlayerData> _playerDataLoader = default;
        
        private Action _onCloseAction;

        private void Awake()
        {
            _backButton.onClick.AddListener(OnBackButton);
            _saveButton.onClick.AddListener(OnSaveButton);
            _saveButton.gameObject.SetActive(false);
        }

        public void Init(Action onCloseAction)
        {
            _onCloseAction = onCloseAction;
            _colorPicker.CurrentColor = _sharedBallColor.Value;
            _colorPicker.onValueChanged.AddListener(value =>
            {
                _sharedBallColor.Value = value;
                if (_sharedBallColor.Value != value)
                {
                    if (_saveButton.gameObject.activeSelf == false)
                    {
                        _saveButton.gameObject.SetActive(true);
                    }
                }
            });
        }

        private void OnSaveButton()
        {
            _playerDataLoader.PlayerData.BallColor.Value = _colorPicker.CurrentColor;
            _playerDataLoader.SaveData();
            OnBackButton();
        }

        private void OnBackButton()
        {
            _sharedBallColor.Value = _playerDataLoader.PlayerData.BallColor.Value;
            _onCloseAction?.Invoke();
            Close();
        }
    }
}