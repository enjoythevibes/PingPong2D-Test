using UnityEngine;

namespace PingPong.SerializableData
{
    [System.Serializable]
    public class Color32Serializable
    {
        private byte _r;
        private byte _g;
        private byte _b;
        private byte _a;

        public Color32 Value
        {
            get
            {
                return new Color32(_r, _g, _b, _a);
            }
            set
            {
                _r = value.r;
                _g = value.g;
                _b = value.b;
                _a = value.a;
            }
        }

        public Color32Serializable(Color32 value)
        {
            Value = value;
        }

        public Color32Serializable()
        {
        }
    }
}
