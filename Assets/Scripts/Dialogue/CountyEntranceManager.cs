using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    static bool geometryAccessStatus;
    static bool wholenumberAccessStatus;
    static bool speciesAccessStatus;



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

    void Update(){
        if(accessCodeInputField.GetComponent<InputField>().isFocused == true)
        {
            // Debug.Log ("input field in focus");
            Player.GetComponent<PlayerMovement>().enabled = false;
            
        } else{
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
        

    }

    public void OpenCountryEntrance(GameObject specificDialogue){
        Debug.Log ("Starting Dialogue with player 1");

        try
        {
            Debug.Log("in try of open country entrance");
            specificDialogue.SetActive(true);
        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    public void CloseCountryEntrance(GameObject specificDialogue){
        try
        {
             specificDialogue.SetActive(false);
             Debug.Log("reset input field");
             accessCodeInputField.GetComponent<InputField>().text = "";
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void CloseCountryGuard(GameObject specificGuard){
        try
        {
            //  animator_guard.SetBool("IsOpen",false);
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
                wholenumberAccessStatus = true;
                specificGuard.SetActive(false);
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    


}
