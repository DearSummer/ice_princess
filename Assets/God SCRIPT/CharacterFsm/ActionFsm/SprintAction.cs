using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionSpace
{
    public class SprintAction : BaseFsm
    {
        private GameObject player;

        public override void MyFixUpdate(Animator _ani)
        {
            player.transform.transform.position += player.transform.transform.forward * Time.deltaTime * 5;
            _ani.ResetTrigger("Run");
        }

        public override void MyUpdate(Animator _ani)
        {

        }

        public override void PrepareEnter(Animator _ani)
        {
            player = GameObject.FindWithTag("Player");
            _ani.SetTrigger("Run");
        }

        public override void PrepareExit(Animator _ani)
        {
            _ani.ResetTrigger("Run");
        }
    }
}
