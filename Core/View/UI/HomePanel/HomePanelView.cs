using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanelView : View {
    private const int HOME_PAGE = 0;
    private const int BEACH_PAGE = 1;

    public Signal changeToBeachSignal = new Signal();
    public Signal changeToRoomSignal = new Signal();
    public Sprite[] bgs;
    public Image background;
    public ChangeToBeach ctb;
    

    internal void init()
    {
        ctb.clickSignal.AddListener(ToBeachScene);
    }

    void ToBeachScene()
    {
        changeToBeachSignal.Dispatch();
        ChangeToBeachScene();
    }

    void ChangeToBeachScene()
    {
        background.sprite = bgs[BEACH_PAGE];
    }
}
