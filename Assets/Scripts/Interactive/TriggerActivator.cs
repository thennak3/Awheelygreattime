using UnityEngine;
using System.Collections;

public class TriggerActivator : MonoBehaviour {

    public GameObject objectToActivate;
    IHasActions actionableObject;

    // Use this for initialization

    void Start()
    {
        actionableObject = objectToActivate.GetComponent<IHasActions>();
    }



    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            actionableObject.DoAction();
            Debug.Log("Tripped Enter");
        }
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            actionableObject.DoAction();
            Debug.Log("Tripped Exit");
        }
    }


}
