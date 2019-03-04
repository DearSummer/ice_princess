using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Fsm
{
    public class MonsterEvent : MonoBehaviour
    {

        public Collider col;

        private void Start()
        {
            col.enabled = false;
        }

        public void AttackEvent()
        {
            int attackChoice = this.GetComponent<Animator>().GetInteger("AttackChoice");
            attackChoice++;
            attackChoice = attackChoice > 3 ? 0:attackChoice;
            this.GetComponent<Animator>().SetInteger("AttackChoice",attackChoice);
        }
        public void BackToNormal()
        {
            this.GetComponent<Animator>().SetInteger("IdleTo", -1);
        }
        [SerializeField]
        private AudioSource audioSource;
        public List<AudioClip> audioClips = new List<AudioClip>();
        public void PlayAudio(int index)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }

        public void StartAttack()
        {
            col.enabled = true;
        }

        public void EndAttack()
        {
            if (col.enabled)
                col.enabled = false;
        }
    }
}
