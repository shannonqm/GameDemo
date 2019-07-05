using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;

public class PlayerView : View
{
    public const string NAME = "PlayerView";

    public PlayerSpace spacePlayer
    {
        get
        {
            return (UIFacade.Find(PlayerFacade.NAME) as PlayerFacade).spacePlayer;
        }
    }

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

    public void RefreshPosition(PlayerModel.PlayerStatus _status, Vector3 _speed)
    {
        spacePlayer.cc.Move(_speed);
    }
}