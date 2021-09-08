using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float shootingForce = 100f;
    public float turnSpeed = 40f;
    public GameObject cannonBallPrefab;
    public Transform spawnPoint;

    void OnEnable()
    {
        InvokeRepeating("ShootAtPlayer", 1f, 5f);
    }

    
    void Update()
    {
        // if we don't have the robot player
        if (!GameManager.instance.RobotPlayer())
        {
            // exit the update method
            return;
        }
        else
        {
            // turn towards the player
            // define a vector towards the player from the tower
            Vector3 directionToPlayer = GameManager.instance.RobotPlayer().transform.position - transform.position;
            Vector3 rotateTowards = Vector3.RotateTowards(transform.forward, directionToPlayer, Time.deltaTime * turnSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(rotateTowards);
        }
    }

    /// <summary>
    /// Shoot at the player
    /// </summary>
    private void ShootAtPlayer()
    {
        if (GameManager.instance.RobotPlayer())
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab, spawnPoint.position, spawnPoint.rotation);
            cannonBall.GetComponent<Rigidbody>().AddForce(cannonBall.transform.forward * shootingForce);
            Destroy(cannonBall, 5f);
        }
    }
}
