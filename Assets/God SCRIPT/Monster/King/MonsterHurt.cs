using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Fsm
{
    public class MonsterHurt : BaseMonterFsm
    {
        private Animator animator;
        private AudioSource audioSouce;
        private int DamageChoice =0;

        private float defense = 0.5f;
        public void MyUpdate()
        {
            
        }

        public void PrepareEnter(Animator ani, AudioSource ads)
        {
            animator = ani;
            audioSouce = ads;
            if(Random.Range(0f,1f)>0.2f)
            {
                animator.SetInteger("DamageChoice", DamageChoice);
                DamageChoice++;
            }
            DamageChoice = DamageChoice > 1 ? 0 : DamageChoice;
        }

        public void PrepareExit()
        {
            animator.SetInteger("DamageChoice", -1);
        }
    }
}
