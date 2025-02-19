using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Behavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public string labelText = "Grab HP, Weaponry, and Bombs";
    public int player_StartingHealth = 15;
    private int player_MaxHealth = 30;
    public int Health
    {
        get { return player_StartingHealth; }

        set {
            player_StartingHealth = value;
            if (player_StartingHealth >= player_MaxHealth)
                labelText = "You are now at Full HP! :3";
        }
    }

    public int initial_BombCount = 0;
    private int max_BombCount = 3;
    public int Bombs
    {
        get{ return initial_BombCount; }

        set
        {
            initial_BombCount = value;
            Debug.Log("Bomb picked!");
            if (initial_BombCount >= max_BombCount)
            {
                labelText = "All Bombs have been collected!";
            }
            else
            {
                labelText = "There are still " +
                    (max_BombCount - initial_BombCount) + " bombs to collect!";
            }
        }
    }

    private int _itemsCollected = 0;
    public int maxItems =9;
    public int Items
    {
        get { return _itemsCollected; }
        set {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                labelText = "You found all the items!";
                showWinScreen = true;
            }
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + player_StartingHealth);
        GUI.Box(new Rect(180, 20, 150, 25), "Weapon: ");
        GUI.Box(new Rect(20, 50, 150, 25), "Bombs: " + initial_BombCount);
        GUI.Box(new Rect(650, 20, 250, 25), "OBJECTIVE: Grab All Collectibles.");
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
        
        if(showWinScreen && GUI.Button(new Rect(Screen.width / 2 - 100, 
            Screen.height / 2 - 50, 200, 100), "YOU WON!"))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
    }
}
