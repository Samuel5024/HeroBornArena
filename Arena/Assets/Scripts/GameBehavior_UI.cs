using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Game_Behavior_UI : MonoBehaviour
{
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public string labelText = "Grab HP, Weaponry, and Bombs";
    public int player_StartingHealth = 10;
    private int player_MaxHealth = 30;

    public TextMeshProUGUI player_StartingHealthText;
    public TextMeshProUGUI initial_BombCountText;
    public TextMeshProUGUI itemsCollectedText;

    public GameObject Win;
    public GameObject Lose;

    public int Health
    {
        get
        {
            return player_StartingHealth;
        }

        set
        {
            player_StartingHealth = value;
            if (player_StartingHealth >= player_MaxHealth)
            {
                labelText = "You are now at Full HP! :3";
            }
            if (player_StartingHealth <= 0)
            { 
                showLossScreen = true;
                Time.timeScale = 0;
                labelText = "You've been got :(";
            }
            else
            {
                labelText = "Grab More Health";
            }


        }
    }

    public int initial_BombCount = 0;
    private int max_BombCount = 3;
    public int Bombs
    {
        get
        {
            return initial_BombCount;
        }

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
                Time.timeScale = 0f;
            }
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    void Start ()
    {
        Win.SetActive(false);
        Lose.SetActive(false);
    }

    void Update()
    {
        player_StartingHealthText.text = "Player Health: " + player_StartingHealth;
        initial_BombCountText.text = "Bombs Collected: " + initial_BombCount;
        itemsCollectedText.text = "Items Collected: " + itemsCollected;

        if (showWinScreen)
        {
            Win.SetActive(true);
            Lose.SetActive(false);
        }

        else if (showLossScreen)
        {
            Win.SetActive(false);
            Lose.SetActive(true);
        }

        else
        {
            Win.SetActive(false);
            Lose.SetActive(false);
        }
    }

}
