using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInHand : SwordState
{
    private GameObject _operated ;
    private string _name = "HandlerSword";
    public override void MyUpdate()
    {
        
    }

    public override void PrepareEnter()
    {
        if (_operated == null) _operated = GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().HandlerSword;
        _operated.SetActive(true);
        _operated.GetComponent<MeshRenderer>().enabled = true;
        _operated.GetComponentInChildren<BoxCollider>().enabled = true;
    }
    public override void PrepareExit()
    {
        GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().DisPlay(_operated, false);
        _operated.GetComponentInChildren<BoxCollider>().enabled = false;
    }
}
