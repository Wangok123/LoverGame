using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPanelMediator : Mediator {
    private const string NOTE_TEXT = "按任意键继续";
    private AsyncOperation async = null;

    [Inject]
    public LoadPanelView loadPanelView { get; set; }

    public override void OnRegister()
    {
        loadPanelView.Init();
        StartCoroutine("LoadScene");
    }

    public override void OnRemove()
    {
        StopCoroutine("LoadScene");
    }


    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync(loadPanelView.nextSceneName);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
                loadPanelView.progressValue = async.progress;
            else
                loadPanelView.progressValue = 1.0f;

            loadPanelView.slider.value = loadPanelView.progressValue;
            loadPanelView.progress.text = (int)(loadPanelView.slider.value * 100) + " %";

            if (loadPanelView.progressValue >= 0.9)
            {
                loadPanelView.progress.text = NOTE_TEXT;
                if (Input.anyKeyDown)
                {
                    async.allowSceneActivation = true;
                }
            }

            yield return null;
        }

    }

}
