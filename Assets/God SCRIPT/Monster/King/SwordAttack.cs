using System.Collections;
using System.Collections.Generic;
using MonsterScript.Fsm;
using UnityEngine;

public class SwordAttack : MonoBehaviour {
    public int damage = 20;

    private MonsterEvent monsterEvent;

    private void Start()
    {
        monsterEvent = GetComponentInParent<MonsterEvent>();
    }

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("MainCharacter") && other.name == "CharaGetHurt")
        {
            HurtData d = new HurtData(damage, this.gameObject);
            monsterEvent.EndAttack();
            other.GetComponent<CharaHurtAble>().GetHurt(HurtType.Damage, d);
        }
    }
}
