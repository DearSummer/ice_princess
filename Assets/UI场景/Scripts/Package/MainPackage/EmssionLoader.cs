using FairySpring.UI.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmssionLoader : MonoBehaviour {

    public GameObject content;
    public GameObject EmssionItem;

    // Use this for initialization
    void Start()
    {
        InitBagItem();
    }

    private void InitBagItem()
    {
        for (int i = 0; i < 20; i++)
        {
            LoadItem("Emssion");
        }
    }


    private void LoadItem(string discribe)
    {
        var item = GameObject.Instantiate(EmssionItem);
        item.transform.localPosition = new Vector3(0, 0, 0);
        item.GetComponent<EmssionItem>().InitEmssion(discribe);
        item.transform.SetParent(content.transform, false);
    }
}
