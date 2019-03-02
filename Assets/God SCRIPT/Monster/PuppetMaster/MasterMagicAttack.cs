using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
namespace MonsterScript.PuppetMaster
{
    public class MasterMagicAttack : BaseMonterFsm
    {
        private int magicAttackChoice = 0;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private AudioSource audioSource;

        private float dertaTime = 0f;
        public void MyUpdate()
        {
            if((dertaTime-=Time.deltaTime)<0f)
            {
                animator.SetInteger("magicAttackChocie", magicAttackChoice);
                animator.SetTrigger("test");
                dertaTime = 15f;
            }
        }
        public void PrepareEnter(Animator ani, AudioSource ads)
        {
            magicAttackChoice = 0;
            animator = ani;
            audioSource = ads;
        }
        public void PrepareExit()
        {
            magicAttackChoice = -1;
            animator.SetInteger("magicAttackChocie", magicAttackChoice);
        }
    }
}

