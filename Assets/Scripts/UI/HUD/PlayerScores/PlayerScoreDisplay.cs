using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PingPong.Player;
using System;
using PingPong.SharedVariable;

namespace PingPong.UI.GameUI
{
    public class PlayerScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreFieldText = default;
        [SerializeField] private IntVariable _playerScoreVariable = default;

        private void Awake()
        {
            _playerScoreVariable.OnValueChanged += OnScoreChanged;
        }

        private void Start()
        {
            OnScoreChanged();
        }

        private void OnScoreChanged()
        {
            _scoreFieldText.text = _playerScoreVariable.Value.ToString();
        }

        private void OnDestroy()
        {
            _playerScoreVariable.OnValueChanged -= OnScoreChanged;
        }
    }
}