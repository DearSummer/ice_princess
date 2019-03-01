using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
//-------------------------------------------
//  author: 
//  description:  
//-------------------------------------------
namespace FairySpring.UI
{
    public class SkyboxCircle : MonoBehaviour
    {
        [SerializeField]
        private Material[] skyboxMaterial;
        private int index = 0;

        // Use this for initialization
        void Start ()
        {
            InvokeRepeating("changeSkybox", 0, 5f);
        }

        private void changeSkybox()
        {
            RenderSettings.skybox = skyboxMaterial[index];
            index++;
            index %= skyboxMaterial.Length;
        }
    }
}
