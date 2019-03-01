using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI.Menu
{
    public class EquipmentContent : Content
    {
        public Text name;
        public Text weapon;

        public Text equipment1;
        public Text equipment2;

        protected override void OnMessageRecive(MenuMessage menuMessage)
        {
            if(menuMessage.actionType != ActionType.Player)
                return;
            SetActive(menuMessage.message.Equals(MenuString.Player.SHOW_EQUIPMENT_STATE));
            string weaponName = "悲叹之种";
            ChangeEquipment(weaponName);
        }
        private void ChangeEquipment(string _EquipmentName)
        {

        }
    }
}
