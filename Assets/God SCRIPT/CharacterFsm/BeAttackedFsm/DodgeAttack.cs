using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAttack : BaseFsm
{
    public override void MyUpdate(Animator _ani)
    {
        if(Input.GetMouseButtonDown(0))
        {
            _ani.SetTrigger("LeftButtonDown");
        }
    }
    public override void MyFixUpdate(Animator _ani)
    {
        
    }
    public override void PrepareEnter(Animator _ani)
    {

    }

    public override void PrepareExit(Animator _ani)
    {

    }
}
