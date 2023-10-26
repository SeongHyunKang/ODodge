using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rightTouchMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameControl.m_instance.move = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameControl.m_instance.move = 0;
    }    
}
