using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour {
    [SerializeField]
    private GameObject LookAt;
    [SerializeField]
    private GameObject _center;
    [SerializeField]
    private GameObject _follow;

    private Vector3 _distance;
	// Use this for initialization
	void Start () {
        _follow = GameObject.FindWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        MyUpdate();
	}
    private void FixedUpdate()
    {
        this.transform.position += _follow.GetComponent<ControlFsm>().GetDoitMove;
    }
    private void MyUpdate()
    {
        this.transform.RotateAround(_center.transform.position, _center.transform.up, CharacterInput.Instance.CamerVector.x*10);
        this.transform.LookAt(LookAt.transform);
    }
}
