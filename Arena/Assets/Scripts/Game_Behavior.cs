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
                labelText = "Full HP!\nGather the Remaining Items!";
        }
    }

    public int initial_BombCount = 0;
    private int max_BombCount = 3;
    public int Bombs
    {
        get{ return initial_BombCount; }

        set
        {
            if (Bombs >= max_BombCount)
            {
                labelText = "All Bombs have been collected!";
            }
            else
            {
                labelText = "There are still " +
                    (max_BombCount - Bombs) + " bombs to collect!";
            }
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + player_StartingHealth);
        GUI.Box(new Rect(180, 20, 150, 25), "Weapon: ");
        GUI.Box(new Rect(20, 50, 150, 25), "Bombs: " + Bombs);
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
    }
}
