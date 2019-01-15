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
    public enum actionInfo { walk = 0, Run = 1 };
    public actionInfo _actionInfo = actionInfo.walk;

}
