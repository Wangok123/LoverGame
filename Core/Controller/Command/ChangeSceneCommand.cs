using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public class ChangeSceneCommand:Command
{
    [Inject]
    public string sceneName { get; set; }

    public override void Execute()
    {
        LoadScene();
    }

    private void LoadScene()
    {
#if UNITY_ANDROID
        SceneManager.LoadScene(sceneName);
#elif UNITY_EDITOR
        SceneManager.LoadScene(Resources.Load("Scenes/"+sceneName));
#endif
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene s, LoadSceneMode arg1)
    {
        switch (s.buildIndex)
        {
            case 1:
                UIManager.Instance.CreateUI<LoadPanelView>();
                break;
        }
    }
}

