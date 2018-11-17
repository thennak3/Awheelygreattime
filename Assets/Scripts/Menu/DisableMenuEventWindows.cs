using UnityEngine;
using System.Collections;

public class DisableMenuEventWindows : MonoBehaviour {
    public Canvas menuCanvas;
    public CardboardReticle cbr;
    // Use this for initialization

    public SwitchModes turnOffVR;
	void Start () {
	    if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            //menuCanvas.worldCamera = null;
            //cbr.enabled = false;
            turnOffVR.TurnOffVR();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
