using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFsm : BaseFsm
{
    public override void MyUpdate(Animator _ani)
    {
        
    }

    public override void PrepareEnter(Animator _ani)
    {
        CharacterInput.Instance.InputEnable = false;
        _ani.SetTrigger("Jump");
    }

    public override void PrepareExit(Animator _ani)
    {
        CharacterInput.Instance.InputEnable = true;
    }
}
