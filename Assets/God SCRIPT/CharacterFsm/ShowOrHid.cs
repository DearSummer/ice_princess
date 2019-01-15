using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrHid : MonoBehaviour {
    [SerializeField]
    public GameObject LevitatedSword;
    public GameObject HandlerSword;
    public GameObject LevitatedSwordRight;
    public GameObject HandlerSwordRight;
    public void DisPlay(GameObject target,bool OpenOrClose)
    {
        if (OpenOrClose == false)
        {
            target.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(Init1(target, OpenOrClose));
        }
        else if (OpenOrClose == true)
        {
            target.GetComponent<MeshRenderer>().enabled = true;
            target.SetActive(true);
        }

    }
    IEnumerator Init1(GameObject target,bool OorC)
    {
        yield return new WaitForSeconds(50);//
        target.SetActive(false);
    }
    public void DesObject(GameObject target)
    {
        target.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(Init2(target));
    }
    IEnumerator Init2(GameObject target)
    {
        yield return new WaitForSeconds(5);//
        GameObject.Destroy(target);
    }
    // Use this for initialization
}
