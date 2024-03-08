using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoybuttonControls : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        Debug.Log("Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
