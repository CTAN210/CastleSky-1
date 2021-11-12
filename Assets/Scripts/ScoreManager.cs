using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text guessText;
    public Text levelText;
    
    int guess = 0;

    private void Awake()
    {
        instance = this; // set an instance of this method 
    }

    void Start()
    {
        guessText.text = guess.ToString() + " Guess(es)"; // displays guessCount
        levelText.text = "Level " + CityEntrance.Scenes.getParam("level"); // Displays level 

    }

    // Update is called once per frame
    public void AddGuess()
    {
        guess++;
        guessText.text = guess.ToString() + " Guess(es)"; // update guessCounter 
    }
}
