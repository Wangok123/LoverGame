using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRoot : ContextView
{
    public Text text;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        this.context = new GameContext(this);        
    }
}
