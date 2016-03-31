using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private bool _isOver = false;

        private Image _image;

        private void Start()
        {
            this._image = this.GetComponentInChildren<Image>();
        }

        private void Update()
        {
            this._image.enabled = this._isOver;
        }

        public void OnPointerEnter(PointerEventData eventData)
        { 
            this._isOver = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
      
            this._isOver = false;
        }
    }
}
