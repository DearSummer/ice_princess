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
    public enum characterInfo { idle = 0 , action = 1, attack = 2, jump = 3, injured = 4, death = 5 };
    public characterInfo _characterInfo = characterInfo.action;
    public enum actionInfo { walk = 0, Run = 1, SprintRun = 3, RunJump = 5 };
    public actionInfo _actionInfo = actionInfo.walk;
    public enum sprintInfo { enter = 0,over =2}
    public sprintInfo _sprintInfo = sprintInfo.over;
    public bool _isFirstInit = false;
    //用来调整专门的奔跑动画
    public Vector3 _adjustVector = Vector3.zero;
}