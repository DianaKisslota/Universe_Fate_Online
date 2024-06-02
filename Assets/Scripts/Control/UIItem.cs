using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<bool> MouseOver;

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseOver?.Invoke(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOver?.Invoke(false);
    }

}
