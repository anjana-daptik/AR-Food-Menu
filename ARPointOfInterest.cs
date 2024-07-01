using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARPointOfInterest : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                PlaceARContent(hitPose.position);
            }
        }
    }

    void PlaceARContent(Vector3 position)
    {
        Debug.Log("Placing AR content at position: " + position);
        ARContentManager.Instance.LoadAndPlaceARContent("https://example.com/image.jpg", position);
    }
}

