// Patrol.cs
using UnityEngine;
using System.Collections;


public class PatrolWalkScript : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;
    Animator anim;
    public float remainingDistance = 0.5f;
    Rigidbody rb;

    public bool repeatPath = true;
    public bool finished = false;
    public bool runOnce = false;
    public RagdollHelper rdh;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
        // Don’t update position automatically
        // agent.updatePosition = false;
        rb = GetComponent<Rigidbody>();
        rdh = GetComponent < RagdollHelper >();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        if (!repeatPath)
            if (destPoint + 1 == points.Length && runOnce)
            {
                agent.Stop();
                //agent.enabled = false;
                finished = true;
                return;
            }
        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        runOnce = true;
        destPoint = (destPoint + 1) % points.Length;
    }
    void OnAnimatorMove()
    {
        // Update position based on animation movement using navigation surface height
        Vector3 position = anim.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (rdh != null)
            if (rdh.ragdolled)
            {
                //Debug.Log("Ragdolled");
                //agent.Stop();
                agent.enabled = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                return;
            }
        if (!agent.enabled)
        {
            agent.enabled = true;
            agent.Resume();
        }
        if (agent.remainingDistance < remainingDistance)
            GotoNextPoint();



        // Update animation parameters
        if (!finished)
        {
            anim.SetBool("move", true);
            //anim.SetFloat("velx", );
            anim.SetFloat("velx", rb.velocity.magnitude);
            anim.SetFloat("vely", rb.angularVelocity.magnitude);
        }
        else
        {
            anim.SetBool("move", false);
        }

        //anim.SetFloat("vely", agent.velocity.y);

        //GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;
    }
}