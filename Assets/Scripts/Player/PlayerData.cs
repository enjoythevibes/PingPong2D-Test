using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PingPong.SerializableData;
using UnityEngine;

namespace PingPong.Player
{
    [System.Serializable]
    public class PlayerData
    {
        private Color32Serializable _ballColor;
        public Color32Serializable BallColor
        {
            set => _ballColor = value;
            get => _ballColor;
        }

        public void SetDefault()
        {
            BallColor = new Color32Serializable(Color.white);
        }
    }
}
