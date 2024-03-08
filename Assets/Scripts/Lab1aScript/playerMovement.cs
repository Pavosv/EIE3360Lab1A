using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 6f; // Player speed
    Vector3 movement;
    Rigidbody playerRigidbody;

    protected Joystick joystick;
    protected JoybuttonControls joybutton;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoybuttonControls>();
    }
    void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector3(
            joystick.Horizontal * speed + Input.GetAxis("Horizontal") * speed, 
            playerRigidbody.velocity.y, 
            joystick.Vertical * speed + Input.GetAxis("Vertical") * speed);

        if (joystick.Horizontal * speed > 0)
        {
            Debug.Log("Moving");
        }
    }
}
