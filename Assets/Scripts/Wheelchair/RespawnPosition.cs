using UnityEngine;
using System.Collections;

public class RespawnPosition : MonoBehaviour {


    public bool clearPosition = false;
    void OnTriggerEnter(Collider col)
    {
        if(clearPosition)
        {
            ResetPosition.instance.ClearResetPosition();
        }
        else
        {
            ResetPosition.instance.SetResetPosition(transform);
        }
    }

}
