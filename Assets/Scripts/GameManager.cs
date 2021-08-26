using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int numberOfLives = 10;


    public void DecreaseLives()
    {
        numberOfLives--;    // shorthand for saying numberOfLives = numberOfLives -1
        if(numberOfLives <= 0)
        {
            // game over
        }
    }

    /// <summary>
    /// return a reference to the player in the scene
    /// </summary>
    /// <returns></returns>
    public GameObject RobotPlayer()
    {
        RobotAnimController robotPlayer = FindObjectOfType<RobotAnimController>();
        if (robotPlayer)
        {
            return robotPlayer.gameObject;
        }
        else
        {
            return default;
        }
    }
}
