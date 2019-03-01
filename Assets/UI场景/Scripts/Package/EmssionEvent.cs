using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmssionEvent : MonoBehaviour {
    public GameObject playButton;
    private float PBalpha=1;
    public GameObject content;
    private float Calpha=0;
    public GameObject FinishButton;
    private float FBalpha;
	// Use this for initialization
	void Start () {
        content.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        playButton.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(playButton.GetComponent<CanvasGroup>().alpha, PBalpha,0.02f);
        FinishButton.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(FinishButton.GetComponent<CanvasGroup>().alpha, FBalpha, 0.02f);
        content.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(content.GetComponent<CanvasGroup>().alpha, Calpha, 0.02f);

    }
    public void PlayButtonDown()
    {
        PBalpha = 0f;
        FBalpha = 0f;
        content.SetActive(true);
        Calpha = 1f;
    }
    public void BackButtonDown()
    {
        PBalpha = 1f;
        FBalpha = 0f;
        Calpha = 0f;
        StartCoroutine(Display(0.5f));
    }
    IEnumerator  Display(float second)
    {
        yield return  new WaitForSeconds(second);
        content.SetActive(false);
    }
}
