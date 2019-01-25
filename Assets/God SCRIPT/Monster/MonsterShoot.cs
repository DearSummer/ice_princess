using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour {
    [SerializeField]
    private Transform _center;

    private ShootBullet[] assembly;
	// Use this for initialization
	void Start () {
        assembly = gameObject.GetComponentsInChildren<ShootBullet>();
	}

    // Update is called once per frame
    private GameObject temp;
	void Update () {
    }
    private void LateUpdate()
    {
        this.transform.RotateAround(_center.transform.position, _center.transform.up, 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            for(int i = 0;i<assembly.Length-1;i++)
            {
                assembly[i].enabled = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            for (int i = 0; i < assembly.Length - 1; i++)
            {
                assembly[i].enabled = false;
            }
        }
    }
}
