using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour {

    public float rotationSpeed;
    public AudioSource pickupSound;
    public AudioSource firework;
    public ParticleSystem flasher;
    public ParticleSystem pickupParticle;
    public bool activatesItem;
    
    public GameObject activates;
    bool spent = false;

    public bool deactivateOnPickup;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
	}

    void OnTriggerEnter(Collider col)
    {
        if(!spent)
        {
            spent = true;
            PickupObjectiveController.instance.PickupCollected();
            if (activatesItem)
                activates.SetActive(true);

            if (pickupSound != null)
                pickupSound.Play();

            if(GetComponent<MeshRenderer>() != null)
                GetComponent<MeshRenderer>().enabled = false;

            if (pickupSound != null)
            {
                pickupSound.Play();
                Debug.Log("Played sound");
            }

            if(firework !=null)
                firework.Play();

            if(flasher!= null)
                flasher.Stop();

            if(pickupParticle !=null)
                pickupParticle.Play();

            if (deactivateOnPickup)
                gameObject.SetActive(false);
        }
    }
}
