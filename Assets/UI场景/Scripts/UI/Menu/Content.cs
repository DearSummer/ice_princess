using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
 
 
//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Content : MonoBehaviour, IMessageCallback
    {

        private CanvasGroup canvasGroup;

        // Use this for initialization
        protected virtual void Start ()
        {
            canvasGroup = GetComponent<CanvasGroup>();            
            MessageDispatcher.Instance.AddMessageHandler(ProjectConstant.MessageBlock.MENU_MSG,this);

            this.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            MessageDispatcher.Instance.RemoveMessageHandler(ProjectConstant.MessageBlock.MENU_MSG, this);
        }

        public void SetActive(bool active)
        {
            if (active && !this.gameObject.activeInHierarchy)
            {
                canvasGroup.alpha = 1;
                this.gameObject.SetActive(true);
            }
            else
            {
                if (this.gameObject.activeInHierarchy)
                    StartCoroutine(DisableGameObject());
            }
        }


        private IEnumerator DisableGameObject()
        {
            canvasGroup.DOFade(0, 0.5f);
            yield return new WaitForSeconds(0.5f);

            this.gameObject.SetActive(false);
        }

        public void ReciveMessage(object sender, object param)
        {
            if(!(param is MenuMessage))
                return;

            OnMessageRecive((MenuMessage) param);
        }


        protected virtual void OnMessageRecive(MenuMessage menuMessage)
        {
        }
    }
}
