using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CamerScript
{
    public class MouseCamera : MonoBehaviour
    {
        [SerializeField]
        private GameObject LookAt;
        [SerializeField]
        private GameObject _center;
        [SerializeField]
        private GameObject _follow;

        private Vector3 _distance;

        private Vector3 offest = Vector3.zero;
        // Use this for initialization
        void Start()
        {
            _follow = GameObject.FindWithTag("Player");

        }

        // Update is called once per frame
        void Update()
        {
            MyUpdate();
        }
        private void FixedUpdate()
        {
            offest = _follow.GetComponent<ControlFsm>().GetDoitMove;
            this.transform.position += new Vector3(offest.x, 0, offest.z);
        }
        private void MyUpdate()
        {
            this.transform.RotateAround(_center.transform.position, _center.transform.up, CharacterInput.Instance.CamerVector.x * 10);
            offest = _center.transform.position - this.transform.position;
            //this.transform.LookAt(LookAt.transform);
        }
    }
}
