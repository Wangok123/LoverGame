using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : MVCSContext
{
    public GameContext(MonoBehaviour view) : base(view)
    {
    }

    public GameContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }

    public override IContext Start()
    {
        base.Start();
        StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        return this;
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {
        #region MediatorBind
        mediationBinder.Bind<LoadPanelView>().To<LoadPanelMediator>();
        mediationBinder.Bind<HomePanelView>().To<HomePanelMediator>();
        #endregion

        #region InjectionBind
        #endregion

        #region CommandBind
        commandBinder.Bind<ChangeSceneSignal>().To<ChangeSceneCommand>();
        #endregion


        commandBinder.Bind<StartSignal>().To<StartCommand>().Once();

        #region SignalBind
        #endregion
    }
}
