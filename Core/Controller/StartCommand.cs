using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCommand : Command {

    private string path;
    public Signal<string> startSignal = new Signal<string>();

    public override void Execute()
    {
        LoadScene();
        
    }

    private void LoadScene()
    {
#if UNITY_ANDROID
        SceneManager.LoadScene("LoadScene");
#elif UNITY_EDITOR
        SceneManager.LoadScene(Resources.Load("Scenes/LoadScene").name);
        Debug.Log("sss");
#endif
    }
}
