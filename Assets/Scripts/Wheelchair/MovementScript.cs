using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementScript : MonoBehaviour {
    public Transform visualRearRightWheel;
    public WheelCollider rearRightWheel;

    public Transform visualRearLeftWheel;
    public WheelCollider rearLeftWheel;

    public Transform visualFrontLeftWheel;
    public WheelCollider frontLeftWheel;

    public Transform visualFrontRightWheel;
    public WheelCollider frontRightWheel;

    public float maxMotorTorque;
    public float maxSteeringAngle;

    public Animator wheelChairArms;


   	// Use this for initialization

    public void KillMovement()
    {
        rearRightWheel.motorTorque = 0f;
        rearLeftWheel.motorTorque = 0f;
    }

    void FixedUpdate()
    {
        if (ResetPosition.instance.isDead)
            return;
        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float inputAmountLeft = 0;
        float inputAmountRight = 0;
        if(Input.GetAxis("LeftWheel") != 0f )
        {
            inputAmountLeft = Input.GetAxis("LeftWheel");
        }
        else if(Input.GetAxis("KeyLeftWheel") != 0f)
        {
            inputAmountLeft = Input.GetAxis("KeyLeftWheel") * -1;
        }
        
        if (Input.GetAxis("RightWheel") != 0f || Input.GetAxis("RightWheelPC") != 0f)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                inputAmountRight = Input.GetAxis("RightWheelPC");
            else
                inputAmountRight = Input.GetAxis("RightWheel");
        }
        else if (Input.GetAxis("KeyRightWheel") != 0f)
        {
            inputAmountRight = Input.GetAxis("KeyRightWheel") * -1;
        }


        float leftMotor = maxMotorTorque * inputAmountLeft;
        float rightMotor = maxMotorTorque * inputAmountRight;

        //frontLeftWheel.steerAngle = steering;
        //SetVisualInfo(visualFrontLeftWheel, frontLeftWheel);

        //frontRightWheel.steerAngle = steering;
        //SetVisualInfo(visualFrontRightWheel, frontRightWheel);

        rearLeftWheel.motorTorque = leftMotor * -1;
        SetVisualInfo(visualRearLeftWheel, rearLeftWheel);
        float leftArm = 0;
        float rightArm = 0;
        rearRightWheel.motorTorque = rightMotor * -1;
        SetVisualInfo(visualRearRightWheel, rearRightWheel);
        if (leftMotor != 0f || rightMotor != 0f)
        {

            if (!wheelChairArms.GetBool("Moving"))
            {
                wheelChairArms.SetBool("Moving", true);
                wheelChairArms.SetTrigger("Move");
            }
            //Debug.Log(wheelChairArms.GetBool("Moving"));

            if (leftMotor < 0)
                leftArm = -1;
            else if (leftMotor > 0)
                leftArm = 1;
            else
                leftArm = 0;


            if (rightMotor < 0)
                rightArm = -1;
            else if (rightMotor > 0)
                rightArm = 1;
            else
                rightArm = 0;

            //Debug.Log("Right Arm" + rightArm);
            //Debug.Log("Left Arm" + leftArm);

            if ((int)wheelChairArms.GetFloat("Left") != (int)leftArm)
            {
                //Debug.Log("Set left arm");
                wheelChairArms.SetFloat("Left", leftArm);
            }
            if ((int)wheelChairArms.GetFloat("Right") != (int)rightArm)
            {
                //Debug.Log("Set Right Arm");
                wheelChairArms.SetFloat("Right", rightArm);
            }
        }
        else
            wheelChairArms.SetBool("Moving", false);

    }

    void SetVisualInfo(Transform t, WheelCollider wheel)
    {
        Vector3 position;
        Quaternion rotation;
        wheel.GetWorldPose(out position, out rotation);
        t.position = position;
        t.rotation = rotation;
    }
}


