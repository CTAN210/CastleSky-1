using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountyEntranceManager : MonoBehaviour
{
    public Animator animator_dialogue;
    public Animator animator_guard;
    public GameObject accessCodeInputField;
    public GameObject Player;

    [SerializeField]
    static bool geometryAccessStatus;
    void Start()
    {
        if (geometryAccessStatus == true){
            animator_guard.SetBool("IsOpen",false);
        }
    }

    void Update(){
        if(accessCodeInputField.GetComponent<InputField>().isFocused == true)
        {
            // Debug.Log ("input field in focus");
            Player.GetComponent<PlayerMovement>().enabled = false;
            
        } else{
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
        

    }

    public void OpenCountryEntrance(){
        Debug.Log ("Starting Dialogue with player 1");

        try
        {
            Debug.Log("in try of open country entrance");
            animator_dialogue.SetBool("IsOpen", true);
        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    public void CloseCountryEntrance(){
        try
        {
             animator_dialogue.SetBool("IsOpen",false);
             Debug.Log("reset input field");
             accessCodeInputField.GetComponent<InputField>().text = "";
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void CloseCountryGuard(){
        try
        {
             animator_guard.SetBool("IsOpen",false);
            geometryAccessStatus = true;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    


}
