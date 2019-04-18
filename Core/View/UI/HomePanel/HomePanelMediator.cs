using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePanelMediator : Mediator {
    [Inject]
    public HomePanelView homePanelView { get; set; }

    public override void OnRegister()
    {
        homePanelView.init();
    }

}
