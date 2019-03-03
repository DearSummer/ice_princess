using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BeAttackedFsm : BaseFsm
{
    private BaseFsm _dodgeAttackFsm = new DodgeAttack();
    private BaseFsm _tureAttackedFsm = new TureAttacked();
    private BaseFsm _currentFsm = null;

    private PlayableDirector director;

    private float _time = 0.3f;
    public BeAttackedFsm()
    {
    }
    public override void MyUpdate(Animator _ani)
    {
        if(_currentFsm!=null)
        {
            _currentFsm.MyUpdate(_ani);
        }
        else
        {
            if ((_time -= Time.deltaTime) > 0)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
//                    _time = 1f;
//                    _ani.SetTrigger("Dodge");
//                    _currentFsm = _dodgeAttackFsm;
//                    _currentFsm.PrepareEnter(_ani);
                    director.Play();
                }
            }
            else
            {
                _currentFsm = _tureAttackedFsm;
            }
        }
        
    }
    public override void MyFixUpdate(Animator _ani)
    {

    }
    public override void PrepareEnter(Animator _ani)
    {
        PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.injured;
        _ani.SetTrigger("TakeDamage");
        _currentFsm = null;
        _time = 0.3f;

        director = _ani.GetComponent<PlayableDirector>();
    }

    public override void PrepareExit(Animator _ani)
    {
        if (_currentFsm == null)
        {
            _currentFsm = _tureAttackedFsm;
        }
        _currentFsm.PrepareExit(_ani);
        PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.action;
    }
}
