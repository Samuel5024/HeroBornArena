using UnityEngine;

public class Item_Behavior_Bomb : MonoBehaviour
{
    public Game_Behavior_UI gameManager;
    public AudioClip pickupClip; //assign in inspector
    private AudioSource pickupSound;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Behavior_UI>();
        pickupSound = GetComponentInChildren<AudioSource>(); // get from child
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Pickup triggered: playing sound " + pickupClip.name);

            if (pickupClip != null && pickupSound != null)
            {
                pickupSound.PlayOneShot(pickupClip);
            }

            gameManager.Bombs += 1;
            gameManager.Items += 1;
            Destroy(gameObject, pickupClip != null ? pickupClip.length : 0f);
        }
    }

}
