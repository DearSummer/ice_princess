using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState : MonoBehaviour {
    public enum monsterState { wait = 0,search =1 , attack =2, beattack =3};
    public monsterState monsterStatus = monsterState.wait;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
