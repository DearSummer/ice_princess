using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace FairySpring.UI
{
    public class ChangeFront : MonoBehaviour
    {
        public Color mColor;
        float red = 150;
        float green = 100;
        float blue = 5;
        float mChangeTime = 0.05f;

        // Use this for initialization
        void Start()
        {
            mColor = this.GetComponent<Text>().color;
        }

        // Update is called once per frame
        void Update()
        {

            red += Random.Range(0, 2);
            green += Random.Range(0, 2);
            if (red >= 255 || green >= 255)
            {
                red = 150;
                green = 100;
                blue = 5;
            }

            this.GetComponent<Text>().color = new Color32((byte) red, (byte) green, (byte) blue, (byte) 255f);
            //mChangeTime = 0.05f;
        }
    }

}