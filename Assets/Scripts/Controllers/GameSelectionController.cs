using UnityEngine;
using System.Collections;

public class GameSelectionController : MonoBehaviour {

    public Transform mainCamera;

    public float rayCastDistance = 4;

    public LayerMask interactionLayer;

    IPlayerInteractive lastSelected;

    public static GameSelectionController instance;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
        
	}

    // Update is called once per frame
    Ray rayCache;
    void Update () {
        rayCache = new Ray(mainCamera.position, mainCamera.forward);
        RaycastHit ray;
        //Debug.DrawRay(mainCamera.position, mainCamera.forward, Color.red, 1.0f);
        if(Physics.Raycast(rayCache, out ray, rayCastDistance, interactionLayer))
        {
            IPlayerInteractive hit;
            hit = ray.collider.GetComponent<IPlayerInteractive>();
            if (hit != lastSelected && lastSelected != null)
                lastSelected.LookAway();
            lastSelected = hit;
            hit.LookAt();
            //Debug.Log("Hit Interactive Collider");
                
        }
        else
        {
            if (lastSelected != null)
            {
                lastSelected.LookAway();
                lastSelected = null;
            }
        }

	}

    public IPlayerInteractive currentInteractable()
    {
        return lastSelected;
    }

    public void InputPressed()
    {
        if (lastSelected != null)
            lastSelected.Use();
    }
}
