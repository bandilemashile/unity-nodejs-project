using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class post : MonoBehaviour
{
    InputField outputArea;

    void Start()
    {
        outputArea = GameObject.Find("outputarea").GetComponent<InputField>();
        GameObject.Find("post").GetComponent<Button>().onClick.AddListener(PostData);
    }

    void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        outputArea.text = "Loading...";
        string uri = "http://localhost:3000/car/create";
        WWWForm form = new WWWForm();
        form.AddField("name", "model");
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
                outputArea.text = request.downloadHandler.text;
        }
    }
}
