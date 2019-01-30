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
    //private void Update()
    //{
    //    if (Open == true)
    //    {
    //        float t = 1f / Time.fixedDeltaTime;
    //        this.transform.parent.transform.position += this.transform.parent.transform.forward * Time.deltaTime * 5;
    //        cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 80f, (t / 10) * Time.deltaTime);
    //    }
    //    else if (Open == false || PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.RunJump)
    //    {
    //        float t = 1f / Time.fixedDeltaTime;
    //        cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 60f, (t / 10) * Time.deltaTime);
    //    }
    //    //这部分从冲刺中退出来，完全可以放在2个脚本中，我这写完全是堆积的，随意很杂乱无章，需要重构一波
    //    if (FirstIn == true && PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.walk)
    //    {
    //        DisablePost();
    //    }
    //}
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
}
