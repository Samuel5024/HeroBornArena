using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Behavior_Health: MonoBehaviour
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
            Destroy(this.transform.gameObject);
            Debug.Log("You grabbed a Health Kit and restored 5 HP :)");
            gameManager.Health += 5;
            gameManager.Items += 1;
        }
    }
}
