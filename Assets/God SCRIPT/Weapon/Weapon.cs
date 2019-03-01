using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int damage = 20;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Get");
       if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")&&other.name == "HpSystem")
       {
            HurtData d = new HurtData(damage, this.gameObject);
            other.GetComponent<HurtAble>().GetHurt(HurtType.Damage, d);
       }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        //{
        //    HurtData d = new HurtData(damage, this.gameObject);

        //    collision.gameObject.GetComponentInChildren<HurtAble>().GetHurt(HurtType.Damage, d);
        //}
    }
}
