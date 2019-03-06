using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
namespace MonsterScript.Golem
{
    public class IceMonsterIdle : BaseMonterFsm
    {
        private float interval = 3f;
        private Animation animtion;
        private AudioSource audioSouce;
        private GolemEvent goleEvent;
        private int IdleChoice = 0;
        private bool Ok = false;
        public void MyUpdate()
        {
            if (!animtion.isPlaying)
            {
                animtion.Play();
            }
        }
        public void PrepareEnter(Animator ani, AudioSource ads)
        {
            if(animtion == null) animtion = ads.gameObject.GetComponentInChildren<Animation>();
            if(audioSouce==null) audioSouce = ads;
            if(goleEvent==null) goleEvent = ads.gameObject.GetComponent<GolemEvent>();
        }

        public void PrepareExit()
        {
            
        }
    }
}
