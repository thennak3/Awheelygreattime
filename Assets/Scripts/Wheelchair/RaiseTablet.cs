using UnityEngine;
using System.Collections;

public class RaiseTablet : MonoBehaviour {

    // Use this for initialization
    public bool tabletRaised = false;

    public string tabletUpTrigger;
    public string tabletDownTrigger;
    public Animator tabletAnimator;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.T))
        {
            if (tabletRaised)
                tabletAnimator.SetTrigger(tabletDownTrigger);
            else
                tabletAnimator.SetTrigger(tabletUpTrigger);
            tabletRaised = !tabletRaised;

        }
	}
}
