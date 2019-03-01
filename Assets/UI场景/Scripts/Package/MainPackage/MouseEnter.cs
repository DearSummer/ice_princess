using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject pannel;
    private Vector3 target = Vector3.zero;
    private float scale = 1.2f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        pannel = this.transform.Find("pannel").gameObject;
        target = new Vector3(0, 0, 0); 
        this.transform.Find("pannel").localPosition = new Vector3(-155, 0, 0);
        scale = 1.2f;
        pannel.GetComponent<Image>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        target = new Vector3(-155, 0, 0);
        pannel.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        pannel.transform.localScale = new Vector3(1, 1, 1);
        this.transform.localScale = new Vector3(1, 1, 1);
        //this.transform.Find("pannel").localPosition = new Vector3(0, 0, 0);
        pannel.GetComponent<Image>().enabled = false;
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(pannel!=null)
        {
            pannel.transform.localPosition = Vector3.Lerp(pannel.transform.localPosition, target, Time.deltaTime * 5f);
            //this.transform.localScale = Vector3.Lerp(pannel.transform.localScale, new Vector3(scale, scale, scale), Time.deltaTime * 5f);
            //pannel.transform.localScale = Vector3.Lerp(pannel.transform.localScale, new Vector3(scale, scale, scale), Time.deltaTime * 5f);
        }
    }
}
