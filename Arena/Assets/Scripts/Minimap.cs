using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player; //reference to player
    
    void LateUpdate () //minimap updates AFTER the player moves
    {
        Vector3 newPosition = player.position; //new minimap position = player position
        newPosition.y = transform.position.y; //zoom out on the y axis
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); //camera rotates with player on the y-axis
    }
}
