using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    float currentTime = 0;
    float startTime = 60;
    public CoinRules cr;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
        GameComplete();
    }

    public GameObject LevelCompleteUi;
    public GameObject LevelFailUi;
    private int score;
    private float multiplier;
    public void GameEnd(bool levelPassed)
    {
        if (levelPassed) 
        {
            print(currentTime);
            // Add method to update leaderboard
            if (currentTime == 0) {
                multiplier = 1;
            } else {
                multiplier = currentTime;
            }
            score =  (int) (cr.correctCounter * multiplier);
            LevelCompleteUi.transform.Find("Panel/Score").GetComponent<Text>().text = "SCORE: " +score.ToString();
            LevelCompleteUi.SetActive(true);
            // Send score to back end 
                if (CityEntrance.Scenes.getParam("level") == "10")
                {
                    Debug.Log("Final Level- Player Score: " + score.ToString());
                }   

        } 
        else 
        {
            LevelFailUi.SetActive(true);
        }
    }

    public void GameComplete()
    {
        if (cr.islevelCompleted) {
            cr.questionHolder.GetComponent<TextMeshPro>().text = "";
            // print(cr.correctCounter);
            Time.timeScale = 0;
            GameEnd(cr.islevelPassed);
            cr.islevelCompleted = false;
        }
    }

    public void updateTime() {
        if (currentTime > 0) {
            currentTime -= 1 * Time.deltaTime;
        } else {
            currentTime = 0;
        }
    }
}
