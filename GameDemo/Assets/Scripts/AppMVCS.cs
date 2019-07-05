using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;

public class AppMVCS : RootMono
{
    private UIFacade[] facades;

    private InputController inputController_;
    private PlayerModel playerModel_;
    private MobModel mobModel_;

    void Awake()
    {
#if UNITY_EDITOR
        Log.level = Log.LogLevel.DEBUG;
#else
        Log.level = Log.LogLevel.INFO;
#endif
        Debug.Log("---------------  Awake ------------------------");
        Transform facadeContainer = this.transform.Find("facades");
        facades = new UIFacade[facadeContainer.childCount];
        for (int i = 0; i < facadeContainer.childCount; i++)
        {
            Transform child = facadeContainer.GetChild(i);
            facades[i] = child.GetComponent<UIFacade>();
            facades[i].Register();
        }

        initialize();

        playerModel_ = new PlayerModel();
        PlayerView playerView = new PlayerView();
        PlayerController playerController = new PlayerController();
        framework.modelCenter.Register(PlayerModel.NAME, playerModel_);
        framework.viewCenter.Register(PlayerView.NAME, playerView);
        framework.controllerCenter.Register(PlayerController.NAME, playerController);

        mobModel_ = new MobModel();
        MobView mobView = new MobView();
        MobController mobController = new MobController();
        framework.modelCenter.Register(MobModel.NAME, mobModel_);
        framework.viewCenter.Register(MobView.NAME, mobView);
        framework.controllerCenter.Register(MobController.NAME, mobController);

        inputController_ = new InputController();
        framework.controllerCenter.Register(InputController.NAME, inputController_);
    }

    void OnEnable()
    {
        Debug.Log("---------------  OnEnable ------------------------");
        setup();
    }

    void Start()
    {
        Debug.Log("---------------  Start ------------------------");

        mobModel_.LinkStatus(PlayerModel.NAME, playerModel_);
        mobModel_.ReadData();
    }

    void Update()
    {
        inputController_.Update();
    }

    void OnDisable()
    {
        Debug.Log("---------------  OnDisable ------------------------");
        dismantle();
    }

    void OnDestroy()
    {
        Debug.Log("---------------  OnDestroy ------------------------");

        framework.modelCenter.Cancel(PlayerModel.NAME);
        framework.viewCenter.Cancel(PlayerView.NAME);
        framework.controllerCenter.Cancel(PlayerController.NAME);
        framework.controllerCenter.Cancel(InputController.NAME);
        //framework.serviceCenter.Cancel(SampleService.NAME);

        foreach (UIFacade facade in facades)
            facade.Cancel();

        release();
    }
}