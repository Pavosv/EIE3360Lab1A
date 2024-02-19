using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class cctvBehavior : MonoBehaviour
{
    public GameObject cameraHead;
    public GameObject player;
    public Text timerText;

    private Transform playerTransform;

    public float speed = 30.0f;
    public float range = 60.0f;
    

    private float defaultXRotation;
    private float defaultZRotation;
    private float elapsedTime;

    private bool isPlayerInside = false;

    // Start is called before the first frame update
    void Start()
    {
        defaultXRotation = cameraHead.transform.rotation.eulerAngles.x; //Get the initial X rotation of the camera head
        defaultZRotation = cameraHead.transform.rotation.eulerAngles.z;//Get the initial Z rotation of the camera head
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerInside) //Keep rotating if player is not detected
        {
            cctvRotate();
        }
        else
        {
            if (playerTransform != null)
            {
                playerInside(); //Lock on player when collider is triggered
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInside = true;
            playerTransform = other.transform; //Get the player's transform location
            timerCount(); //Start the timer
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInside = false;
            playerTransform = null; //Remove the player's transform when player exits
            timerCount(); //Stop the timer
        }
    }

    private void cctvRotate()
    {
        float angle = Mathf.PingPong(Time.time * speed, range * 2) - range; //The camera constantly moves between -60 and 60 degrees
        cameraHead.transform.rotation = Quaternion.Euler(defaultXRotation, angle - 180, defaultZRotation);

    }

    private void playerInside()
    {
        cameraHead.transform.LookAt(playerTransform.position); //Camera follows player when detected
    }

    private void timerCount()
    {
        if (isPlayerInside == true)
        {
            elapsedTime += Time.deltaTime; //Start timer when player is detected
        }
        else
        {
            elapsedTime = 0; //Reset when player is not
        }
        timerText.text = Mathf.FloorToInt(elapsedTime).ToString();
        if (elapsedTime >=3) //Game restarts after 3 seconds
        {
            elapsedTime = 0;
            timerText.text = Mathf.FloorToInt(elapsedTime).ToString();
            restartGame();

        }
    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
