using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewOfField : MonoBehaviour
{
    [SerializeField]
    private Animator _ani;
    [SerializeField]
    private ImageEffect_RadialBlur postProcess;
    [SerializeField]
    private Camera cam;

    private bool Open = false;

    [SerializeField]
    private GameObject preEffect;

    private bool FirstIn = false;

    [SerializeField]
    private GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixUpdate()
    {
        if (Open == true)
        {
            float t = 1f / Time.fixedDeltaTime;
            //player.transform.transform.position += player.transform.transform.forward * Time.deltaTime * 5;
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 80f, (t / 10) * Time.deltaTime);
        }
        else if (Open == false || PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.RunJump)
        {
            float t = 1f / Time.fixedDeltaTime;
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 60f, (t / 10) * Time.deltaTime);
        }
        //这部分从冲刺中退出来，完全可以放在2个脚本中，我这写完全是堆积的，随意很杂乱无章，需要重构一波
        if (FirstIn == true && PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.walk)
        {
            Debug.Log("1111");
            DisablePost();
        }
    }
    private void EnablePost()
    {
        FirstIn = true;
        postProcess.enabled = true;
        preEffect.SetActive(true);
        //PlayInfo.Instance._actionInfo = PlayInfo.actionInfo.Run;
        Open = true;
    }
    private void DisablePost()
    {
        FirstIn = false;
        postProcess.enabled = false;
        preEffect.SetActive(false);
        Open = false;
        //关闭跑步
        _ani.SetTrigger("RunExit");
        PlayInfo.Instance._actionInfo = PlayInfo.actionInfo.Run;
    }
}
