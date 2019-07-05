using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XTC.MVCS;
using XTC.Types;
using XTC.Logger;

public class InputController : Controller
{
    public const string NAME = "InputController";

    private Vector2 direction = Vector2.zero;
    private PlayerModel modelPlayer { get; set; }

    protected override void setup()
    {
        modelPlayer = modelCenter_.FindModel(PlayerModel.NAME) as PlayerModel;
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

    public void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        modelPlayer.UpdatePosition(direction);
    }

    
}