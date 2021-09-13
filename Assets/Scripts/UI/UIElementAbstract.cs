using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.UI
{
    public abstract class UIElementAbstract : MonoBehaviour
    {
        protected UIControllerAbstract _uiController;

        public virtual void Init(UIControllerAbstract uiController)
        {
            _uiController = uiController;
        }

        public virtual void Close()
        {
            _uiController.CloseUIElement(this);
        }
    }
}