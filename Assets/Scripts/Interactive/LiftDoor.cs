using UnityEngine;
using System.Collections;
using System;

public class LiftDoor : MonoBehaviour,IHasActions {

    public Lift liftScript;
    public bool isTopButton = true;
    public void DoAction()
    {
        liftScript.CallCart(isTopButton);
    }

    public bool IsActive()
    {
        //throw new NotImplementedException();
        return false;
    }


}
