using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this code is to have the camera track the player at a slight offset behind & above the player capsule

public class Camera_Behavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);

    //target holds & gives us access to the player capsule's Transfrom info (position, rotation, scale)
    private Transform target;

    void Start()
    {
        //GameObject.Find locates the capsule by name and retrives its Transform property fr/ the scene
        //capsule's x,y, and z positions are updated & stored in the target variable each frame 

        target = GameObject.Find("Player").transform;
    }

    //LateUpdate so the camera code runs AFTER movement happens
    //this gives target the most up-to-date position to reference
    void LateUpdate()
    {
        //TransformPoint returns the position of the player capsule and offsets it slightly behind
        //the player capsule. 
        this.transform.position = target.TransformPoint(camOffset);

        //LookAt focuses on the target parameter passed in and updates the capsule's rotation every frame 
        this.transform.LookAt(target);

    }
}
