using UnityEngine;
using System.Collections;
using System;

public class Lift: MonoBehaviour, IHasActions {

    [Header("Animations")]
    public Animator topLiftDoorAnimator;
    public Animator bottomLiftDoorAnimator;
    public Animator cartAnimator;
    public string openDoorTrigger;
    public string closeDoorTrigger;

    public string sendCartDownTrigger;
    public string sendCartUpTrigger;


    bool bottomDoorClosed = true;
    bool topDoorClosed = true;
    public bool liftAtTop = true;

    [Header("Lift Timings")]
    public float cartTravelTime;
    public float cartTravelTimer;
    public float doorOpeningTime;
    bool canUseInternalButton = true;
    

    [Header("Player Clear Doors")]
    public Transform playerClearTopPoint;
    public Transform playerClearBottomPoint;
    public LayerMask playerBlockLayer;

    [Header("Lock Player During Movement")]
    public ApplydownForce lockPosition;

    public void DoAction()
    {
        throw new NotImplementedException();
    }

    public void useLiftButtonInternal()
    {
        if (canUseInternalButton)
        {
            if (liftAtTop)
            {
                topDoorClosed = CloseDoorTop();
                if (topDoorClosed)
                {
                    MoveCart();
                    canUseInternalButton = false;
                    cartTravelTimer = 0f;
                }
            }
            else
            {
                bottomDoorClosed= CloseDoorBottom();
                if (bottomDoorClosed)
                {
                    MoveCart();
                    canUseInternalButton = false;
                    cartTravelTimer = 0f;
                }
            }
        }
    }

    public bool IsActive()
    {
        if (!canUseInternalButton)
            return true;
        return false;
        
    }
    
    public void CallCart(bool top)
    {
        if(top)
        {
            if(liftAtTop && topDoorClosed && canUseInternalButton)
            {
                topLiftDoorAnimator.SetTrigger(openDoorTrigger);
                topDoorClosed = false;
            }
            else if(!liftAtTop)
            {
                
                useLiftButtonInternal();
            }
        }
        else
        {
            if (!liftAtTop && bottomDoorClosed && canUseInternalButton)
            {
                bottomLiftDoorAnimator.SetTrigger(openDoorTrigger);
                bottomDoorClosed = false;
            }
            else
            {
                useLiftButtonInternal();
            }
        }
    }

    public bool CloseDoorTop()
    {
        Ray ray = new Ray(playerClearTopPoint.position, playerClearTopPoint.forward);
        if (Physics.Raycast(ray, 2, playerBlockLayer))
            return false;

        topLiftDoorAnimator.SetTrigger(closeDoorTrigger);
        //topDoorClosed = true;
        return true;
    }

    public bool CloseDoorBottom()
    {
        Ray ray = new Ray(playerClearBottomPoint.position, playerClearBottomPoint.forward);
        if (Physics.Raycast(ray, 2, playerBlockLayer))
            return false;

        bottomLiftDoorAnimator.SetTrigger(closeDoorTrigger);
        //bottomDoorClosed = true;
        return true;
    }

    public void MoveCart()
    {

        if (liftAtTop)
        {
            cartAnimator.SetTrigger(sendCartDownTrigger);
            liftAtTop = false;
        }
        else
        {
            cartAnimator.SetTrigger(sendCartUpTrigger);
            liftAtTop = true;
        }
        if(lockPosition.isActive)
        {
            StaticWheelChairReference.instance.parent = lockPosition.transform;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(cartTravelTimer < cartTravelTime)
        {
            cartTravelTimer += Time.deltaTime;
            if (cartTravelTimer > cartTravelTime)
            {
                if (liftAtTop)
                    topLiftDoorAnimator.SetTrigger(openDoorTrigger);
                else
                    bottomLiftDoorAnimator.SetTrigger(openDoorTrigger);
                canUseInternalButton = true;
                StaticWheelChairReference.instance.parent = null;
            }
        }


	}

}
