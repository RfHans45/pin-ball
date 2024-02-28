using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleController : MonoBehaviour
{
   public float restPostion = 0f;
   public float pressedpostion = 35f;
   public float hitstrenght = 1000f;
   public float flipperdamper = 150f;
   HingeJoint hinge;
   public string inputName;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

       void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitstrenght;
        spring.damper = flipperdamper;
        
        if (Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedpostion;
        }
        else
        {
            spring.targetPosition = restPostion;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
