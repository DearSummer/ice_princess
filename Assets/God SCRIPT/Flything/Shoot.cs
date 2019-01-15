using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject shootModel;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        shootModel.transform.position += shootModel.transform.up * Time.deltaTime*10;
        if (Input.GetMouseButtonDown(1))
        {
            shootModel.transform.position = this.transform.position;
        }
	}
}
