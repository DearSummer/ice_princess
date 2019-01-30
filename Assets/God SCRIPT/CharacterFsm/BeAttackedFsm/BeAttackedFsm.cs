using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttackedFsm : BaseFsm
{
    private BaseFsm _dodgeAttackFsm = new DodgeAttack();
    private BaseFsm _tureAttackedFsm = new TureAttacked();
    private BaseFsm _currentFsm = null;
    public BeAttackedFsm()
    {
    }
    public override void MyUpdate(Animator _ani)
    {
        bool flag = _ani.GetBool("IsTrueAttacked");
        if (flag) _currentFsm = _tureAttackedFsm;
        else _currentFsm = _dodgeAttackFsm;
        _currentFsm.MyUpdate(_ani);
    }
    public override void MyFixUpdate(Animator _ani)
    {

    }
    public override void PrepareEnter(Animator _ani)
    {
        _ani.SetTrigger("beAttacked");
    }

    public override void PrepareExit(Animator _ani)
    {
        _currentFsm.PrepareExit(_ani);
        PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.action;
    }
}
