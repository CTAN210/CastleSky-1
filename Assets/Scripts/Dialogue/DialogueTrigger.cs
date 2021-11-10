using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Animator animator_dialogue;
    public Animator animator_guard;



    public void OpenCountryEntrance(){
        Debug.Log ("Starting Dialogue with player");
        
        try
        {
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
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }


}
