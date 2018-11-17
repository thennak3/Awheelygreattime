using UnityEngine;
using System.Collections;

public class SetHeadToCameraRotation : MonoBehaviour {

    public Transform headTransform;
	
	// Update is called once per frame
	void Update () {
        
        
        headTransform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0,-90,-90));
	}
}
