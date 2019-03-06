using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Golem
{
    public class GolemEvent : MonoBehaviour
    {
        [SerializeField]
        private Animation animation;
        public bool run = false;
        public void TranslateToIdle()
        {
            run = false;
            animation.clip = animation.GetClip("Idle");
            animation.Play();
        }
        public void TranslateToAttack()
        {
            run = false;
            animation.clip = animation.GetClip("Attack");
            animation.Play();
        }
        public void TranslateToRun()
        {
            run = true;
            animation.clip = animation.GetClip("Run");
            animation.Play();
        }
        public void TranslateToHit(int choice)
        {
            string s = "Hit" + choice.ToString();
            animation.GetClip(s);
            animation.clip = animation.GetClip(s);
            animation.Play();
        }
        public void TranslateToDeath()
        {
            run = false;
            animation.clip = animation.GetClip("Death02");
            animation.Play();
        }
    }
}
