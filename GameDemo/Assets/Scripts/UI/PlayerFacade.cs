using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XTC.MVCS;

[System.Serializable]
public class PlayerUI
{

}

[System.Serializable]
public class PlayerSpace
{
    public CharacterController cc;
}

public class PlayerFacade : UIFacade
{
    public const string NAME = "PlayerFacade";
    public PlayerUI uiPlayer;
    public PlayerSpace spacePlayer;
}