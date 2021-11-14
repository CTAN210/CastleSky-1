using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject Snake;
    public CoinRules coinRules;
    public GameObject InstructionUi;
    public Text levelTxt;
    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 0;

        if (CityEntrance.Scenes.getParam("level") == "10"){
                levelTxt.text = "Final Level" ; // Displays Final level 
			} else {
                levelTxt.text = "Level " + CityEntrance.Scenes.getParam("level"); // Displays level 
			}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Game Start");
        MainMenuUI.SetActive(false);
        Snake.SetActive(true);
        // Time.timeScale = 1;
    }

    public void QuitGame()
    {
        //redirect to main game
        Vector3 playerPositionVector = new Vector3();
        playerPositionVector = CityEntrance.Scenes.getPosition("position");
        CityEntrance.Scenes.Load("Math World Scene","level","0","position",playerPositionVector);
        Time.timeScale = 1;

    }

     public void OpenInstruction()
    {
        Debug.Log("Open Instruction");
        MainMenuUI.SetActive(false);
        InstructionUi.SetActive(true);
        InstuctionMenu.setPreviousUi(MainMenuUI);
    }
}
