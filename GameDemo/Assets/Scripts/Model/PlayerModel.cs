using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;

public class PlayerModel : Model
{
    public const string NAME = "PlayerModel";

    public class PlayerStatus : Model.Status
    {
        public Vector2 direction = Vector2.zero;
        public float speed = 3.0f;
    }

    protected override void setup()
    {
        status_ = new PlayerStatus();
    }


    private PlayerController controller
    {
        get
        {
            return controllerCenter_.FindController(PlayerController.NAME) as PlayerController;
        }
    }

    private PlayerStatus status
    {
        get
        {
            return status_ as PlayerStatus;
        }
    }

    public void UpdatePosition(Vector2 _direction)
    {
        status.direction = _direction;
        controller.Move(status);
    }
}