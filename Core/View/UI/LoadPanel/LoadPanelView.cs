using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadPanelView : View
{ 

    //显示进度的文本
    public Text progress;
    //进度条的数值
    public float progressValue;
    public Slider slider;
    public string nextSceneName;//加载下个场景的名字

    public void Init()
    {
#if UNITY_ANDROID
        nextSceneName = "Home";
#elif UNITY_EDITOR
        nextSceneName = "Scenes/Home";
#endif
    }
}
