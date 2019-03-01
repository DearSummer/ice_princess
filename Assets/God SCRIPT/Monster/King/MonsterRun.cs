using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Fsm
{
    public class MonsterRun : BaseMonterFsm{
        private Animator animator;
        private AudioSource audioSouce;
        private bool searchForEnemy = false;
        private GameObject operatedCharacter;
        public void MyUpdate()
        {
            if(searchForEnemy)
            {
                operatedCharacter.transform.position += operatedCharacter.transform.forward * Time.deltaTime*5f;
            }
        }

        public void PrepareEnter(Animator ani, AudioSource ads)
        {
            animator = ani;
            audioSouce = ads;
            animator.SetBool("Run", true);
            searchForEnemy = true;
            operatedCharacter = animator.gameObject;
        }

        public void PrepareExit()
        {
            animator.SetBool("Run", false);
            searchForEnemy = false;
        }
    }
}
