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

        [SerializeField][Range(1,5)]
        private float distance = 3f;
        // Use this for initialization
        void Start()
        {
            _follow = GameObject.FindWithTag("Player");

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void LateUpdate()
        {
            MyUpdate();
        }
        private void FixedUpdate()
        {
            offest = _follow.GetComponent<ControlFsm>().GetDoitMove;
            this.transform.position += offest;
        }
        private void MyUpdate()
        {
            Vector3 dir = (LookAt.transform.position - this.transform.position).normalized;
            Vector3 redir = new Vector3(dir.x, dir.y, dir.z * distance);
            this.transform.position = LookAt.transform.position - dir * distance;
            //this.transform.LookAt(LookAt.transform.position);
            TransX();
            TransY(dir);
            offest = _center.transform.position - this.transform.position;
            //this.transform.LookAt(LookAt.transform);
        }
        private float Correct(float target)
        {
            float max = 85f;
            float min = 30f;
            target = target > max ? max : target;
            target = target < min ? min : target;
            return target;
        }
        private void TransX()
        {
            this.transform.RotateAround(_center.transform.position, _center.transform.up, CharacterInput.Instance.CamerVector.x * 5);
        }
        private void TransY(Vector3 _dir)
        {
            RaycastHit hit;
            if(Physics.Linecast(this.transform.position,LookAt.transform.position,out hit))
            {
                string name = hit.collider.gameObject.tag;
                if(name =="terrain")
                {
                    transform.position = hit.point;
                }
            }
            this.transform.RotateAround(_center.transform.position, this.transform.right, CharacterInput.Instance.CamerVector.y * -0.8f);
        }
    }
}
