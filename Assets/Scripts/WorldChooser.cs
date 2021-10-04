using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChooser : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject Player;

    public void OpenDialogueBox() 
    {
        try
        {
        DialogueBox.transform.position = Player.transform.position;
        
        DialogueBox.transform.position = DialogueBox.transform.position + new Vector3(3,3,0);

        //animator.SetBool("IsOpen", true);
        
        Debug.Log(DialogueBox.transform.position);
        }
        catch (System.Exception)
        {   
            throw;
        }
    }

    public void CloseDialogueBox() 
    {
        //animator.SetBool("IsOpen", false);
        DialogueBox.transform.position = DialogueBox.transform.position + new Vector3(3000,0,0);
    }

}
