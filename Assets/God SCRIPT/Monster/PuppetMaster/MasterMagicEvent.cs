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
    private GameObject magicTwo;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioOne;
    [SerializeField]
    private AudioClip audioTwo;
	// Use this for initialization
	public void MagicOne()
    {
        GameObject temp = GameObject.Instantiate(magicOne);
        temp.transform.parent = null;
        temp.transform.position = Target.transform.position + Vector3.up * 10f;
        audioSource.clip = audioOne;
        audioSource.Play();
    }
    public void MagicTwo()
    {
        GameObject temp = GameObject.Instantiate(magicTwo);
        temp.transform.parent = null;
        temp.transform.position = Target.transform.position;
        audioSource.clip = audioTwo;
        audioSource.Play();
    }
}
