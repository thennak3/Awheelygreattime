using UnityEngine;
using System.Collections;

public class FallDetector : MonoBehaviour {
    Rigidbody rb;
    // Use this for initialization
    bool triggered;
    public float triggerOnVelocity;

    public AudioSource wilheimScream;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float yvel = Mathf.Abs(rb.velocity.y);
        if (yvel > triggerOnVelocity && !triggered)
        {
            wilheimScream.Play();
            if (!ResetPosition.instance.isDead)
                ResetPosition.instance.isDead = true;
            triggered = true;
        }
        else if(yvel < triggerOnVelocity && triggered)
        {
            triggered = false;
            GameController.instance.ReportFalls();
        }
        //Debug.Log(rb.velocity.y);
	}
}
