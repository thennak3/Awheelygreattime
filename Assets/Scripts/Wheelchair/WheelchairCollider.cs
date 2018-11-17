using UnityEngine;
using System.Collections;

public class WheelchairCollider : MonoBehaviour {

    // Use this for initialization
    public int pedestrianLayer;
    public int wallLayer;
    public int painLayer;


    Rigidbody rb;

    public AudioSource pedestrianHit;
    
    public AudioClip[] pedestrianHitClips;

    public AudioSource objectHit;
    public AudioClip[] objectHitClips;

    public AudioSource splatHit;
    public AudioClip[] splatHitClips;

    public float objectHitCooldownTime = 0.2f;
    public float objectHitCooldownTimer = 0.2f;

    public float painForce;
    public AudioSource painHit;
    public AudioClip[] painHitClips;

    public float painHitCooldownTime = 0.2f;
    public float painHitCooldownTimer = 0.2f;

    
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (objectHitCooldownTimer <= objectHitCooldownTime)
            objectHitCooldownTimer += Time.deltaTime;
        if (painHitCooldownTimer <= painHitCooldownTime)
            painHitCooldownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        
        GameObject go = collision.collider.gameObject;


        if (go.layer == pedestrianLayer)
        {
            //Debug.Log("Hit a pedestrian");
            //lets get the ragdoll helper script

            Transform top = go.transform;
            while (top.parent != null)
                top = top.parent;

            RagdollBehaviour rdh = top.GetComponentInParent<RagdollBehaviour>();

            if (rdh != null)
                if (!rdh.isRagDolled())
                {
                    rdh.Impact(collision.collider.attachedRigidbody, (collision.contacts[0].thisCollider.transform.position - collision.collider.transform.position).normalized * rb.velocity.magnitude);
                    pedestrianHit.transform.position = collision.contacts[0].point;
                    pedestrianHit.PlayOneShot(pedestrianHitClips[(int)Random.Range(0, pedestrianHitClips.Length)]);
                }
        }
        else if (go.layer == wallLayer && objectHitCooldownTimer > objectHitCooldownTime)
        {
            GameController.instance.ReportWallCollission();
            objectHit.transform.position = collision.contacts[0].point;
            objectHit.PlayOneShot(objectHitClips[(int)Random.Range(0, objectHitClips.Length)]);
            objectHitCooldownTimer = 0f;
            //Debug.Log((int)Random.Range(0, objectHitClips.Length));
        }
        else if (go.layer == painLayer && painHitCooldownTimer > painHitCooldownTime)
        {
            GameController.instance.ReportWallCollission();
            painHit.PlayOneShot(painHitClips[(int)Random.Range(0, painHitClips.Length)]);
            painHitCooldownTimer = 0f;
            //Debug.Log("pain hit");
        }
        if(ResetPosition.instance.isDead)
        {
            splatHit.transform.position = collision.contacts[0].point;
            splatHit.PlayOneShot(splatHitClips[(int)Random.Range(0, splatHitClips.Length)]);
            rb.AddExplosionForce( painForce, collision.collider.transform.position,5,0.1f,ForceMode.VelocityChange);
            //objectHitCooldownTimer = 0f;
        }
    }

}
