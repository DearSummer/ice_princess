using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Fsm
{
    public class MonsterAttack : BaseMonterFsm
    {
        private int AttackChoice = 0;
        private Animator animator;
        private AudioSource audioSouce;
        public void MyUpdate()
        {
            
        }

        public void PrepareEnter(Animator Ani, AudioSource ado)
        {
            AttackChoice = 0;
            animator = Ani;
            audioSouce = ado;
            animator.SetInteger("AttackChoice", AttackChoice);
        }

        public void PrepareExit()
        {
            AttackChoice = -1;
            animator.SetInteger("AttackChoice", AttackChoice);
        }
    }
}
