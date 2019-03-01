using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring
{
    public class MessageSystem : MonoBehaviour
    {     
        // Update is called once per frame
        private void Update()
        {
            MessageDispatcher.Instance.Update();
        }

        private void OnDestroy()
        {
            MessageDispatcher.Instance.Dispose();
        }
    }
}
