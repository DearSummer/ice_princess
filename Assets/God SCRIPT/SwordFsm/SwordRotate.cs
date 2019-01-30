using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRotate : SwordState
{
    private GameObject _temp = null;
    private GameObject _model = null;

    private string _modelName = "HandlerSword";

    private GameObject _handler = null;

    public bool _IsBack = false;
    public bool _IsMove = true;
    public override void MyUpdate()
    {
        if(_IsMove)
        {
            if (_IsBack)
            {
                _temp.transform.position -= _handler.transform.forward * Time.deltaTime * 10;
            }
            else
            {
                _temp.transform.position += _handler.transform.forward * Time.deltaTime * 10;
            }
        }
        _temp.transform.Rotate(Vector3.up * 1800 * Time.deltaTime, Space.World);
    }

    public override void PrepareEnter()
    {
        if (_model == null) _model = GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().HandlerSword;
        _handler = GameObject.Find("CorrentPoint");

        _temp = GameObject.Instantiate(_model);

        _temp.SetActive(true);
        _temp.GetComponent<MeshRenderer>().enabled = true;

        _temp.GetComponentInChildren<BoxCollider>().enabled = true;
        _temp.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        _temp.transform.position = _handler.transform.position;
        _temp.transform.SetParent(null);
        _temp.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public override void PrepareExit()
    {
        GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().DesObject(_temp);
    }
}
