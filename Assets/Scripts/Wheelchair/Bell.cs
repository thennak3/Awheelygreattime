using UnityEngine;
using System.Collections;

public class Bell : MonoBehaviour {

    // Use this for initialization

    public float Radius;
    public AudioSource soundToPlay;
    public LayerMask bellLayer;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            soundToPlay.Play();
            Collider[] colls = Physics.OverlapSphere(transform.position, Radius,bellLayer);
            MoveToLocation mov;
            foreach(Collider col in colls)
            {
                mov = col.GetComponent<MoveToLocation>();
                if(mov != null)
                {
                    mov.Move();
                }
            }

        }
	}
}
