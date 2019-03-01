using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;
 
 
//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring
{
    public interface IMessageCallback
    {
        void ReciveMessage(object sender, object param);
    }
}
