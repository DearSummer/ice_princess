using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInfo
{
    public static PlayInfo instance;
    public static PlayInfo Instance
    {
        get
        {
            if (null == instance)
                instance = new PlayInfo();
            return instance;
        }
        set { }
    }
    public enum characterInfo { action =0,attack = 1,jump = 2,injured = 3, death =4 };
    public characterInfo _characterInfo = characterInfo.action;
    public enum actionInfo { walk = 0, Run = 1,BackRun =2,SprintRun =3,RunForwardExit =4,RunJump =5 };
    public actionInfo _actionInfo = actionInfo.walk;
    public bool _isFirstInit = false;
    public bool _isFirstDoubleRun = false;

}
