using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : MonoBehaviour {
    public GameObject _center;
    public GameObject camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _center.transform.Rotate(Vector3.up, CharacterInput.Instance.CamerVector.x *50 * Time.deltaTime);

        camera.transform.position = this.transform.position;
        camera.transform.LookAt(_center.transform);
	}
}
