using UnityEngine;
using System.Collections;

public class MenuMovement : MonoBehaviour {

    public Animator wheelChairAnimator;

    public string[] animations;

    public float minTimeForAnimation;
    public float maxTimeForAnimation;
    float nextAnimation;

    bool pickNewAnimation = true;
    string animationPicked;

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
	    if(pickNewAnimation)
        {
            animationPicked = animations[(int)Random.Range(0f, animations.LongLength)];
            nextAnimation = Random.Range(minTimeForAnimation, maxTimeForAnimation);
            Invoke("DoAnimation", nextAnimation);
            pickNewAnimation = false;
        }
	}

    void DoAnimation()
    {
        pickNewAnimation = true;
        wheelChairAnimator.SetTrigger(animationPicked);
    }
}
