using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : MonoBehaviour {
    public int damage = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer + "   " + other.name);
        if(other.gameObject.layer == 12&&other.name == "CharaGetHurt")
        {
            HurtData d = new HurtData(damage, this.gameObject);
            other.GetComponent<CharaHurtAble>().GetHurt(HurtType.Damage, d);
        }
    }
}
