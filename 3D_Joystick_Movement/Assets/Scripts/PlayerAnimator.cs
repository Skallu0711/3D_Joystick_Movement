using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    
    // arms
    public GameObject leftArm;
    public GameObject rightArm;

    // legs
    public GameObject leftLeg;
    public GameObject rightLeg;

    private float clock = 0.0f;
    public float swingSpeed;
    public float velocity = 0.0f;
    public float velocityFiltered = 0.0f;
    public float animationAmmount = 0.0f;

    public Rigidbody rb;
    public Vector3 lastPosition = new Vector3(0,0,0);
    
    void Start()
    {
        
    }

    
    void Update()
    {
        clock += Time.deltaTime * velocityFiltered * 0.25f;

        velocity = ((transform.position - lastPosition) / Time.deltaTime).magnitude;
        velocityFiltered = velocityFiltered * (1 - Time.deltaTime * 5) + velocity * Time.deltaTime * 5;

        animationAmmount = Mathf.Clamp(velocityFiltered * 0.5f, 0, 1);

        lastPosition = transform.position;

        leftArm.transform.localEulerAngles = new Vector3(Mathf.Sin(clock * swingSpeed) * animationAmmount * 45.0f, 0, 0);
        rightArm.transform.localEulerAngles = new Vector3(-Mathf.Sin(clock * swingSpeed) * animationAmmount * 45.0f, 0, 0);
        
        leftLeg.transform.localEulerAngles = new Vector3(-Mathf.Sin(clock * swingSpeed) * animationAmmount * 45.0f, 0, 0);
        rightLeg.transform.localEulerAngles = new Vector3(Mathf.Sin(clock * swingSpeed) * animationAmmount * 45.0f, 0, 0);
    }
}
