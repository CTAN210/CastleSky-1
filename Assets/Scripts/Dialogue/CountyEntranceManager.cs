using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System;
public class CountyEntranceManager : MonoBehaviour
{
    // public Animator animator_dialogue;
    public GameObject geometry_dialogue;
    public GameObject wholenumber_dialogue;
    public GameObject species_dialogue;
    // public Animator animator_guard;
    public GameObject geometry_guard;
    public GameObject wholenumber_guard;
    public GameObject species_guard;
    public GameObject accessCodeInputField;
    public GameObject Player;
    public Animator PlayerAnimator;
    public GameObject guard;

    [SerializeField]
    public static bool geometryAccessStatus;
    public static bool wholenumberAccessStatus;
    public static bool speciesAccessStatus;



    void Start()
    {
        if (geometryAccessStatus == true){
            // animator_guard.SetBool("IsOpen",false);
            geometry_guard.SetActive(false);
        }

        if (wholenumberAccessStatus == true){
            // animator_guard.SetBool("IsOpen",false);
            wholenumber_guard.SetActive(false);
        }

        if (speciesAccessStatus == true){
            // animator_guard.SetBool("IsOpen",false);
            species_guard.SetActive(false);
        }




    }


    public void OpenCountryEntrance(GameObject specificDialogue){
        Debug.Log ("Starting Dialogue with player 1");

        try
        {
            Debug.Log("in try of open country entrance");
            specificDialogue.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled = false;
        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    public  void CloseCountryEntrance(GameObject specificDialogue){
        try
        {
            specificDialogue.SetActive(false);
            Player.GetComponent<PlayerMovement>().enabled = true;
            Debug.Log("reset input field");
            // accessCodeInputField.GetComponent<InputField>().text = ""; 
            specificDialogue.GetComponentInChildren<InputField>().text = ""; 
            // GameObject.Find("Geometry_error_message").GetComponent<Text>().enabled = false;
            // Text error_message = specificDialogue.GetComponent("Geometry_error_message").gameObject.GetComponent<Text>();
            Text[] textComponents = specificDialogue.GetComponentsInChildren<Text>();
            foreach(Text textComponent in textComponents) {
                if (textComponent.name.Contains("Error_message")){
                    textComponent.enabled = false;
                }
                Debug.Log(textComponent.name);
                Debug.Log("test");
            }
            // error_message.enabled = false;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public async void accessCodeAuthentication(GameObject specificDialogue){
        try
        {
            Debug.Log("reset input field");
            string accessCode = specificDialogue.GetComponentInChildren<InputField>().text;
            string dialogueName = specificDialogue.name;
            Debug.Log("accessCode: " + accessCode);
            
            switch (dialogueName) {
                case "Geometry_Entrance_Dialogue":
                    Debug.Log("I am in Geomtry Dialogue");
                    if(await checkAccessCode(accessCode,"Geometry")){
                        Debug.Log("Geometry access code is successful");
                        CloseCountryGuard(GameObject.Find("Geometry_Entrance_Guard"));
                        specificDialogue.SetActive(false);
                        Player.GetComponent<PlayerMovement>().enabled = true;
                    } else {
                         Text[] textComponents = specificDialogue.GetComponentsInChildren<Text>();
                         foreach(Text textComponent in textComponents) {
                            if (textComponent.name.Contains("Error_message")){
                                textComponent.enabled = true;
                            }
                        }
                    }
                    
                    break;

                case "WholeNumber_Entrance_Dialogue":
                    Debug.Log("I am in Whole Number Dialogue");
                    if(await checkAccessCode(accessCode,"Whole_Numbers")){
                        Debug.Log("Whole Numbers access code is successful");
                        CloseCountryGuard(GameObject.Find("WholeNumber_Entrance_Guard"));
                        specificDialogue.SetActive(false);
                        Player.GetComponent<PlayerMovement>().enabled = true;
                    } else {
                         Text[] textComponents = specificDialogue.GetComponentsInChildren<Text>();
                         foreach(Text textComponent in textComponents) {
                            if (textComponent.name.Contains("Error_message")){
                                textComponent.enabled = true;
                            }
                        }
                    }
                    
                    break;
                
                case "Species_Entrance_Dialogue":
                    Debug.Log("I am in Species Dialogue");
                    if(await checkAccessCode(accessCode,"Species")){ // Change to Species URL
                        Debug.Log("Species access code is successful");
                        CloseCountryGuard(GameObject.Find("Species_Entrance_Guard"));
                        specificDialogue.SetActive(false);
                        Player.GetComponent<PlayerMovement>().enabled = true;
                    } else {
                         Text[] textComponents = specificDialogue.GetComponentsInChildren<Text>();
                         foreach(Text textComponent in textComponents) {
                            if (textComponent.name.Contains("Error_message")){
                                textComponent.enabled = true;
                            }
                        }
                    }
                    break;
            } 
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void CloseCountryGuard(GameObject specificGuard){
        try
        {
            //  animator_guard.SetBool("IsOpen",false);\\
            Debug.Log("in close country guard");

            specificGuard.SetActive(false);
            if (specificGuard == geometry_guard){  
                geometryAccessStatus = true;
                specificGuard.SetActive(false);
            }
            else if (specificGuard == wholenumber_guard){
                wholenumberAccessStatus = true;
                specificGuard.SetActive(false);
            }
            else if (specificGuard == species_guard){
                speciesAccessStatus = true;
                specificGuard.SetActive(false);
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public async Task<bool> checkAccessCode(string accessCode, string country)
    {
         //Load from DB
        var url = "ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/getAccessCode/" + country;
        Debug.Log(country);
        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while(!operation.isDone) {
            await Task.Yield();
        }
        
        var jsonResponse = www.downloadHandler.text;
        string[] jsonResponseArray =  JsonConvert.DeserializeObject<string[]>(jsonResponse);
        jsonResponse = jsonResponseArray[0];
        
        Debug.Log(jsonResponse);
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log($"Failed: {www.error}");
        }

        try {
            Debug.Log($"Success: {www.downloadHandler.text}");
            

            if (jsonResponse == accessCode) {
                return true;
            }

            return false;
        } catch(Exception e) {
            Debug.LogError($"Could not parse response: {jsonResponse}. {e.Message}");
            return false;
        }
    }


}
