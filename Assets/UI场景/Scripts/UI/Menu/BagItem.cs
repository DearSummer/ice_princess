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
    public class BagItem : MonoBehaviour
    {

        public Text name;
        public Text count;

        private EquipmentMessage message;


        public void InitBagItem(string name, int count,EquipmentMessage message)
        {
            this.name.text = name;
            this.count.text = count.ToString();

            this.message = message;
        }

        public void OnBagItemClick()
        {
            MenuMessage message = new MenuMessage(ActionType.Bag, MenuString.Bag.SHOW_BAG) {messageBody = this.message};
            MessageDispatcher.Instance.DispatchMessage(ProjectConstant.MessageBlock.MENU_MSG, this,
                message);
        }
    }
}
