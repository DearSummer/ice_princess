using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMotionHandler : MonoBehaviour {

    private Animator _animtor;

    public ControlFsm cfsm;

	// Use this for initialization
	void Start () {
        _animtor = GetComponent<Animator>();
	}

    private void OnAnimatorMove()
    {
        cfsm.AnimationMove(_animtor.deltaPosition);
    }
}
