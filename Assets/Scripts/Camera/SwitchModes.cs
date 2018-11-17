using UnityEngine;
using System.Collections;

public class SwitchModes : MonoBehaviour {

    public CardboardHead headScript;
    public Cardboard cardboardScript;
    public FirstPersonCam fpc;
    public bool cardboardOn = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.Joystick1Button4) )
        {
            TurnOffVR();
        }
	}

    public void TurnOffVR()
    {
        if (cardboardOn)
        {
            cardboardScript.VRModeEnabled = false;
            headScript.trackRotation = false;
            fpc.enabled = true;
        }
        else
        {
            cardboardScript.VRModeEnabled = true;
            headScript.trackRotation = true;
            fpc.enabled = false;
        }

        cardboardOn = !cardboardOn;
    }
}
