using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public InputField inputEmail;
    public InputField inputUsername;
    public InputField inputPassword;
    public Text registrationError;
    public void PostRegistationForm()
    {
         registrationError.text = "";

        string email = inputEmail.text.ToString();
        string username = inputUsername.text.ToString();
        string password = inputPassword.text.ToString();
        string userClass = UserClassDropdown.selectedClass;

        Dictionary<string, dynamic> registrationForm = new Dictionary<string, dynamic>();
        registrationForm.Add("email", email);
        registrationForm.Add("password", password);
        registrationForm.Add("name", username);
        registrationForm.Add("RoleId", 1);
        registrationForm.Add("Class", userClass);

        string jsonform = JsonConvert.SerializeObject(registrationForm, Formatting.Indented);

        Debug.Log(jsonform);

        StartCoroutine(Post("http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/register", jsonform));
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
            //TODO: Send UserId to next scene.
            string idKey = request.downloadHandler.text.Split(',')[0];
            string id = idKey.Split(':')[1];
            Debug.Log(id);
            CityEntrance.Scenes.Load("Choose Character Scene", "userId", id, "position" ,new Vector3(0,0,0));
        }

        if (request.downloadHandler.text.Contains("User.EmailAddress_UNIQUE")) {
            registrationError.text = "Email already in use.";
        } else if (request.downloadHandler.text.Contains("User.UserName_UNIQUE")) {
            registrationError.text = "Username already in use.";
        }
    }

    
}
