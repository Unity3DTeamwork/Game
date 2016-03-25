using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isOver = false;

    private Image image;

    void Start()
    {
          this.image = this.GetComponentInChildren<Image>();
    }
    void Update()
    {
        if (isOver)
        {
            this.image.enabled = true;
        }
        else
        {
            this.image.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    { 
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
        isOver = false;
    }
}
