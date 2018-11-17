using UnityEngine;
using System.Collections;
/// <summary>
/// This script should be used for dialog as well as clicking on things for input
/// </summary>
public class InputController : MonoBehaviour {


    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Return))
        {
            if (!GameController.instance.endLevel)
            {
                //Debug.Log("Button Pressed");
                if (DialogController.instance.activeDialog)
                    DialogController.instance.InputPressed();
                else if (GameSelectionController.instance.currentInteractable() != null)
                    GameSelectionController.instance.InputPressed();
            }
            else
            {
                Application.LoadLevel(0);
            }
        }                       
	}
}
