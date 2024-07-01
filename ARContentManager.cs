using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ARContentManager : MonoBehaviour
{
    public static ARContentManager Instance;
    public GameObject arContentPrefab;

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

    public void PlaceARContent(Vector3 position)
    {
        Instantiate(arContentPrefab, position, Quaternion.identity);
    }

    public void LoadAndPlaceARContent(string imageUrl, Vector3 position)
    {
        StartCoroutine(LoadImageCoroutine(imageUrl, position));
    }

    //private IEnumerator LoadImageCoroutine(string imageUrl, Vector3 position)
    //{
    //    using (WWW www = new WWW(imageUrl))
    //    {
    //        yield return www;
    //        if (string.IsNullOrEmpty(www.error))
    //        {
    //            Texture2D texture = www.texture;
    //            GameObject arContent = Instantiate(arContentPrefab, position, Quaternion.identity);
    //            Renderer renderer = arContent.GetComponent<Renderer>();
    //            renderer.material.mainTexture = texture;
    //        }
    //        else
    //        {
    //            Debug.LogError("Failed to load image: " + www.error);
    //        }
    //    }
    //}

    private IEnumerator LoadImageCoroutine(string imageUrl, Vector3 position)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                // Get the texture from the web request
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);

                // Instantiate AR content prefab and apply texture
                GameObject arContent = Instantiate(arContentPrefab, position, Quaternion.identity);
                Renderer renderer = arContent.GetComponent<Renderer>();
                renderer.material.mainTexture = texture;
            }
            else
            {
                // Handle error
                Debug.LogError("Failed to load image: " + webRequest.error);
            }
        }
    }

}

