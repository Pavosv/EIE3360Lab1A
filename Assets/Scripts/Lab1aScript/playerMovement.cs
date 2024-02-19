using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 6f; // The speed at which the player will move.
    Vector3 movement; // The vector stores the direction of the player's movement.
    Rigidbody playerRigidbody; // Reference to the player's rigid body.
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // Store the input axes.
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        // Set the movement vector based on the axis input.
        movement.Set(hor, 0f, ver);
        // Normalize the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;
        // Move the player to its current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
