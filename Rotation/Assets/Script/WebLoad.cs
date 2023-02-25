using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebLoad : MonoBehaviour
{
    [SerializeField] RawImage image;

    void Awake()
    {
        StartCoroutine(GetTexture(image));
    }

    IEnumerator GetTexture(RawImage webImage)
    {
        string url = "https://cdn.pixabay.com/photo/2016/05/27/14/33/football-1419954_960_720.jpg";

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            webImage.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }

}
