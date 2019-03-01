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
    public class SystemContentButtonEvent : MonoBehaviour, IMessageCallback
    {
        // Use this for initialization
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

            MenuMessage menuMessage = (MenuMessage)param;
            if (menuMessage.actionType != ActionType.ActionBar)
                return;
            this.gameObject.SetActive(menuMessage.message.Equals(MenuString.SHOW_SYS_CONTENT));
        }

        public void OnExitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            
        }
    }
}
