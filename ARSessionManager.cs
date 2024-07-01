using UnityEngine;

public class ARSessionManager : MonoBehaviour
{
    public static ARSessionManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartARSession(string imageUrl)
    {
        // Logic to start AR session and handle image URL
        Debug.Log("Starting AR session with image URL: " + imageUrl);
        // Initialize AR Session if needed
        // ...

        // Assuming ARPointOfInterest is handling the touch input and placing the content
        // We pass the image URL to ARContentManager
        ARContentManager.Instance.LoadAndPlaceARContent(imageUrl, new Vector3(0, 0, 1));
    }
}

