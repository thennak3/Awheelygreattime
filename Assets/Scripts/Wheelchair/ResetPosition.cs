using UnityEngine;
using System.Collections;

public class ResetPosition : MonoBehaviour {

    public static ResetPosition instance;
    public Transform resetee;
    public Vector3 addPosition;

    public float resetCooldownTime = 2.0f;
    public float resetCooldownTimer = 0f;
    // Update is called once per frame
    public bool isDead = false;

    public Transform resetPosition;

    void Start()
    {
        if(instance == null)
            instance = this;
    }
	void Update () {

        if (resetCooldownTimer < resetCooldownTime)
            resetCooldownTimer += Time.deltaTime;
        if(resetCooldownTimer > resetCooldownTime)
        {
            if(Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                if (resetPosition == null)
                    resetee.transform.position += addPosition;
                else
                    resetee.transform.position = resetPosition.position;
                resetee.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                resetee.GetComponent<Rigidbody>().velocity = Vector3.zero;
                resetCooldownTimer = 0f;
                isDead = false;
                GameController.instance.ReportReset();
            }
        }
	}

    public void SetResetPosition(Transform t)
    {
        resetPosition = t;
    }

    public void ClearResetPosition()
    {
        resetPosition = null;
    }

}
