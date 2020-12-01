using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickToPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    
    public JoystickMovement joystickMovement;
    public CharacterController characterController;

    void Start()
    {
        
    }
    
    void Update()
    {
        characterController.SimpleMove(new Vector3(joystickMovement.inputs.x * speed,0,  joystickMovement.inputs.y * speed));

        if (new Vector3(joystickMovement.inputs.x * speed,0,  joystickMovement.inputs.y * speed).magnitude > 0.01f)
            transform.rotation = Quaternion.LookRotation(new Vector3(joystickMovement.inputs.x * speed,0,  joystickMovement.inputs.y * speed));
    }
    
}
