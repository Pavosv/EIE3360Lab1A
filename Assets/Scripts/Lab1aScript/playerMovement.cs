using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 6f; // Player speed
    Vector3 movement;
    Rigidbody playerRigidbody;
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        movement.Set(hor, 0f, ver);
        movement = movement.normalized * speed * Time.deltaTime; //Gets the direction and multiplies by speed
        playerRigidbody.MovePosition(transform.position + movement); //Add the initial position to the movement
    }
}
