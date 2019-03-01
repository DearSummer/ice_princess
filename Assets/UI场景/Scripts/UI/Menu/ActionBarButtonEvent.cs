using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI.Menu
{
    public class ActionBarButtonEvent : MonoBehaviour
    {
        public void OnPlayerButtonClick()
        {
            MessageDispatcher.Instance.DispatchMessage(ProjectConstant.MessageBlock.MENU_MSG, this,
                new MenuMessage(ActionType.ActionBar, MenuString.SHOW_PLAYER_CONTENT));
        }

        public void OnSkillButtonClick()
        {
            MessageDispatcher.Instance.DispatchMessage(ProjectConstant.MessageBlock.MENU_MSG, this,
                new MenuMessage(ActionType.ActionBar, MenuString.SHOW_SKILL_CONTENT));
        }

        public void OnBagButtonClick()
        {
            MessageDispatcher.Instance.DispatchMessage(ProjectConstant.MessageBlock.MENU_MSG, this,
                new MenuMessage(ActionType.ActionBar, MenuString.SHOW_BAG_CONTENT));
        }

        public void OnSystemButtonClick()
        {
            MessageDispatcher.Instance.DispatchMessage(ProjectConstant.MessageBlock.MENU_MSG, this,
                new MenuMessage(ActionType.ActionBar, MenuString.SHOW_SYS_CONTENT));
        }
    }
}
