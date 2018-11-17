using UnityEngine;
using System.Collections;

public class MoveToLocation : MonoBehaviour {

    // Use this for initialization

    PatrolWalkScript walkScript;
    UnityEngine.AI.NavMeshAgent navAgent;
    public bool hasMoved = false;
    public Transform moveToLocation;


	void Start () {
        walkScript = GetComponent<PatrolWalkScript>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Move()
    {
        if(!hasMoved)
        {
            walkScript.enabled = true;
            if (navAgent != false)
                navAgent.enabled = true;
        }
    }
}
