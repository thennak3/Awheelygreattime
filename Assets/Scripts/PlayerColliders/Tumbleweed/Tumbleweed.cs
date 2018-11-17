using UnityEngine;
using System.Collections;

public class Tumbleweed : MonoBehaviour {

    // Use this for initialization
    public float minDirectionChange = 5f;
    public float maxDirectionChange = 20f;
    float timer;
    float time = 5f;
    Rigidbody rb;
    public float force;
    Vector3 forceDirection = Vector3.zero;

    public float minJumpTime = 2f;
    public float maxJumpTime = 3f;
    float jumpTime = 5f;
    float jumpTimer = 0f;
    public float jumpForceMin;
    public float jumpForceMax;
	void Start () {
        timer = 0f;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;
        jumpTimer += Time.deltaTime;
        if(timer>time)
        {
            forceDirection = Random.insideUnitSphere;
            timer = 0f;
            time = Random.Range(minDirectionChange, maxDirectionChange);
        }
        if(jumpTimer>jumpTime)
        {
            rb.AddForce(Vector3.up * Random.Range(jumpForceMin, jumpForceMax), ForceMode.Impulse);
            jumpTimer = 0f;
            jumpTime = Random.Range(minJumpTime, maxJumpTime);
        }
        rb.AddTorque(forceDirection * force);
	}
}
