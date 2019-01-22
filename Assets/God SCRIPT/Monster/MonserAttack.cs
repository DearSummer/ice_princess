using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonserAttack : MonoBehaviour {
    [SerializeField]
    private Animator ani;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 && other.gameObject.tag == "Player")
        {
            ani.SetBool("Move", false);
            ani.SetBool("Attack 01", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9 && other.gameObject.tag == "Player")
        {
            ani.SetBool("Move", true);
            ani.SetBool("Attack 01", false);
        }
    }
}
