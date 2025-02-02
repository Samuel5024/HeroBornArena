using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//The purpose of this code is to move the Player capsule while implementing physics through the Rigidbody component

public class Player_Behavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    private float vInput;
    private float hInput;

    //private Rigidbody-type variable contains capsule's Rigidbody component info
    private Rigidbody _rb;

    //Start fires when scripts in a scene are initialized => when you click PLAY
    void Start()
    {
        //GetComponent checks if the Rigidbody component type exists
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Input.GetAxis("Vertical") detects when up/W or down/S is pressed 
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;


        /* We comment out Transform & Rotate so we don't run two different kinds of player control
         
        //Translate takes in a Vector3 parameter to move the Player's TRANSFORM component
        //Time.deltaTime supplies direction & speed Player needs to move
        //forward/back along the z axis at the speed we calculated
        
        this.transform.Translate(Vector3.back * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */
    }

    //FixedUpdate() is frame independent for physics code
    private void FixedUpdate()
    {
        //rotation stores our our left and right rotation
        Vector3 rotation = Vector3.up * hInput;

        //Quaternion.Euler converts & returns the Vector3 parameter in Euler Angles (Unity preferred)
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        //Calls MovePosition on our _rb component and applies movement force to satisfy our vector parameter
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}
