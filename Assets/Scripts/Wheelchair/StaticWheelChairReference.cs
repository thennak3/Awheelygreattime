using UnityEngine;
using System.Collections;

public class StaticWheelChairReference : MonoBehaviour {
    public static Transform instance;
	// Use this for initialization
	void Awake () {
        if(instance == null)
            instance = transform;
	}
	
	// Update is called once per frame
	
}
