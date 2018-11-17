using UnityEngine;
using System.Collections;

public class RagdollBehaviour : MonoBehaviour {
    float impactEndTime = 0;
    Rigidbody impactTarget = null;
    Vector3 impact;
    RagdollHelper helper;

    public float minGetUpTime;
    public float maxGetUpTime;

    public ParticleSystem getUpParticles;

    float curGetUpTime;
    float curGetUpTimer;
    //public Animator animator;
    //public Rigidbody topLevelRigidBody;
    //Rigidbody[] rbs;
    // Use this for initialization
    void Start () {
        /*rbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = true;
            
        }
        topLevelRigidBody.isKinematic = false;*/

        //Get all the rigid bodies that belong to the ragdoll

        //Add the RagdollPartScript to all the gameobjects that also have the a rigid body
        helper = GetComponent<RagdollHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < impactEndTime)
        {
            impactTarget.AddForce(impact, ForceMode.VelocityChange);
        }
        if(helper.ragdolled)
        {
            curGetUpTimer += Time.deltaTime;
            if(curGetUpTimer > curGetUpTime)
            {
                getUpParticles.Play();
                helper.ragdolled = false;
            }
        }
    }

    public void Impact (Rigidbody rb,Vector3 direction)
    {
        //Debug.Log("Impact Registered");
        GameController.instance.ReportPedestrianCollission();
        impactTarget = rb;
        impact = direction * 2.0f;
        helper.ragdolled = true;
        impactEndTime = Time.time + 0.25f;
        curGetUpTimer = 0f;
        curGetUpTime = Random.Range(minGetUpTime, maxGetUpTime);
    }

    public bool isRagDolled()
    {
        return helper.ragdolled;
    }

    void OnCollisionEnter(Collision collision)
    {
       /* Debug.Log("Collision");
        //find the RagdollHelper component and activate ragdolling
        
        //set the impact target to whatever the ray hit
        impactTarget = collision.contacts[0].thisCollider.attachedRigidbody; 
        //impact direction also according to the ray
        impact = (collision.contacts[0].thisCollider.transform.position - collision.collider.transform.position).normalized * 2.0f;
        //the impact will be reapplied for the next 250ms
        */
    }
}
