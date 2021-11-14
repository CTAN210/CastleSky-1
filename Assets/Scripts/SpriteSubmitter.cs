using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.SceneManagement;

public class SpriteSubmitter : MonoBehaviour
{
    // TODO: Need to get id from previous scene.
    public GameObject selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        string userId = CityEntrance.Scenes.getParam("userId");
        string CharacterName =  selectedCharacter.GetComponent<Image>().sprite.name;

        Dictionary<string, dynamic> spriteUpdateForm = new Dictionary<string, dynamic>();
        spriteUpdateForm.Add("CharacterName", CharacterName);

        string jsonform = JsonConvert.SerializeObject(spriteUpdateForm, Formatting.Indented);

        StartCoroutine(Post("http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/users/" + userId, jsonform));

    }

     IEnumerator<dynamic> Post(string url, string bodyJsonString)
    {
        var request = UnityWebRequest.Put(url, bodyJsonString); 
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.downloadHandler.text);

        if (request.result == UnityWebRequest.Result.Success) {

            SceneManager.LoadScene("Login Scene");
        }
    }
}
