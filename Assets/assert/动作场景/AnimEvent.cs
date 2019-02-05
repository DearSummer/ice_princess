using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CamerScript;
public class AnimEvent:MonoBehaviour{
    private SwordControl SwordFsm = null;
    [SerializeField]
    private CameraView camView;
    public void Start()
    {
        SwordFsm = GetComponentInParent<SwordControl>();
    }
    private bool FirstIn = false;
    //这里都是命令，其实都可以用命令封装起来
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
    private void EnablePost()
    {
        camView.EnablePost();
    }
    private void DisablePost()
    {
        camView.DisablePost();
    }
    private void UpAttack()
    {
        this.transform.parent.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.parent.transform.up * 2000);
    }
    private void ForWardSpecialAttack()
    {
        camView.ForWardSpecialAttack();
        camView.CameraShake();
    }
}
