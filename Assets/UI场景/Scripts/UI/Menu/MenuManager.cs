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
    public class MenuManager : MonoBehaviour, IMessageCallback
    {
        private ActionBarButtonEvent actionBarButtonEvent;
        private bool isShow = true;
        // Use this for initialization
        void Start ()
        {
            MessageDispatcher.Instance.AddMessageHandler(ProjectConstant.MessageBlock.UI_MSG,this);
            actionBarButtonEvent = GetComponentInChildren<ActionBarButtonEvent>();
            SetMenuActive(true);
        }

        void OnDestroy()
        {
            MessageDispatcher.Instance.RemoveMessageHandler(ProjectConstant.MessageBlock.UI_MSG, this);
        }

        public void SetMenuActive(bool isActive)
        {
            this.gameObject.SetActive(isActive);
            isShow = isActive;
        }

        public void ReciveMessage(object sender, object param)
        {
            var uiMessgae = param as UIMessage;
            if (uiMessgae != null)
            {
                switch (uiMessgae.GetMessageId())
                {
                    case (byte)UiMessageId.ShowMenu:
                        isShow = !isShow;
                        SetMenuActive(isShow);
                        if (isShow)
                        {
                            actionBarButtonEvent.OnPlayerButtonClick();
                        }
                        break;

                }
            }
        }
    }
}
