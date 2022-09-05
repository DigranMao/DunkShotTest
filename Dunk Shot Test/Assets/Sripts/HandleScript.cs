using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Interface interfacePlay;

    public void OnPointerDown(PointerEventData eventDataDown)
    {
        
    }

    public void OnPointerUp(PointerEventData eventDataUp)
    {
        interfacePlay.ingame = true;
    }

    
}
