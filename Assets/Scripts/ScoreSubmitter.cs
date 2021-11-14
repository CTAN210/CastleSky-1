using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.SceneManagement;
public class ScoreSubmitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void PostScoreToDB(string userId, string cityName, int score)
    {
        Debug.Log("Entered Post");
        Dictionary<string, dynamic> registrationForm = new Dictionary<string, dynamic>();
        registrationForm.Add("countryName", cityName);
        registrationForm.Add("userId", userId);
        registrationForm.Add("score", score);
        Debug.Log("Dictionary made.");
        
        string jsonform = JsonConvert.SerializeObject(registrationForm, Formatting.Indented);

        Debug.Log(jsonform);

        StartCoroutine(Post("http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/updateScore", jsonform));
    }

    IEnumerator<dynamic> Post(string url, string bodyJsonString)
    {
        var request = UnityWebRequest.Post(url, bodyJsonString);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
       // request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.downloadHandler.text);

        if (request.result == UnityWebRequest.Result.Success) {
            //TODO: Go where next?
        }
    }

    
}
