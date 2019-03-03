using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
namespace MonsterScript.PuppetMaster
{
    public class MasterSearch : BaseMonterFsm
    {
        private Animator animator;
        private AudioSource audioSource;
        public void MyUpdate()
        {
            animator.gameObject.transform.position += animator.transform.forward * Time.deltaTime*2f;
        }
        public void PrepareEnter(Animator ani, AudioSource ads)
        {
            animator = ani;
            audioSource = ads;
            animator.SetLayerWeight(ani.GetLayerIndex("Run"), 0.4f);
        }

        public void PrepareExit()
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Run"), 0f);
        }
    }
}
