﻿using System.Collections;

using System.Collections.Generic;

using UnityEngine;

namespace FairySpring.UI
{
    public class Fade : MonoBehaviour
    {
        private float UI_Alpha = 1.0f; //初始化时让UI显示
        public float alphaSpeed = 2f; //渐隐渐显的速度
        private CanvasGroup canvasGroup;

        // Use this for initialization
        void Start()
        {
            canvasGroup = this.GetComponent<CanvasGroup>();
            if (this.CompareTag("UiGroup_Two") || this.CompareTag("SkillCanvas"))
            {
                UI_FadeOut_Event();
            }
        }

        void Update()
        {
            if (canvasGroup == null)
            {
                return;
            }

            if (UI_Alpha != canvasGroup.alpha)
            {
                canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, UI_Alpha, alphaSpeed * Time.deltaTime);
                if (Mathf.Abs(UI_Alpha - canvasGroup.alpha) <= 0.01f)

                {
                    canvasGroup.alpha = UI_Alpha;
                }
            }
        }

        public void UI_FadeIn_Event()

        {

            UI_Alpha = 1;
            canvasGroup.blocksRaycasts = true; //可以和该对象交互

        }

        public void UI_FadeOut_Event()
        {
            UI_Alpha = 0;
            canvasGroup.blocksRaycasts = false; //不可以和该对象交互

        }
    }
}