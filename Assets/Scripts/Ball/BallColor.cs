using System.Collections;
using System.Collections.Generic;
using PingPong.Event;
using PingPong.Player;
using PingPong.SharedVariable;
using PingPong.UI.Windows;
using UnityEngine;

namespace PingPong.Ball
{
    public class BallColor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer = default;
        [SerializeField] private Color32Variable _color32Variable = default;
        [SerializeField] private PlayerDataLoaderAbstract<PlayerData> _playerDataLoader = default;

        private void Awake()
        {
            _color32Variable.Value = _playerDataLoader.PlayerData.BallColor.Value;
            _color32Variable.OnValueChanged += SetColor;
            SetColor();
        }

        private void SetColor()
        {
            _spriteRenderer.color = _color32Variable.Value;
        }

        private void OnDestroy()
        {
            _color32Variable.OnValueChanged -= SetColor;
        }
    }
}