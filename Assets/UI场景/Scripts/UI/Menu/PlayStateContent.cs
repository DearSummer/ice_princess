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
    public class PlayStateContent : Content
    {
        
        [Tooltip("Character Name")]
        public Text name;

       [Tooltip("Character Property")]
        public Text lv;
        public Text hp;
        public Text mp;
        public Text atk;

        public Text def;


        protected override void OnMessageRecive(MenuMessage menuMessage)
        {
            if(menuMessage.actionType != ActionType.Player)
                return;

            SetActive(menuMessage.message.Equals(MenuString.Player.SHOW_PLAYER_STATE));
        }
    }
}
