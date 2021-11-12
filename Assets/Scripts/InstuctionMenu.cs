using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstuctionMenu : MonoBehaviour
{
    public GameObject InstructionUi;
    private static GameObject previousUi;
    public static void setPreviousUi (GameObject Ui)
    {
        previousUi = Ui;
    }
    public void CloseInstruction()
    {
        Debug.Log("Close Instruction");
        previousUi.SetActive(true);
        InstructionUi.SetActive(false);
    }
}
