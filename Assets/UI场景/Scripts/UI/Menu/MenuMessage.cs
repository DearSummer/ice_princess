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
    public class MenuMessage
    {
        public ActionType actionType;
        public string message;
        public object messageBody;

        public MenuMessage(ActionType actionType,string message)
        {
            this.actionType = actionType;
            this.message = message;
        }


    }
}
