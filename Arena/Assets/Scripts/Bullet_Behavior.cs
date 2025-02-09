using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
    public float onscreenDelay = 3f; 
    void Start()
    {
        Destroy(this.gameObject, onscreenDelay);//delete bullet prefabs from the heirarchy
    }
}
