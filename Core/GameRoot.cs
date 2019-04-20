using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRoot : ContextView
{
    
    
    private static GameRoot _instance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Init();    
    }

    void Init()
    {
        this.context = new GameContext(this);
    }
}
