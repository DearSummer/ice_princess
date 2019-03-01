using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MonsterScript.Fsm
{
    public class SearchEnemy : MonoBehaviour
    {
        [SerializeField]
        private GameObject Target;
        [SerializeField]
        private FinalMachine FinFsm;
        [SerializeField]
        private GameObject My;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            FinFsm.TranslateToRun();
        }
        private void OnTriggerExit(Collider other)
        {
            FinFsm.TranslateToIdle();
        }
        private void OnTriggerStay(Collider other)
        {
            Vector3 dir =- My.transform.position + new Vector3(Target.transform.position.x,My.transform.position.y, Target.transform.position.z);
            Debug.DrawRay(My.transform.position, dir, Color.blue);
            My.transform.LookAt(My.transform.position + dir);
            
        }
    }
}
