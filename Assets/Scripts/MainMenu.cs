using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject Snake;
    public CoinRules coinRules;
    public GameObject InstructionUi;
    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 0;
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
        // Debug.Log("Quit Game");
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
