using UnityEngine;
using System.Collections;

public class ApplydownForce : MonoBehaviour {
    public float distance;
    public float forcePerUpdate;
    public bool isActive = false;
    Rigidbody wheelchairRB;
    Transform transformCache;
	// Use this for initialization
	void Start () {
        wheelchairRB = StaticWheelChairReference.instance.GetComponent<Rigidbody>();
        transformCache = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ((transformCache.position - StaticWheelChairReference.instance.position).magnitude < distance)
        {
            wheelchairRB.AddForce(-Vector3.up * forcePerUpdate);
            isActive = true;
        }
        else
            isActive = false;
	}
}
