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
    public class SkillContentButtonEvent : MonoBehaviour, IMessageCallback
    {
        void Start()
        {
            MessageDispatcher.Instance.AddMessageHandler(ProjectConstant.MessageBlock.MENU_MSG, this);
            this.gameObject.SetActive(false);
        }

        void OnDestroy()
        {
            MessageDispatcher.Instance.RemoveMessageHandler(ProjectConstant.MessageBlock.MENU_MSG, this);
        }

        public void ReciveMessage(object sender, object param)
        {
            if (!(param is MenuMessage))
                return;

            MenuMessage message = (MenuMessage) param;
            if (message.actionType != ActionType.ActionBar)
                return;


            if (message.message.Equals(MenuString.SHOW_SKILL_CONTENT))
            {
                if (!this.gameObject.activeInHierarchy)
                    this.gameObject.SetActive(true);
            }
            else if (
                !message.message.Equals(MenuString.SHOW_SKILL_CONTENT))
            {
                if (this.gameObject.activeInHierarchy)
                    this.gameObject.SetActive(false);
            }
        }

    }
}
