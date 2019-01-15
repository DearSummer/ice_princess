using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordThrow : SwordState
{
    private GameObject _temp = null;
    private GameObject _model = null;

    private string _modelName = "HandlerSword";

    public bool _isStop = false;
    public override void MyUpdate()
    {
        if(!_isStop)_temp.transform.position -= -_temp.transform.up * Time.deltaTime * 3;
    }

    public override void PrepareEnter()
    {
        if (_model == null) _model = GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().HandlerSword;

        _temp = GameObject.Instantiate(_model);
        _temp.GetComponent<MeshRenderer>().enabled = true;
        _temp.SetActive(true);

        _temp.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        _temp.transform.position = _model.transform.position;
        _temp.transform.SetParent(null);
        _temp.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public override void PrepareExit()
    {
        _isStop = false;
        GameObject.Find("ShowOrHid").GetComponent<ShowOrHid>().DesObject(_temp);
    }
}
