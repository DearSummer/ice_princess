using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    public int damage = 0;
    public LayerMask targetLayer;

    private GameObject master;

    public void SetMaster(GameObject m)
    {
        master = m;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer & (1 << targetLayer.value)) != 0 && other.gameObject != master)
        {
            DamageData data = new DamageData();
            data.damage = damage;
            data.sender = gameObject;

            Damageable d = other.GetComponent<Damageable>();
            if (d != null)
                d.TryGetHurt(data);
         
        }
    }





}
