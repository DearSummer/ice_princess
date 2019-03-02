using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
public class AttackEnemy : MonoBehaviour {
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private FinalMachine FinFsm;
    [SerializeField]
    private GameObject My;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ForSearch")
        {
            FinFsm.TranslateToAttack();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Vector3 dir = -My.transform.position + new Vector3(Target.transform.position.x, My.transform.position.y, Target.transform.position.z);
        My.transform.LookAt(My.transform.position + dir);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ForSearch")
        {
            FinFsm.TranslateToIdle();
        }
    }
}
