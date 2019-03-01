using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
//using FairySpring.Fight;
using UnityEngine;
using UnityEngine.UI;
//using FightingMessage = FairySpring.Fight.FightingMessage;


//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI.PlayerState
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PlayerStateManager : MonoBehaviour, IMessageCallback
    {

        private CanvasGroup canvasGroup;

        public HpSlider magicPointSlider;
        public HpSlider heathPointSlider;        


        // Use this for initialization
        void Start ()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            ShowPlayerState(false);

            MessageDispatcher.Instance.AddMessageHandler(ProjectConstant.MessageBlock.UI_MSG, this);
        }
        

        public void ReciveMessage(object sender, object param)
        {

            var uiMessgae = param as UIMessage;
            if (uiMessgae != null)
            {
                switch (uiMessgae.GetMessageId())
                {
                    case (byte)UiMessageId.HeathChange:
                        SetHeathPointValue(uiMessgae.GetValue<float>());
                        break;
                    case (byte)UiMessageId.HidePlayerState:
                        ShowPlayerState(false);
                        break;
                    case (byte)UiMessageId.MagicChange:
                        SetMagicPointValue(uiMessgae.GetValue<float>());
                        break;
                    case (byte)UiMessageId.ShowPlayerState:
                        ShowPlayerState(true);
                        break;
                }
            }

        }

        void OnDestroy()
        {
            MessageDispatcher.Instance.RemoveMessageHandler(ProjectConstant.MessageBlock.UI_MSG, this);
        }

        private void ShowPlayerState(bool isShow)
        {
            if (isShow)
            {
                canvasGroup.DOFade(1, 0.5f);
            }
            else
            {
                canvasGroup.DOFade(0, 0.5f);
            }
        }

        private void SetMagicPointValue(float value)
        {
            magicPointSlider.ChangeSliderValue(value);
        }


        private void SetHeathPointValue(float value)
        {
            heathPointSlider.ChangeSliderValue(value);
        }
    }
}
