using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent:MonoBehaviour{
    private SwordControl SwordFsm = null;

    [SerializeField]
    private Animator _ani;

    [SerializeField]
    private ImageEffect_RadialBlur postProcess;
    [SerializeField]
    private Camera cam;

    private bool Open = false;

    [SerializeField]
    private GameObject preEffect;
    private AudioSource audio;
    public void Start()
    {
        audio = GetComponent<AudioSource>();
        SwordFsm = GetComponentInParent<SwordControl>();
    }
    private void Update()
    {
        if(Open == true)
        {
            float t = 1f / Time.fixedDeltaTime;
            this.transform.parent.transform.position += this.transform.parent.transform.forward * Time.deltaTime*5;
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 80f, (t / 10) * Time.deltaTime);
        }
        else
        {
            float t = 1f / Time.fixedDeltaTime;
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 60f, (t / 10) * Time.deltaTime);
        }
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
    private void EnablePost()
    {
        postProcess.enabled = true;
        preEffect.SetActive(true);
        Open = true;
    }
    private void DisablePost()
    {
        postProcess.enabled = false;
        preEffect.SetActive(false);
        Open = false;
    }
}
