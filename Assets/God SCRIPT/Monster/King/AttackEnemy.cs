using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
public class AttackEnemy : MonoBehaviour {
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private FinalMachine FinFsm;
    private void OnTriggerEnter(Collider other)
    {
        FinFsm.TranslateToAttack();
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        FinFsm.TranslateToIdle();
    }
}
