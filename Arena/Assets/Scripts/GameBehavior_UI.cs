using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading;
public class Game_Behavior_UI : MonoBehaviour
{
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public string labelText = "Grab HP, Weaponry, and Bombs";
    private int player_MaxHealth = 30;

    public TextMeshProUGUI player_startingHealthText;
    public TextMeshProUGUI initial_bombCountText;
    public TextMeshProUGUI itemsCollectedText;

    public GameObject Win;
    public GameObject Lose;

    private int player_startingHealth = 10;
    public int Health
    {
        get
        {
            return player_startingHealth;
        }

        set
        {
            player_startingHealth = value;
            if (player_startingHealth >= player_MaxHealth)
            {
                labelText = "You are now at Full HP! :3";
            }
            if (player_startingHealth <= 0)
            { 
                showLossScreen = true;
                Debug.Log("ded");
                Time.timeScale = 0;
                labelText = "You've been got :(";
            }
            else
            {
                labelText = "Grab More Health";
            }


        }
    }

    private int initial_bombCount = 0;
    private int max_BombCount = 3;
    public int Bombs
    {
        get
        {
            return initial_bombCount;
        }

        set
        {
            initial_bombCount = value;
            Debug.Log("Bomb picked!");
            if (initial_bombCount >= max_BombCount)
            {
                labelText = "All Bombs have been collected!";
            }
            else
            {
                labelText = "There are still " +
                    (max_BombCount - initial_bombCount) + " bombs to collect!";
            }
        }
    }

    private int itemsCollected = 0;
    public int maxItems = 9;
    public int Items
    {
        get
        {
            return itemsCollected;
        }

        set
        {
            itemsCollected = value;

            if (itemsCollected >= maxItems)
            {
                labelText = "You found all the items!";
                showWinScreen = true;
            }
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        player_startingHealthText.text = "Player Health: " + player_startingHealth;
        initial_bombCountText.text = "Bombs Collected: " + initial_bombCount;
        itemsCollectedText.text = "Items Collected: " + itemsCollected;

        if (showWinScreen)
        {
            Win.SetActive(true);
            Lose.SetActive(false);
            Time.timeScale = 0.0f;
        }

        else if (showLossScreen)
        {
            Win.SetActive(false);
            Lose.SetActive(true);
            Time.timeScale = 0.0f;
        }

        else
        {
            Win.SetActive(false);
            Lose.SetActive(false);
        }
    }

}
