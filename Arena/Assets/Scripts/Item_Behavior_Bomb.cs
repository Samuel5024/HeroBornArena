using UnityEngine;
using UnityEngine.Audio;

public class Item_Behavior_Bomb : MonoBehaviour
{
    public Game_Behavior_UI gameManager;
    public AudioClip pickupClip; //assign in inspector
    private AudioSource audioSource; //"speaker" in the scene that plays the clip

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Behavior_UI>();
        audioSource = GetComponent<AudioSource>(); //assumes AudioSource is on same object
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("You Got a Bomb! \n Time to go KABOOM!");

            if (pickupClip != null) //check for sound
            {
                AudioSource tempAudio = new GameObject("TempAudio").AddComponent<AudioSource>();
                tempAudio.clip = pickupClip;
                tempAudio.Play();
                Destroy(tempAudio.gameObject, pickupClip.length);
            }

            Destroy(gameObject);
            gameManager.Bombs += 1;
            gameManager.Items += 1;
        }
    }
}
