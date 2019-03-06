using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Golem
{

    public class Attack : MonoBehaviour
    {
        [SerializeField]
        private GolemEvent golemEvent;
        [SerializeField]
        private GameObject Target;
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "ForSearch")
            {
                golemEvent.TranslateToAttack();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "ForSearch")
            {
                golemEvent.TranslateToRun();
            }
        }
    }
}
