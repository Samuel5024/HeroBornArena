using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Item_Behavior_Bomb : MonoBehaviour
{
    public Game_Behavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").
            GetComponent<Game_Behavior>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("You Got a Bomb! \n Time to go KABOOM!");
            gameManager.Items += 1;
        }
    }
}
