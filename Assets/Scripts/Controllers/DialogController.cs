using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour {

    public static DialogController instance;
    public bool activeDialog = false;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InputPressed()
    {
        //Do things
    }


}
