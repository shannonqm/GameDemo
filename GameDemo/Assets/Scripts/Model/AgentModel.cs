using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;

public class AgentModel : Model
{

    public class Agent
    {
        public string name = "";
    }

    public class AgentStatus : Model.Status
    {
        public List<Agent> agents = new List<Agent>(0);
    }

    protected override void setup()
    {
        status_ = new AgentStatus();
    }


    protected AgentStatus status
    {
        get
        {
            return status_ as AgentStatus;
        }
    }

}