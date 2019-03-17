using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorScript;
public class AttackFsm:BaseFsm  {
    public override void MyFixUpdate(Animator _ani)
    {
        
    }
    public override void MyUpdate(Animator _ani)
    {
        if(Input.GetMouseButtonDown(0))
        {
            _ani.SetTrigger("LeftButtonDown");
            _ani.ResetTrigger("RightButtonDown");
            //_ani.SetBool("IsPress", true);
        }
        else if(Input.GetMouseButton(1))
        {
            _ani.SetTrigger("RightButtonDown");
            _ani.ResetTrigger("LeftButtonDown");
            //_ani.SetBool("IsPress", true);
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            _ani.SetTrigger("Back");
            _ani.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce((_ani.gameObject.transform.up-
            _ani.gameObject.transform.forward) * 1000);
        }
        _ani.speed = Mathf.Lerp(_ani.speed, 1, 0.05f);
    }

    public override void PrepareEnter(Animator _ani)
    {
        PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.attack;
        _ani.SetTrigger("Attack");
        if(AnimatorInfo.Instance.Run)
        {
            _ani.SetBool("RunAttack",true);
        }
        else
        {
            _ani.SetBool("RunAttack", false);
        }
    }

    public override void PrepareExit(Animator _ani)
    {
        Reset(_ani);
    }
    private void Reset(Animator _ani)
    {
        _ani.ResetTrigger("RightButtonDown");
        _ani.ResetTrigger("LeftButtonDown");
        AnimatorInfo.Instance.Run = false;
    }
}
