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
            distance -= Input.GetAxis("Mouse ScrollWheel");
        }
        private void FixedUpdate()
        {
            Vector3 dir = (LookAt.transform.position - this.transform.position).normalized;
            this.transform.position = LookAt.transform.position - dir * distance;
        }
        private void LateUpdate()
        {
            MyUpdate();
            CameraMove();
            this.transform.LookAt(_center.transform);
        }
        private void CameraMove()
        {
            offest = _follow.GetComponent<ControlFsm>().GetDoitMove;
            this.transform.position += offest;
        }
        private void MyUpdate()
        {
            
            TransX();
            TransY();
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

        private void TransY()
        {
            RaycastHit hit;
            if (Physics.Linecast(_center.transform.position + Vector3.up*0.1f, this.transform.position, out hit))
            {
                string name = hit.collider.gameObject.tag;
                if (name == "terrain")
                {
                    //如果射线碰撞的不是相机，那么就取得射线碰撞点到玩家的距离
                    float currentDistance = Vector3.Distance(hit.point, _center.transform.position);
                    //如果射线碰撞点小于玩家与相机本来的距离，就说明角色身后是有东西，为了避免穿墙，就把相机拉近
                    if (currentDistance < distance)
                    {
                        this.transform.position = hit.point;
                    }
                }
            }
            this.transform.RotateAround(_center.transform.position, this.transform.right, CharacterInput.Instance.CamerVector.y * -0.8f);
        }
    }
}
