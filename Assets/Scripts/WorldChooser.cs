using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChooser : MonoBehaviour
{

    public GameObject Dialoguebox;
    public GameObject Player;
    public void OpenDialogueBox() 
    {
        try
        {
            Dialoguebox.SetActive(true);
            if (Player != null){
                Dialoguebox.transform.position = Player.transform.position + new Vector3(3,3,0);
            }
        }
        catch (System.Exception)
        {   
            throw;
        }
    }

    public void CloseDialogueBox() 
    {
        Dialoguebox.SetActive(false);
        //animator.SetBool("IsOpen", false);
    }

}
