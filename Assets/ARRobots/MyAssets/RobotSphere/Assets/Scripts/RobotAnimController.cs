using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 30f;
    public float deadZone = 0.2f;

    private Animator robotAnimator;
    private Rigidbody robotRigidbody;
    private Joystick joystick;


    void OnEnable()
    {
        joystick = FindObjectOfType<Joystick>();
        robotRigidbody = GetComponent<Rigidbody>();
        robotAnimator = GetComponent<Animator>();
        robotAnimator.SetBool("Open_Anim", true);
    }

    
    void Update()
    {
        if(joystick.Direction.magnitude >= deadZone)
        {
            // move forward!
            robotRigidbody.AddForce(transform.forward * moveSpeed);

            // animate walking
            robotAnimator.SetBool("Walk_Anim", true);
        }
        else
        {
            // stop moving forward and stop walk animation
            robotAnimator.SetBool("Walk_Anim", false);
        }

        // rotate the robot
        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
        Vector3 directionToRotateIn = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime * turnSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(directionToRotateIn);
         
    }
}
