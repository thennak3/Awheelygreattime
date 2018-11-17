using UnityEngine;
using System.Collections;
using System;

public class LiftCartButton : MonoBehaviour,IHasActions {

    public Lift liftScript;
    public void DoAction()
    {
        liftScript.useLiftButtonInternal();
    }

    public bool IsActive()
    {
        return false;
    }

    
}
