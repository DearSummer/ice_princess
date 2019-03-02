using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.PuppetMaster
{
    public class MasterSearchForEnemy : MonoBehaviour
    {

        [SerializeField]
        private GameObject Target;
        [SerializeField]
        private MasterFinalFsm FinFsm;
        [SerializeField]
        private GameObject My;
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "ForSearch") { FinFsm.Translate(1); }
            
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "ForSearch") { FinFsm.Translate(0); }
        }
        private void OnTriggerStay(Collider other)
        {
            Vector3 dir = -My.transform.position + new Vector3(Target.transform.position.x, My.transform.position.y, Target.transform.position.z);
            Debug.DrawRay(My.transform.position, dir, Color.blue);
            My.transform.LookAt(My.transform.position + dir);

        }
    }
}
