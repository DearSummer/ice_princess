using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MonsterScript.Fsm
{
    public class FinalMachine : MonoBehaviour
    {
        private BaseMonterFsm currentFsm;
        private Animator animator;
        private BaseMonterFsm AttackFsm = new MonsterAttack();
        private BaseMonterFsm IdleFsm = new MonsterIdle();
        private BaseMonterFsm RunFsm = new MonsterRun();
        private BaseMonterFsm HurtFsm = new MonsterHurt();
        //怪物声音播放
        [SerializeField]
        private AudioSource audioSouce;
        // Use this for initialization
        void Start()
        {
            animator = this.GetComponent<Animator>();
            IdleFsm.PrepareEnter(animator,audioSouce);
            currentFsm = IdleFsm;
        }

        // Update is called once per frame
        void Update()
        {
            currentFsm.MyUpdate();
        }
        private void Translate()
        {
            
        }
        public void TranslateToAttack()
        {
            currentFsm.PrepareExit();
            AttackFsm.PrepareEnter(animator,audioSouce);
            currentFsm = AttackFsm;
        }
        public void TranslateToIdle()
        {
            currentFsm.PrepareExit();
            IdleFsm.PrepareEnter(animator, audioSouce);
            currentFsm = IdleFsm;
        }
        public void TranslateToRun()
        {
            currentFsm.PrepareExit();
            RunFsm.PrepareEnter(animator, audioSouce);
            currentFsm = RunFsm;
        }
        public void TranslateToDamge()
        {
            currentFsm.PrepareExit();
            HurtFsm.PrepareEnter(animator, audioSouce);
            currentFsm = HurtFsm;

        }
    }
}
