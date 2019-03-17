using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFsm : BaseFsm
{
    public override void MyFixUpdate(Animator _ani)
    {

    }

    public override void MyUpdate(Animator _ani)
    {

    }

    public override void PrepareEnter(Animator _ani)
    {
        _ani.SetTrigger("Jump");
        _ani.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(_ani.gameObject.transform.up * 3000);
        _ani.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(_ani.gameObject.transform.forward * 2000);

    }

    public override void PrepareExit(Animator _ani)
    {
        PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.action;
    }
}
