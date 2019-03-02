using MagicalFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMagicEvent : MonoBehaviour {
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private GameObject magicOne;
    [SerializeField]
    private AudioSource audioSource;
	// Use this for initialization
	public void MagicOne()
    {
        GameObject temp = GameObject.Instantiate(magicOne);
        temp.transform.parent = null;
        temp.transform.position = Target.transform.position + Vector3.up * 10f;
        audioSource.Play();
    }
}
