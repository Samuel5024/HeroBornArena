using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Behavior_Gun : MonoBehaviour
{    
    public Game_Behavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").
            GetComponent<Game_Behavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject); //erase item from hierarchy when collected by player
            Debug.Log("Here's a Weapon.\nHOORAY! Now try not to die :)");
            gameManager.Items += 1;
            collision.gameObject.GetComponent<Player_Behavior>().OnGun();
        }
    }


}
