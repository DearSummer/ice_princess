using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
public class AttackEnemy : MonoBehaviour {
    private GameObject Target;
    [SerializeField]
    private FinalMachine FinFsm;
    [SerializeField]
    private GameObject My;
    private void Start()
    {
        Target = GameObject.Find("character");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ForSearch")
        {
            FinFsm.TranslateToAttack();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(FinFsm.currentFsm!=FinFsm.AttackFsm)
        {
            StartCoroutine(Trans());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ForSearch")
        {
            FinFsm.TranslateToRun();
        }
    }
    IEnumerator Trans()
    {
        yield return new WaitForSeconds(1f);
        FinFsm.TranslateToAttack();
    }
}
