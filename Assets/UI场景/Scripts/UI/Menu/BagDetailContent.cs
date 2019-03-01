using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI.Menu
{
    public class BagDetailContent : Content, IMessageCallback
    {

        public Text name;
        public Text desc;

        protected override void OnMessageRecive(MenuMessage menuMessage)
        {
            if (menuMessage.actionType != ActionType.Bag)
                return;

            if (menuMessage.message.Equals(MenuString.Bag.SHOW_BAG))
            {

                this.gameObject.SetActive(false);
                this.gameObject.SetActive(true);
                name.text = ((EquipmentMessage) menuMessage.messageBody).name;
                desc.text = ((EquipmentMessage) menuMessage.messageBody).desc;

            }
        }





    }
}
