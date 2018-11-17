using UnityEngine;
using System.Collections;

public class WheelchairMovementSound : MonoBehaviour {

    public AudioSource movementWindSound;
    public float minVel;
    public float maxVel;
    public float minVol;
    public float maxVol;


    public AudioClip[] movementClips;
    public AudioSource audioLeftWheel;
    public AudioSource audioRightWheel;
    public float minVelocityForMovement;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float vel = rb.velocity.magnitude;
        if (vel < minVel)
            movementWindSound.volume = 0f;
        else
        {

            float vol = Mathf.Clamp(maxVol * ((vel - minVel) / maxVel), minVol, maxVol);

            movementWindSound.volume = vol;
        }
        //Debug.Log(vel);
	}

    public void handMovementNoiseLeft()
    {
        if (rb.velocity.magnitude > minVelocityForMovement)
            audioLeftWheel.PlayOneShot(MovementAudioclip());
    }

    public void handMovementNoiseRight()
    {
        if (rb.velocity.magnitude > minVelocityForMovement)
            audioRightWheel.PlayOneShot(MovementAudioclip());
    }

    AudioClip MovementAudioclip()
    {
        return movementClips[(int)Random.Range(0, movementClips.Length)];
    }
}
