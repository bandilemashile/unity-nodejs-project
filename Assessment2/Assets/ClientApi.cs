using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;


public class ClientApi : MonoBehaviour
{

    public string url;
    public Text nameText;
    public Text modelText;
    public Text speedText;

    


    [System.Serializable]
    public struct UserObject
    {
        
        public string name;
        public string model;
        public string speed;

    }

  UserObject[] users;

    // Start is called before the first frame update
    public void GetData()
    {
        StartCoroutine(Get(url));
        
    }

    public IEnumerator Get(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {


                    JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(www.downloadHandler.data));

                    if(jsonData == null)
                    {
                        print("no data");
                    }
                    else
                    {
                        print("Connected to server : Reading data");
                        print("Car name is :" + jsonData["name"]);
                        print("Car model is :" + jsonData["model"]);
                        print("Car speed is :" + jsonData["speed"]);

                        nameText.text = jsonData["name"];
                        speedText.text = jsonData["speed"];
                        modelText.text = jsonData["model"];
                    }
                    // handle the result
                   // var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                  //  Debug.Log(result);

                    

                    //  var user = JsonUtility.FromJson<UserObject>("{\"car\":" + result + "}");
                   

                    //   nameText.text = user.name.ToString();
                    
                    //  Debug.Log("name is " + nameText.text);

                    // JsonUtility.FromJsonOverwrite(result, user);





                }
                else
                {
                    //handle the problem
                    Debug.Log("Error! data couldn't get.");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
}






