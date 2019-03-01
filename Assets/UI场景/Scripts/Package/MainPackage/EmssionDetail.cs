using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmssionDetail : MonoBehaviour {
    public Text detail;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void EmssionDetailChange(string content)
    {
        detail.text = content;
        this.GetComponent<CanvasGroup>().alpha = 1;
    }
}
