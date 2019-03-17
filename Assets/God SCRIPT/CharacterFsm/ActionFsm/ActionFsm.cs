using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionSpace;


public class ActionFsm : BaseFsm
{
    private Animator _ani;
    private GameObject player = null;

    private BaseFsm _usualFsm = new UsualAction();
    private BaseFsm _sprintFsm = new SprintAction();
    public BaseFsm _currentFsm = null;

    public override void MyUpdate(Animator _ani)//主循环方法
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.jump;
            ControlFsm cf = GameObject.FindWithTag("Player").GetComponent<ControlFsm>();
            cf.Translate(cf.GetFsmAssemble(3));
        }
        if (PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.SprintRun&&_currentFsm != _sprintFsm)
        {
            Translate(_sprintFsm);           
        }
        else if(PlayInfo.Instance._actionInfo != PlayInfo.actionInfo.SprintRun && _currentFsm != _usualFsm)
        {
            Translate(_usualFsm);
        }
        _currentFsm.MyUpdate(_ani);
    }
    public override void MyFixUpdate(Animator _ani)
    {
        _currentFsm.MyFixUpdate(_ani);
    }
    public void Translate(BaseFsm nextFsm)
    {
        _currentFsm.PrepareExit(_ani);
        _currentFsm = nextFsm;
        _currentFsm.PrepareEnter(_ani);
    }
    public override void PrepareEnter(Animator ani)
    {
        _currentFsm = _usualFsm;
        _currentFsm.PrepareEnter(ani);

        _ani = ani;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public override void PrepareExit(Animator _ani)
    {
        _currentFsm.PrepareExit(_ani);
    }
}
