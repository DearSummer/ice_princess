using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CamerScript
{
    public class CameraView : MonoBehaviour
    {
       // [SerializeField]
        private Animator _ani;
        [SerializeField]
        private ImageEffect_RadialBlur postProcess;
        [SerializeField]
        private Camera cam;
        [SerializeField]
       // private GameObject prEffect;
        private bool Open = false;

        private bool FirstIn = false;

        private float ViewPoint = 60f;
        // Use this for initialization
        void Start()
        {
            postProcess.enabled = false;
            _ani = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
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
                this.GetComponent<Camera>().fieldOfView = Mathf.Lerp(this.GetComponent<Camera>().fieldOfView, ViewPoint, (t / 10) * Time.deltaTime);
            }
            else if (Open == false || PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.RunJump)
            {
                float t = 1f / Time.fixedDeltaTime;
                this.GetComponent<Camera>().fieldOfView = Mathf.Lerp(this.GetComponent<Camera>().fieldOfView, ViewPoint, (t / 10) * Time.deltaTime);
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
            ViewPoint = 90f;
            Open = true;
         //   prEffect.SetActive(true);
        }
        public void DisablePost()
        {
            ViewPoint = 75f;
            FirstIn = false;
            postProcess.enabled = false;
            Open = false;
            //关闭跑步
            PlayInfo.Instance._actionInfo = PlayInfo.actionInfo.Run;
            _ani.SetTrigger("RunExit");
          //  prEffect.SetActive(false);
        }
        public void ForWardSpecialAttack()
        {
            ViewPoint = 90f;
            _ani.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(_ani.gameObject.transform.forward * 2000);
            _ani.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(_ani.gameObject.transform.up * 1500);
            StartCoroutine(BackToNormal());
        }
        IEnumerator BackToNormal()
        {
            yield return new WaitForSeconds(1);
            ViewPoint = 75f;
        }
        public void CameraShake()
        {

        }
    }
}