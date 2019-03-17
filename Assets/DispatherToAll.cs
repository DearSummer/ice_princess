using GameInfo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatherToAll : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GameObject.Find("GameInfo").GetComponent<GameInfomation>().ResetScence();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
