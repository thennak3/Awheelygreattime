using UnityEngine;
using System.Collections;

public class Kitten : MonoBehaviour {


    public string[] kittenActions;
    public float minTime;
    public float maxTIme;
    public Animation kittyAnimator;
    bool doAnim;
	// Use this for initialization
	void Start () {
        Invoke("AnimTimer", Random.Range(minTime, maxTIme));
        foreach (string s in kittenActions)
        {
            GetComponent<Animation>()[s].layer = 1;
            GetComponent<Animation>()[s].wrapMode = WrapMode.Once;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (doAnim)
        {
            doAnim = false;

            kittyAnimator.Play(kittenActions[(int)Random.Range(0, kittenActions.Length)]);
                
                //SetTrigger();
        }
        if (!kittyAnimator.isPlaying)
            kittyAnimator.Play("Idle");
	}

    void AnimTimer()
    {
        doAnim = true;
        Invoke("AnimTimer", Random.Range(minTime, maxTIme));
    }
}
