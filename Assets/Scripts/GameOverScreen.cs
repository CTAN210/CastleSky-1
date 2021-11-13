using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Text guessText;


    public void Setup(int userScore)
    {
        gameObject.SetActive(true); // to show the screen
        // Send score to DB if level = 3 
        if (CityEntrance.Scenes.getParam("level") == GameController.finalLevel.ToString()){
            Debug.Log("Final Level- Player Score: " + userScore);
        }


        guessText.text = userScore.ToString() + " Points";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MatchingPairGameScene");
    }
    public void ExitButton()
    {
        // SceneManager.LoadScene("Math World Scene");
        Vector3 playerPositionVector = new Vector3();
        playerPositionVector = CityEntrance.Scenes.getPosition("position");
        CityEntrance.Scenes.Load("Math World Scene","level","0","position",playerPositionVector);
    }


}
