using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Behavior_Health: MonoBehaviour
{
    public Game_Behavior_UI gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").
            GetComponent<Game_Behavior_UI>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("You grabbed a Health Kit and restored 5 HP :)");
            gameManager.player_startingHealth += 5;
            gameManager.itemsCollected += 1;
        }
    }
}
