using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.SceneManagement;
using System.Reflection;
public class LoginSubmitter : MonoBehaviour
{
    public InputField inputEmail;
    public InputField inputPassword;
    public Text loginError;          

    public void PostLoginForm()
    {
        string email = inputEmail.text.ToString();
        string password = inputPassword.text.ToString();

        Dictionary<string, dynamic> registrationForm = new Dictionary<string, dynamic>();
        registrationForm.Add("email", email);
        registrationForm.Add("password", password);

        string jsonform = JsonConvert.SerializeObject(registrationForm, Formatting.Indented);

        Debug.Log(jsonform);
        StartCoroutine(Post("http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/login", jsonform));
    
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
            Debug.Log("HooWoo");

            if (request.downloadHandler.text.Contains("User not found")) {
                loginError.text = "The email entered does have an account registered.";
            } else if (request.downloadHandler.text.Contains("Password not correct")) {
                loginError.text = "Incorrect Password.";
            } else {
                User user = JsonConvert.DeserializeObject<User>(request.downloadHandler.text); 
                Debug.Log(user);
                if (user.RoleID == 1){
                    Dictionary<string,string> userDetail = new Dictionary<string, string>{};
                    userDetail.Add("userId", user.UserId.ToString());
                    userDetail.Add("characterName", user.CharacterName);
                    userDetail.Add("userName", user.UserName);
                    CityEntrance.Scenes.Load("Student Choose World Scene",  userDetail);
                    // SceneManager.LoadScene("Student Choose World Scene");
                } // Student 

                if (user.RoleID == 2){
                    SceneManager.LoadScene("Teacher Commands Scene");

                }
                
            }
        }
    }
    
    

}
