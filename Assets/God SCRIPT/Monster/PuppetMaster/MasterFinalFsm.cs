using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
namespace MonsterScript.PuppetMaster
{
    public class MasterFinalFsm : MonoBehaviour
    {
        private BaseMonterFsm currentFsm;
        private BaseMonterFsm magicAttackFsm = new MasterMagicAttack();
        private BaseMonterFsm magicIdleFsm = new MasterIdle();
        private Animator animator;
        private AudioSource audioSouce;
        private void Start()
        {
            animator = this.GetComponent<Animator>();
            magicIdleFsm.PrepareEnter(animator, audioSouce);
            currentFsm = magicIdleFsm;
        }
        private void Update()
        {
            currentFsm.MyUpdate();
        }
        public void Translate(int num)
        {
            currentFsm.PrepareExit();
            switch(num)
            {
                case 0:
                    currentFsm = magicIdleFsm;
                    break;
                case 1:
                    currentFsm = magicAttackFsm;
                    break;
            }
            currentFsm.PrepareEnter(animator, audioSouce);
        }
    }
}
