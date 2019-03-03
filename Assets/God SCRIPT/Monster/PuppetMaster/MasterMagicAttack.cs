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

        private float dertaTimeOne = 0f;
        private float dertaTimeTwo = 20f;
        public void MyUpdate()
        {
            if((dertaTimeOne -= Time.deltaTime)<0f)
            {
                animator.SetInteger("magicAttackChocie", 0);
                dertaTimeOne = 15f;      
            }
            else if((dertaTimeTwo -= Time.deltaTime) < 0f)
            {
                animator.SetInteger("magicAttackChocie", 1);
                dertaTimeTwo = 20f;
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

