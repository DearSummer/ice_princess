using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Golem
{
    public class SecondTaskSword : MonoBehaviour
    {
        public int damage = 10;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("MainCharacter") && other.name == "CharaGetHurt")
            {
                HurtData d = new HurtData(damage, this.gameObject);
                other.GetComponent<CharaHurtAble>().GetHurt(HurtType.Damage, d);
            }
        }
    }
}
