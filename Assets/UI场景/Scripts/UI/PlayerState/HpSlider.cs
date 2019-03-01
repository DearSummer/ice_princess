using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI.PlayerState
{
    public class HpSlider : MonoBehaviour
    {
        private Slider hpSliderMain;
        private Slider hpSliderSecondary;


        void Start()
        {
            hpSliderMain = GetComponent<Slider>();
            Slider[] sliders = GetComponentsInChildren<Slider>();

            foreach (var slider in sliders)
            {
                if (slider != hpSliderMain)
                {
                    hpSliderSecondary = slider;
                }
            }
        }


        public void ChangeSliderValue(float value)
        {
            hpSliderMain.DOValue(value, 0.25f);
            hpSliderSecondary.DOValue(value, 1f);
        }
    }
}
