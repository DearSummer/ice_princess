using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmssionItem : MonoBehaviour {
    public GameObject detail;
    public Text discribe;
    public void InitEmssion(string dis)
    {

    }
    public void DetailShow()
    {
        detail = GameObject.Find("EmssionDetailContent");
        detail.GetComponent<EmssionDetail>().EmssionDetailChange("痛苦记忆：背叛，我为什么会被你背叛啊");
    }
}
