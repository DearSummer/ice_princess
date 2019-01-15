using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

    private AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Play(float time)
    {
        if (audio.isPlaying) return;

        audio.Play();
        
        //audio.PlayScheduled(0.1f);
        Invoke("StopAudio", time);
    }
    public void Stop()
    {
        audio.Stop();
    }
    private void StopAudio()
    {
        audio.Stop();
    }
    
}
