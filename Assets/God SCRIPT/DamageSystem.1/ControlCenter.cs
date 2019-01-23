using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCenter : MonoBehaviour,IMsgReceiver<HurtType,HurtData> {
    public HurtAble ha;

    public void ReceiverMsg(HurtData data, object sender, HurtType type)
    {
        if(type == HurtType.Damage)
        {
            
        }
    }
    // Use this for initialization
    void Start () {
        ha.Register(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
