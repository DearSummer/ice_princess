using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CamerScript
{
    public class CameraView : MonoBehaviour
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
        void Update()
        {

        }
        private void FixedUpdate()
        {
            if (Open == true)
            {
                float t = 1f / Time.fixedDeltaTime;
                this.GetComponent<Camera>().fieldOfView = Mathf.Lerp(this.GetComponent<Camera>().fieldOfView, 90f, (t / 10) * Time.deltaTime);
            }
            else if (Open == false || PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.RunJump)
            {
                float t = 1f / Time.fixedDeltaTime;
                this.GetComponent<Camera>().fieldOfView = Mathf.Lerp(this.GetComponent<Camera>().fieldOfView, 60f, (t / 10) * Time.deltaTime);
            }
            if (FirstIn == true && PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.walk)
            {
                DisablePost();
            }
        }
        public void EnablePost()
        {
            FirstIn = true;
            postProcess.enabled = true;
            preEffect.SetActive(true);
            //PlayInfo.Instance._actionInfo = PlayInfo.actionInfo.Run;
            Open = true;
        }
        public void DisablePost()
        {
            FirstIn = false;
            postProcess.enabled = false;
            preEffect.SetActive(false);
            Open = false;
            //关闭跑步
            PlayInfo.Instance._actionInfo= PlayInfo.actionInfo.Run;
            _ani.ResetTrigger("RunExit");
            _ani.SetTrigger("RunExit");
        }
    }
}
