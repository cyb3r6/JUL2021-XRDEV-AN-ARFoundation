using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public GameObject robotPrefab;
    public GameObject spawnedRobot;

    private ARRaycastManager aRRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(spawnedRobot == null)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                if(aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;
                    spawnedRobot = Instantiate(robotPrefab, hitPose.position, robotPrefab.transform.rotation);
                }
            }
        }
    }
}
