using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MonsterScript.Fsm
{
    public class MonsterIdle : BaseMonterFsm
    {
        private int IdleTo = -1;
        private Animator animator;
        private AudioSource audioSouce;
        //这里用来变化站立的姿态，单个太单调
        private float timeCalculator = 5f;
        public void MyUpdate()
        {
            if((timeCalculator-=Time.deltaTime)<0f)
            {
                timeCalculator = 5f;
                IdleTo++;
                IdleTo = IdleTo > 1 ? -1 : IdleTo;
                animator.SetInteger("IdleTo", IdleTo);
            }
        }
        public void PrepareEnter(Animator Ani, AudioSource ado)
        {
            IdleTo = -1;
            animator = Ani;
            audioSouce = ado;
            animator.SetInteger("IdleTo", IdleTo);
        }

        public void PrepareExit()
        {
            IdleTo = -1;
            animator.SetInteger("IdleTo", IdleTo);
        }
    }
}
