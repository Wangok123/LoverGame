using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeToBeach : View,IPointerClickHandler
{
    public Signal clickSignal = new Signal();

    public void OnPointerClick(PointerEventData eventData)
    {
        clickSignal.Dispatch();
    }
}
