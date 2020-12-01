using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickMovement : MonoBehaviour
{
    public bool isHeld;
    
    public Vector2 mousePosition;
    public Vector2 inputs;
    
    public GameObject joystick;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float maxDistance = 50.0f;
        
        if (isHeld)
        {
           //Debug.Log("clicked ");

           mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
           joystick.transform.position = mousePosition;

           if (joystick.transform.localPosition.magnitude > maxDistance)
               joystick.transform.localPosition *= maxDistance / joystick.transform.localPosition.magnitude;
        }
        else
        {
            float returnSpeed = 5.0f;
            joystick.transform.localPosition = joystick.transform.localPosition * (1 - Time.deltaTime * returnSpeed);
        }

        inputs = joystick.transform.localPosition / maxDistance;
    }
    
    // JoyInner ActionEvent method
    public void OnHold(bool input)
    {
        isHeld = input;
    }
    
}
