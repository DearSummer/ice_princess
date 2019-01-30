using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            _ani.SetBool("IsPress", true);
        }
        else if(Input.GetMouseButton(1))
        {
            _ani.SetTrigger("RightButtonDown");
            _ani.ResetTrigger("LeftButtonDown");
            _ani.SetBool("IsPress", true);
        }
        _ani.speed = Mathf.Lerp(_ani.speed, 1, 0.05f);
    }

    public override void PrepareEnter(Animator _ani)
    {
        _ani.SetBool("IsPress", false);
        _ani.SetBool("attack", true);
    }

    public override void PrepareExit(Animator _ani)
    {
        _ani.SetBool("attack", false);
        _ani.SetBool("IsRunAttack", false);
        _ani.ResetTrigger("RightButtonDown");
        _ani.ResetTrigger("LeftButtonDown");
    }
}
