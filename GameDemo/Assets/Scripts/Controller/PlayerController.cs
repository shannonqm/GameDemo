using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;

public class PlayerController : Controller
{
    public const string NAME = "PlayerController";

    protected override void setup()
    {
    }

    protected override void dismantle()
    {
    }

    private PlayerView view
    {
        get
        {
            return viewCenter_.FindView(PlayerView.NAME) as PlayerView;
        }
    }

    public void Move(PlayerModel.PlayerStatus _status)
    {
        Vector3 speed = Vector3.zero;
        speed.x = _status.direction.x;
        speed.z = _status.direction.y;
        speed = speed * _status.speed * Time.deltaTime;
        view.RefreshPosition(_status, speed);
    }
}