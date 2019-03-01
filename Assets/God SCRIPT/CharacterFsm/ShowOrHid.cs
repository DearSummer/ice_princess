using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrHid : MonoBehaviour {
    [SerializeField]
    public GameObject LevitatedSword;
    public GameObject HandlerSword;
    public void DisPlay(GameObject target,bool OpenOrClose)
    {
        if (OpenOrClose == false)
        {
            StartCoroutine(Init1(target, OpenOrClose));
            target.GetComponent<MeshRenderer>().enabled = false;
            //target.GetComponent<Weapon>().enabled = false;
            
        }
        else if (OpenOrClose == true)
        {
            target.GetComponent<MeshRenderer>().enabled = true;
            //target.GetComponent<Weapon>().enabled = true;
            target.SetActive(true);
        }

    }
    IEnumerator Init1(GameObject target,bool OorC)
    {
        yield return new WaitForSeconds(100);//
        target.SetActive(false);
    }
    public void DesObject(GameObject target)
    {
        target.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(Init2(target));
    }
    IEnumerator Init2(GameObject target)
    {
        yield return new WaitForSeconds(2);//
        GameObject.Destroy(target);
    }
    // Use this for initialization
}
