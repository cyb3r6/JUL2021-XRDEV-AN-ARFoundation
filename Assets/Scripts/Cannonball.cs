using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            // destroy the player and cannon ball
            Destroy(collision.gameObject);

            // decrease the number of lives
            GameManager.instance.DecreaseLives();

            // animate death
        }
    }
}
