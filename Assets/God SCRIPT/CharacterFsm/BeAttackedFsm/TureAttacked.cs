using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TureAttacked : BaseFsm
{
    public override void MyFixUpdate(Animator _ani)
    {

    }

    public override void MyUpdate(Animator _ani)
    {
        
    }

    public override void PrepareEnter(Animator _ani)
    {
        
    }

    public override void PrepareExit(Animator _ani)
    {
        _ani.SetBool("IsTrueAttacked", false);
    }
}
