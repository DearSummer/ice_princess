using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
using GameInfo;

public class SpceTrans : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ForSearch"&&this.gameObject.name == "Cube-Parent")
        {
            Destroy(this.gameObject);
            GameObject.Find("GameInfo").GetComponent<GameInfomation>().SaveScenceInformation(1);
        }
        else if (other.name == "ForSearch" && this.gameObject.name == "Cube-Child")
        {

            GameObject.Find("GameInfo").GetComponent<GameInfomation>().LoadScenceInfomation();
        }
    }
}
