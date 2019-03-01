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
    public class BagItemLoader : MonoBehaviour
    {
        public GameObject content;
        public GameObject bagItem;

        // Use this for initialization
        void Start ()
        {
            InitBagItem();
        }

        private void InitBagItem()
        {
            for (int i = 0; i < 20; i++)
            {
                EquipmentMessage message = new EquipmentMessage
                {
                    name = (i + 1) + "God Of Wisdom",
                    desc = "make by akua"
                };
                LoadItem((i + 1) + "God Of Wisdom", i + 1,message);
            }
        }


        private void LoadItem(string name, int count,EquipmentMessage message)
        {
            var item = GameObject.Instantiate(bagItem);
            item.GetComponent<BagItem>().InitBagItem(name, count,message);

            item.transform.SetParent(content.transform, false);
        }
    }
}
