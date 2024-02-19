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
        defaultXRotation = cameraHead.transform.rotation.eulerAngles.x;
        defaultZRotation = cameraHead.transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerInside)
        {
            cctvRotate();
        }
        else
        {
            if (playerTransform != null)
            {
                playerInside();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInside = true;
            playerTransform = other.transform;
            timerCount();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInside = false;
            playerTransform = null;
            timerCount();
        }
    }

    private void cctvRotate()
    {
        float angle = Mathf.PingPong(Time.time * speed, range * 2) - range;
        cameraHead.transform.rotation = Quaternion.Euler(defaultXRotation, angle - 180, defaultZRotation);

    }

    private void playerInside()
    {
        cameraHead.transform.LookAt(playerTransform.position);
    }

    private void timerCount()
    {
        if (isPlayerInside == true)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            elapsedTime = 0;
        }
        timerText.text = Mathf.FloorToInt(elapsedTime).ToString();
        if (elapsedTime >=3)
        {
            restartGame();
        }
    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
