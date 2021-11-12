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
    public InputField inputClass;
    public Text registrationError;

    void Start(){
        registrationError.text = "";
        // string email = "\"calvinlow@gmail.com\"";
        // string password = "\"ilovecock\"";
        // string username = "\"cocksterhaha\"";
        // string userClass = "\"5A\"";

        // string email = "calvinlow7@gmail.com";
        // string password = "password";
        // string username = "calvinlow";
        // string userClass = "5A";

        string email = inputEmail.text.ToString();
        string username = inputUsername.text.ToString();
        string password = inputPassword.text.ToString();
        string userClass = UserClassDropdown.selectedClass;

        

        // submitForm(registrationForm);

        Dictionary<string, dynamic> registrationForm = new Dictionary<string, dynamic>();
        registrationForm.Add("email", email);
        registrationForm.Add("password", password);
        registrationForm.Add("name", username);
        registrationForm.Add("RoleId", 1);
        registrationForm.Add("ClassId", userClass);

        string jsonform = JsonConvert.SerializeObject(registrationForm, Formatting.Indented);

        Debug.Log(jsonform);

        // string registrationForm = "{\"email\":"+ email 
        // + ",\"password\":" + password 
        // + ",\"name\":" + username
        // + ",\"RoleId\": 0" 
        // + ",\"Class\":" + userClass +"}";

        Debug.Log(jsonform);
        StartCoroutine(Post("http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/register", jsonform));
    }
    

    // IEnumerator<UnityWebRequestAsyncOperation> submitForm(string registrationForm = null)
    // {
    //     Debug.Log ("Yo");
    //     string url = "http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/register";

    //     UnityWebRequest www = UnityWebRequest.Post(url, registrationForm);
    //     www.SetRequestHeader("Content-Type", "application/json");
    //     www.SetRequestHeader("email", "calvinlow@gmail.com");
    //     www.SetRequestHeader("password", "ilovecock");
        

    //     yield return www.SendWebRequest();

    //     if (www.result != UnityWebRequest.Result.Success) {
    //         registrationError.text = www.error;
    //          Debug.Log(www.error);
    //     }
    //     else {
    //         Debug.Log("Form upload complete!");
    //         //Change Scene based on user type!
    //     }
    // }

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
            SceneManager.LoadScene("Choose Character Scene");
        }

        if (request.downloadHandler.text.Contains("User.EmailAddress_UNIQUE")) {
            registrationError.text = "Email already in use.";
        } else if (request.downloadHandler.text.Contains("User.UserName_UNIQUE")) {
            registrationError.text = "Username already in use.";
        }
    }

    
}
