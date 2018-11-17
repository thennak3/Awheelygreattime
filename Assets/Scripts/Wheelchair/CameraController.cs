using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Camera[] cameras;
    public int cameranum;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.C))
        {
            cameras[cameranum].enabled = false;
            if (cameranum + 1 > cameras.Length - 1)
                cameranum = 0;
            else
                cameranum += 1;
            cameras[cameranum].enabled = true;

        }
	}
}
