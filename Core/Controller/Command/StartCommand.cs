using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCommand : Command {
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }
    [Inject]
    public ChangeSceneSignal changeSceneSignal { get; set; }

    public override void Execute()
    {
        changeSceneSignal.Dispatch("LoadScene");
    }

}
