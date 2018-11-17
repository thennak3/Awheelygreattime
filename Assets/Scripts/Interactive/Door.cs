using UnityEngine;
using System.Collections;
using System;

public class Door : MonoBehaviour,IHasActions {

    public bool doorIsOpen = false;
    public Animator doorAnimator;

    public string doorTriggerOpen;
    public string doorTriggerClose;

    public float doorSpeed;

    public AudioSource doorMovement;

    public void DoAction()
    {
        doorAnimator.SetFloat("Speed", doorSpeed);
        if(doorIsOpen)
        {
            doorAnimator.SetTrigger(doorTriggerClose);
            if(doorMovement !=null)
            doorMovement.Play();
        }
        else
        {
            doorAnimator.SetTrigger(doorTriggerOpen);
            if (doorMovement != null)
                doorMovement.Play();
        }
        doorIsOpen = !doorIsOpen;
    }

    public bool IsActive()
    {
        if (doorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !doorAnimator.IsInTransition(0))
            return true;
        return false;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
