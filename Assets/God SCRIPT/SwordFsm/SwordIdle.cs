using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordIdle : SwordState
{
    private GameObject _operated;
    private GameObject _operatedRight;
    private GameObject _show;
    private    string   _name = "LevitatedSword";
    public override void MyUpdate()
    {
        
    }

    public override void PrepareEnter()
    {
        if (_operated == null)
        {
            //_operatedRight =  GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().LevitatedSwordRight;
            _operated = GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().LevitatedSword;
            //_show = GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().HandlerSwordRight;
        }
        _operated.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().DisPlay(_operated, true);
        //_operated.SetActive(true);
        //_operatedRight.SetActive(true);
        //_show.SetActive(false);
    }

    public override void PrepareExit()
    {
        if (_operated == null)
        {
           // _operatedRight = GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().LevitatedSwordRight;
            _operated = GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().LevitatedSword;
            //_show = GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().HandlerSwordRight;
        }
        //_operated.GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().DisPlay(_operated,false);
        //_operated.SetActive(false);
        // _operatedRight.SetActive(false);
        //_show.SetActive(true);
    }
}
