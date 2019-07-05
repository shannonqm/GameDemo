using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;
using LitJson;

public class MobModel : AgentModel
{
    public const string NAME = "MobModel";

    public class MobAgent : AgentModel.Agent
    {

    }

    private MobController controller
    {
        get
        {
            return controllerCenter_.FindController(MobController.NAME) as MobController;
        }
    }

    protected override void setup()
    {
        base.setup();
    }

    public void ReadData()
    {
        string path = Application.streamingAssetsPath + "/mobs.txt";
        string json = File.ReadAllText(path);
        Log.Debug("MobModel", "{0}", json);

        List<MobAgent> agents = new List<MobAgent>();
        agents = JsonMapper.ToObject<List<MobAgent>>(json);
        Log.Debug("MobModel", "has {0} mobs", agents.Count);
        status.agents.AddRange(agents);

        controller.Preload(status);
    }

}