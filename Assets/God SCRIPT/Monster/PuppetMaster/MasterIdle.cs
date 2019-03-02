using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
namespace MonsterScript.PuppetMaster
{
    public class MasterIdle : BaseMonterFsm
    {

        // Use this for initialization
        private int IdleChoice = -1;
        private Animator animator;
        private AudioSource audioSouce;
        //这里用来变化站立的姿态，单个太单调
        private float timeCalculator = 5f;
        public void MyUpdate()
        {
            if ((timeCalculator -= Time.deltaTime) < 0f)
            {
                timeCalculator = 5f;
                IdleChoice++;
                IdleChoice = IdleChoice > 0 ? -1 : IdleChoice;
                animator.SetInteger("IdleChoice", IdleChoice);
            }
        }
        public void PrepareEnter(Animator Ani, AudioSource ado)
        {
            IdleChoice = -1;
            animator = Ani;
            audioSouce = ado;
            animator.SetInteger("IdleChoice", IdleChoice);
        }

        public void PrepareExit()
        {
            IdleChoice = -1;
            animator.SetInteger("IdleChoice", IdleChoice);
        }
    }
}
