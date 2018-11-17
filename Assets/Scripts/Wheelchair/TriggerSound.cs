using UnityEngine;
using System.Collections;

public class TriggerSound : MonoBehaviour {
    public AudioSource soundTrigger;
    
    void Update()
    {
        
    }
	// Use this for initialization
	void OnTriggerEnter(Collider col)
    {
        if(!soundTrigger.isPlaying)
            soundTrigger.Play();
    }
}
