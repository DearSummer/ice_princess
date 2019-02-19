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
            player.transform.transform.position += player.transform.transform.forward * Time.deltaTime * 6;
        }

        public override void MyUpdate(Animator _ani)
        {

        }

        public override void PrepareEnter(Animator _ani)
        {
            player = GameObject.FindWithTag("Player");
            _ani.ResetTrigger("RunExit");
        }

        public override void PrepareExit(Animator _ani)
        {

        }
    }
}
