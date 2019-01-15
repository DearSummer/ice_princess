using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaKoBeattacked : BaseFsm
{
    public override void MyUpdate(Animator _ani)
    {
        
    }

    public override void PrepareEnter(Animator _ani)
    {
        _ani.SetTrigger("BeAttacked");
    }

    public override void PrepareExit(Animator _ani)
    {
        
    }
}
