using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;

public class MobView : View
{
    public const string NAME = "MobView";

    protected override void setup()
    {
    }

    protected override void bindEvents()
    {
    }

    protected override void unbindEvents()
    {
    }

    protected override void dismantle()
    {
    }

    public void Preload(MobModel.AgentStatus _status)
    {
        foreach(MobModel.Agent agent in _status.agents)
        {
            Debug.Log("sdsdsd");
            GameObject obj = new GameObject();
            obj.name = "121212";
            //MobAI ai = obj.AddComponent<MobAI>();
            // ai.SetUp(agent)

            PlayerModel.PlayerStatus playerStatus = _status.Access(PlayerModel.NAME) as PlayerModel.PlayerStatus;
            Debug.Log(playerStatus.direction);
        }
    }
}