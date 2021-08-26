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
        
    }
}
