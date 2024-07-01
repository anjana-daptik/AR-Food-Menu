using UnityEngine;
using UnityEngine.UI;

public class DeepLinkingHandler : MonoBehaviour
{
    public Button ARViewButton;

    void Start()
    {
        if (ARViewButton != null)
        {
            //ARViewButton.onClick.AddListener(() => OnDeepLinkActivated("unitydl://openCamera?image=https://example.com/image.jpg"));
            ARViewButton.onClick.AddListener(() => OnDeepLinkActivated("unitydl://openCamera?image=https://bonmasala.com/wp-content/uploads/2022/10/mutton-biriyani-recipe.jpeg"));
        }
    }

    void OnDeepLinkActivated(string url)
    {
        if (url.StartsWith("unitydl://openCamera"))
        {
            string imageUrl = url.Split('?')[1].Split('=')[1];
            StartARSession(imageUrl);
        }
    }

    void StartARSession(string imageUrl)
    {
        // Logic to start AR session
        Debug.Log("Starting AR session with image URL: " + imageUrl);
        ARSessionManager.Instance.StartARSession(imageUrl);
    }
}

