using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI.PlayerState
{
    public class OutputTexture : RawImage
    {
        private Slider slider;

        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();

            slider = GetComponentInParent<Slider>();
            if (slider)
            {
                uvRect = new Rect(0, 0, slider.value, 1);
            }

        }
    }
}
