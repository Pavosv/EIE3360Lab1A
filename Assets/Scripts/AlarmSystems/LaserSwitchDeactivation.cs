using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchDeactivation : MonoBehaviour
{
    public GameObject laser;                // Reference to the laser that can we turned off at this switch.
    public Material unlockedMat;            // The screen's material to show the laser has been unloacked.

    
    private GameObject player;              // Reference to the player.
    protected JoybuttonControls joybutton;

    void Awake()
    {
        // Setting up the reference.
        player = GameObject.FindGameObjectWithTag(Tags.player);
        joybutton = FindObjectOfType<JoybuttonControls>();
    }


    void OnTriggerStay(Collider other)
    {
        // If the colliding gameobject is the player...
        if (other.gameObject == player)
            // ... and the switch button is pressed...
            if (Input.GetButton("Switch") || joybutton.Pressed)
                // ... deactivate the laser.
                LaserDeactivation();
    }

    void LaserDeactivation()
    {
        // Deactivate the laser GameObject.
        laser.SetActive(false);

        // Store the renderer component of the screen.
        Renderer screen = transform.Find("prop_switchUnit_screen").GetComponent<Renderer>();

        // Change the material of the screen to the unlocked material.
        screen.material = unlockedMat;

        // Play switch deactivation audio clip.
        GetComponent<AudioSource>().Play();	
    }
}
