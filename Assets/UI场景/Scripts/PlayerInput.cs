using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring
{
    public class PlayerInput : MonoBehaviour
    {
        [Header("-----key setting----")]
        public string keyUp;
        public string keyDown;
        public string keyLeft;
        public string keyRight;

        [Header("--------camera key setting----")]
        public string cKeyUp;
        public string cKeyDown;
        public string cKeyLeft;
        public string cKeyRight;
        public float cSensitivityX = 0.25f;
        public float cSensitivityY = 0.5f;

        [Header("-----run key------")]
        public string keyA;
        [Header("------jump key-----")]
        public string keyB;

        [Header("-----attack key setting----")]
        public string keyC;
        public string keyD;

        private float targetUpValue;
        private float targetRightValue;

        private float targetCUpvalue;
        private float targetCRightValue;

        private float velocityUpValue;
        private float velocityRightValue;

        private float velocityCUpValue;
        private float velocityCRightValue;

        [Header("----Lens locked----")]
        public bool IsLensLocked=false;
        public bool Run
        {
            private set;
            get;
        }

        public bool Jump
        {
            private set;
            get;
        }

        public bool Attack
        {
            private set;
            get;
        }

        public bool Magic
        {
            private set;
            get;
        }

        //摄像机的上方向信号量
        public float CUpValue
        {
            private set;
            get;
        }

        //摄像机的右方向信号量
        public float CRightValue
        {
            private set;
            get;
        }

        public float UpValue
        {
            private set;
            get;
        }

        public float RightValue
        {
            private set;
            get;
        }

        public float SignalValueMagic
        {
            private set;
            get;
        }

        public Vector3 SignalVec
        {
            set;
            get;
        }

        [SerializeField]
        [Header("-------enable-------")]
        private bool inputEnable = true;

        public bool InputEnable
        {
            get
            {
                return inputEnable;
            }
            set
            {
                inputEnable = value;
            }
        }

        // Update is called once per frame
        void Update()
        {

            InputHandler();

            if (!inputEnable)
            {
                targetRightValue = 0f;
                targetUpValue = 0f;
            }

            UpValue = Mathf.SmoothDamp(UpValue, targetUpValue, ref velocityUpValue, 0.1f);
            RightValue = Mathf.SmoothDamp(RightValue, targetRightValue, ref velocityRightValue, 0.1f);

            CUpValue = Mathf.SmoothDamp(CUpValue, targetCUpvalue, ref velocityCUpValue, 0.3f);
            CRightValue = Mathf.SmoothDamp(CRightValue, targetCRightValue, ref velocityCRightValue, 0.3f);


            Vector2 temp = SquareToCircle(new Vector2(UpValue, RightValue));

            SignalValueMagic = Mathf.Sqrt(temp.x * temp.x + temp.y * temp.y);
            SignalVec = temp.x * this.transform.forward + temp.y * this.transform.right;
        }

        /// <summary>
        /// 控制输入的信息
        /// </summary>
        private void InputHandler()
        {
            //if (CheckLock() == false) MouseTurn();

            Run = Input.GetKey(keyA);
            Jump = Input.GetKey(keyB);
            Attack = Input.GetKey(keyC);
            Magic = Input.GetKey(keyD);
        }
        /////鼠标控制转向
        private void MouseTurn()
        {
            targetUpValue = (Input.GetKey(keyUp) ? 1.0f : 0f) - (Input.GetKey(keyDown) ? 1.0f : 0f);

            targetRightValue = (Input.GetKey(keyRight) ? 1.0f : 0f) - (Input.GetKey(keyLeft) ? 1.0f : 0f);


            //targetCUpvalue = (Input.GetKey(cKeyUp) ? 1.0f : 0f) - (Input.GetKey(cKeyDown) ? 1.0f : 0f);
            targetCUpvalue = Input.GetAxis("Mouse Y") * cSensitivityY;
            //targetCRightValue = (Input.GetKey(cKeyRight) ? 1.0f : 0f) - (Input.GetKey(cKeyLeft) ? 1.0f : 0f);
            targetCRightValue = Input.GetAxis("Mouse X") * cSensitivityX;
        }
        /// <summary>
        /// 将直角坐标系下的坐标映射为相应的圆的坐标
        /// </summary>
        /// <param name="input">直角坐标系下的坐标</param>
        /// <returns>相应的圆的坐标系的坐标</returns>
        private Vector2 SquareToCircle(Vector2 input)
        {
            Vector2 result = Vector2.zero;
            result.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
            result.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);

            return result;
        }
        /////////////控制是否锁住镜头/////
        private bool CheckLock()
        {
            if(ProjectConstant.GAME_STATE!=GameState.Normal)
            {
                return false;
            }
            return true;
        }
    }
}
