using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.UI
{
    using UnityEngine;
    
    public abstract class UIControllerAbstract : ScriptableObject
    {
        public abstract void Init(RectTransform uiControllerHolder);
        public abstract T OpenUIElement<T>(string uiElementName = null) where T : UIElementAbstract;
        public abstract void CloseUIElement(UIElementAbstract uiElement);
    }
}