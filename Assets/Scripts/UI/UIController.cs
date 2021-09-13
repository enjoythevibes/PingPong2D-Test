using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PingPong.UI
{
    [CreateAssetMenu(fileName = "UIController", menuName = "Data/UI/UIController", order = 0)]
    public class UIController : UIControllerAbstract
    {
        [SerializeField] private string _uiElementsPath = "UI/";
        private List<UIElementAbstract> _openedUIElements = new List<UIElementAbstract>();
        private RectTransform _uiControllerHolder;

        public override void Init(RectTransform uiControllerHolder)
        {
            _uiControllerHolder = uiControllerHolder;
        }

        public override T OpenUIElement<T>(string uiElementName = null)
        {
            if (string.IsNullOrEmpty(uiElementName))
            {
                uiElementName = typeof(T).Name;
            }
            var uiElementPath = _uiElementsPath + uiElementName;
            var uiElementPrefab = Resources.Load<UIElementAbstract>(uiElementPath);
            if (uiElementPrefab == null)
            {
                Debug.LogError($"{uiElementPath} cant find prefab by path");
                return default;
            }

            var uiElementIsntance = MonoBehaviour.Instantiate(uiElementPrefab, _uiControllerHolder);
            _openedUIElements.Add(uiElementIsntance);
            uiElementIsntance.Init(this);
            return uiElementIsntance as T;
        }

        public override void CloseUIElement(UIElementAbstract uiElement)
        {
            if (_openedUIElements.Contains(uiElement))
            {
                _openedUIElements.Remove(uiElement);
                MonoBehaviour.Destroy(uiElement.gameObject);
            }
            else
            {
                Debug.LogError($"{uiElement.GetType()} cant find opened ui element");
            }
        }
    }
}