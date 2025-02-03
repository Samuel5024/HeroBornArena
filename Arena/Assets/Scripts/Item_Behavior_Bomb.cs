using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Behavior_Bomb : MonoBehaviour
{
    //OnCollsionEntere comes w/ parameter that stores a reference to the Collider that ran into it
    void OnCollisionEnter(Collision collision)
    {
        //Collision class has a property called gameObject
        //gameObject holds a reference to the colliding GameObject's Collider
        if(collision.gameObject.name == "Player")
        {
            //if the colliding object is the player we'll call the Destroy() method
            //this.trasnform.gameObject sets the Pivot prefab to be destroyed
            Destroy(this.transform.gameObject);

            //prints out log to the console that we have collected an item
            Debug.Log("You Got a Bomb! \n Time to go KABOOM!");
        }
    }
}
