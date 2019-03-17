using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MonsterScript.Fsm
{
    public class SearchEnemy : MonoBehaviour
    {
        private GameObject Target;
        [SerializeField]
        private FinalMachine FinFsm;
        [SerializeField]
        private GameObject My;
        private float TimeLock = 0.5f;
        private void Start()
        {
            Target = GameObject.Find("character");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "ForSearch")
                FinFsm.TranslateToRun();
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "ForSearch")
                FinFsm.TranslateToIdle();
        }
        private void OnTriggerStay(Collider other)
        {
            if((TimeLock-=Time.deltaTime*2f)<0)
            {
                TimeLock = 0.5f;
                Vector3 dir = -My.transform.position + new Vector3(Target.transform.position.x, My.transform.position.y, Target.transform.position.z);
                My.transform.LookAt(My.transform.position + dir);
            }
        }
    }
}
