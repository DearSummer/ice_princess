using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
namespace MonsterScript.Golem
{
    public class IceFinalFsm : MonoBehaviour
    {
        private BaseMonterFsm IdleFsm = new IceMonsterIdle();
        private Animator ani;
        [SerializeField]
        private AudioSource audioSource;
        // Use this for initialization
        void Start()
        {
            IdleFsm.PrepareEnter(ani, audioSource);
        }

        // Update is called once per frame
        void Update()
        {
            IdleFsm.MyUpdate();
        }
    }
}
