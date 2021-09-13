using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.SharedVariable
{
    using System;
    using UnityEngine;

    // [CreateAssetMenu(fileName = "VariableAbstract", menuName = "Data/SharedVariable/VariableAbstract", order = 0)]
    public abstract class VariableAbstract<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] protected T _initialValue = default;
        private T _value;
        public T Value
        {
            set
            {
                _value = value;
                OnValueChanged?.Invoke();
            }
            get
            {
                return _value;
            }
        }
        public event Action OnValueChanged;

        public void ForceOnValueChange()
        {
            OnValueChanged?.Invoke();
        }

        public void OnAfterDeserialize()
        {
            Value = _initialValue;
        }

        public void OnBeforeSerialize()
        {
        }
    }
}