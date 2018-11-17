using UnityEngine;
using System.Collections;

public class PickupObjectiveController : MonoBehaviour {

    public static PickupObjectiveController instance;

    public string textOnceFinished;
	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
	}

    // Update is called once per frame
    /*void Update () {
	    
	}*/
    public GameObject activateOnComplete;
    public int collectables = 1;
    public void PickupCollected()
    {
        collectables -= 1;
        if (collectables == 0)
        {
            activateOnComplete.SetActive(true);
            GUIController.instance.SetObjectiveText(textOnceFinished);
        }
        GUIController.instance.SetObjectivesRemaining(collectables);
        
    }

}
