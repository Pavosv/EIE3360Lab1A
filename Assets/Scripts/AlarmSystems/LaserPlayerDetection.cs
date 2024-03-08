using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlayerDetection : MonoBehaviour
{
    private GameObject player;                          // Reference to the player.
    private LastPlayerSighting lastPlayerSighting;      // Reference to the global last sighting of the player.

    void Awake()
    {
        // Setting up references.
        player = GameObject.FindGameObjectWithTag(Tags.player);
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
}


    void OnTriggerStay(Collider other)
    {
        // If the beam is on...
        if (GetComponent<Renderer>().enabled)
            // ... and if the colliding gameobject is the player...
            if (other.gameObject == player)
            // ... set the last global sighting of the player to the colliding object's position.
            {
                lastPlayerSighting.position = other.transform.position;
                lastPlayerSighting.timerStart = false; //Timer doesn't start until player leaves
                Debug.Log("Player enters, timer Start: " + lastPlayerSighting.timerStart);
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GetComponent<Renderer>().enabled)
            // ... and if the colliding gameobject is the player...
            if (other.gameObject == player)
            {
                lastPlayerSighting.timerStart = true; //When player exits detection zone, start timer
                Debug.Log("Player leaves, timer Start: " + lastPlayerSighting.timerStart);
            }
    }
}
