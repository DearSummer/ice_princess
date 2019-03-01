using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI
{
    public class UIMessage
    {
        private byte messageId;
        private object value;

        public UIMessage(byte messageId,object value)
        {
            this.value = value;
            this.messageId = messageId;
        }

        public byte GetMessageId()
        {
            return messageId;
        }

        public T GetValue<T>()
        {
            return value is T ? (T) value : default(T);
        }
    }
}
