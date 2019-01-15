using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent:MonoBehaviour{
    private SwordControl SwordFsm = null;

    [SerializeField]
    private Animator _ani;

    private AudioSource audio;
    public void Start()
    {
        audio = GetComponent<AudioSource>();
        SwordFsm = GetComponentInParent<SwordControl>();
    }
    public void SwordIdle()
    {
        SwordFsm.TranslateToState(SwordFsm.GetState(0));
    }
    private void SwordInHandler()
    {
        SwordFsm.TranslateToState(SwordFsm.GetState(1));
    }
    private void SowrdFly()
    {
        ((SwordRotate)SwordFsm.GetState(2))._IsBack = false;
        SwordFsm.TranslateToState(SwordFsm.GetState(2));
    }
    private void SwordFlyBack()
    {
        ((SwordRotate)SwordFsm.GetState(2))._IsMove = true;
        ((SwordRotate)SwordFsm.GetState(2))._IsBack = true;
    }
    private void SwordFlyRotate()
    {
        ((SwordRotate)SwordFsm.GetState(2))._IsMove = false;
    }
    private void SwordThrow()
    {
        SwordFsm.TranslateToState(SwordFsm.GetState(3));
    }
    private void SwordThrowStop()
    {
        ((SwordThrow)SwordFsm.GetState(3))._isStop = true;
    }
}
