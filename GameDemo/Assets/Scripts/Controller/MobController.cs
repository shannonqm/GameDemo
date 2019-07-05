using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;

public class MobController : Controller
{
    public const string NAME = "MobController";

    protected override void setup()
    {
    }

    protected override void dismantle()
    {
    }

    private MobView view
    {
        get
        {
            return viewCenter_.FindView(MobView.NAME) as MobView;
        }
    }

    public void Preload(MobModel.AgentStatus _status)
    {
        view.Preload(_status);
    }
}