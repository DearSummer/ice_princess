using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

    public GameObject target;
	// Use this for initialization
	void Start () {
        //target = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        ToCamera();
	}
    private void ToCamera()
    {
        Vector3 temptaget = new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(temptaget - transform.position), 5 * Time.deltaTime);
    }
}
