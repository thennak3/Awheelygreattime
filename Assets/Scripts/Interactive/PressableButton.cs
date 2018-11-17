using UnityEngine;
using System.Collections;
using System;

public class PressableButton : MonoBehaviour, IPlayerInteractive {

    public ParticleSystem highlightedParticles;
    public GameObject actionableObject;
    IHasActions actionScript;
    public bool sendCommandIfActive = true;

    public ParticleSystem activatedParticles;
    public int activatedParticleEmitQuantity;

    public Animator pressableButtonAnimation;
    public string buttonAnimationTrigger;
    public float gazeTime;
    bool gazeDone = false;
    float gazeTimer;

    void Start()
    {
        actionScript = actionableObject.GetComponent<IHasActions>();
    }

    public void LookAt()
    {
        if(!highlightedParticles.isPlaying)
            highlightedParticles.Play();
        gazeTimer += Time.deltaTime;
    }

    public void LookAway()
    {
        if(highlightedParticles.isPlaying)
            highlightedParticles.Stop();
        gazeTimer = 0;
        gazeDone = false;
    }

    void Update()
    {
        if (gazeTimer > gazeTime && !gazeDone)
        {
            Use();
            gazeDone = true;
        }
    }

    public void Use()
    {
        if (!sendCommandIfActive && actionScript.IsActive())
            return;
        actionScript.DoAction();
        if (pressableButtonAnimation != null) 
            pressableButtonAnimation.SetTrigger(buttonAnimationTrigger);
        if (activatedParticles != null)
            activatedParticles.Emit(activatedParticleEmitQuantity);
    }

}
