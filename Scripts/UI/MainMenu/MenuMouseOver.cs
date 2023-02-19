using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{

    public Image mouseOverImage;



    public void OnPointerEnter(PointerEventData eventData)
    {
        Color alpha = mouseOverImage.color;
        alpha.a = Constants.mouseOverAlpha;
        mouseOverImage.color = alpha;
        //Debug.Log("Mouse is over GameObject.");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color alpha = mouseOverImage.color;
        alpha.a = 0;
        mouseOverImage.color = alpha;
        //Debug.Log("Mouse is no longer on GameObject.");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Color alpha = mouseOverImage.color;
        alpha.a = 0;
        mouseOverImage.color = alpha;
        //Debug.Log("Mouse is no longer on GameObject.");
    }
}
