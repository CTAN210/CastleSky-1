using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public AddButtons addButtons = new AddButtons();
    // Start is called before the first frame update
    System.Random rnd = new System.Random(); 

    [SerializeField]
    public Sprite bgImage;

    public GameOverScreen GameOverScreen;

    public HelpScreen HelpScreen;
    
    public Sprite[] puzzles; 
    public Sprite[] puzzles1;

    public List<Sprite> gamePuzzles = new List<Sprite>();    
    
    public List<Button> buttonList = new List<Button>();

    private bool firstGuess, secondGuess;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/1");
        puzzles1 = Resources.LoadAll<Sprite>("Sprites/1");
    }

    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2; // total puzzles to solve
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        

        for(int i = 0; i < objects.Length; i++)
        {
            buttonList.Add(objects[i].GetComponent<Button>());
            buttonList[i].image.sprite = bgImage;
        }
    }
    void AddGamePuzzles() // get the images we using from puzzle library for the game 
    {
        IEnumerable<UnityEngine.Sprite> tempSprites;
        int buttonCount = buttonList.Count;
        int puzzlesCount = puzzles.Length;


        if (puzzlesCount < (buttonCount/2) )
        {
            /*Debug.Log("in Loop");*/
            int numOfRepeats = (buttonCount / 2) - puzzlesCount;
            tempSprites = puzzles;
            Debug.Log("TS COUNT: " + tempSprites.Count());
            IEnumerable<UnityEngine.Sprite>  repeatedSprites = puzzles.OrderBy(x => rnd.Next()).Take(numOfRepeats);
            tempSprites = tempSprites.Concat(repeatedSprites);
            Debug.Log("TS COUNT: "+ tempSprites.Count());
        } else
        {
            tempSprites = puzzles.OrderBy(x => rnd.Next()).Take(buttonCount / 2); 
        }

        foreach(Sprite sprite in tempSprites)
        {
            gamePuzzles.Add(sprite);
            gamePuzzles.Add(Array.Find(puzzles1, s => s.name == sprite.name));
        }
    }

    void AddListeners() // must be below getButtons - because need buttonList to be filled 
    {
        foreach(Button btn in buttonList)
        {
            btn.onClick.AddListener(() => pickAPuzzle());
        }
    }

    
    // Pick a puzzle - is a function of a button - aka a listener 
    public void pickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("You have click " + name);

        if (!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            
            // flip the card to from cardBack to front image
            buttonList[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

            // make the button unclickable after clicking on it
            buttonList[firstGuessIndex].enabled = false; 
            
        } else if (!secondGuess)
        {
            secondGuess = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            buttonList[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            // make the button unclickable after clicking on it
            buttonList[secondGuessIndex].enabled = false;

            countGuesses++;

            //Update Guess counter UI
            ScoreManager.instance.AddGuess();

            StartCoroutine(CheckIfThePuzzleMatch());

            if (firstGuessPuzzle == secondGuessPuzzle)
            {
                Debug.Log("Match!");
            } else
            {
                Debug.Log("Not Match.");
            }

        }
    }

    IEnumerator CheckIfThePuzzleMatch()
    {
        yield return new WaitForSeconds(0.75f); // wait second

        if (firstGuessPuzzle == secondGuessPuzzle) // Guess Correctly
        {
            yield return new WaitForSeconds(.3f);

            // Disable the buttons by make the buttons not interactable after correct guess
            buttonList[firstGuessIndex].interactable = false;
            buttonList[secondGuessIndex].interactable = false;

            // hide the buttons(cards) after correct guess
            buttonList[firstGuessIndex].image.color = new Color(0, 0, 0, 0); 
            buttonList[secondGuessIndex].image.color = new Color(0, 0, 0, 0); 
            
            CheckIfTheGameIsFinished();
        } else
        {
            yield return new WaitForSeconds(.3f);

            // make the buttons clickable again
            buttonList[firstGuessIndex].enabled = buttonList[secondGuessIndex].enabled = true; 

            // flip the card back by setting the image to the cardbgimage
            buttonList[firstGuessIndex].image.sprite = bgImage;
            buttonList[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.3f);

        //reset firstGuess and SecondGuess - as we have alr flipped them back 
        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished() 
    {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses)
        {
            int playerScore = CalculatePlayerScore(countGuesses, gameGuesses);
            GameOver(playerScore);
            Debug.Log("Game has completed");
            Debug.Log("It took you " + countGuesses + " tries to complete the game. "); 
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public int CalculatePlayerScore(int countGuesses, int gameGuesses){
        int playerScore;
        double maxGuesses;
        double maxScore; 
        double playerPoints;
        string level = LevelSelectionScreen.Scenes.getParam("level");
        
        switch (level)
        {
            case "1":
                maxGuesses = gameGuesses * 1; 
                break;
            case "2":
                maxGuesses = gameGuesses * 2; 
                break;            
            case "3":
                maxGuesses = gameGuesses * 3; 
                break;
            default:
                maxGuesses = gameGuesses;
                break;
        }
        
        int excessGuessPenalty = (countGuesses-gameGuesses) * 5; // Deduct 5 pints for each 
        maxScore = maxGuesses*20;

        playerPoints = ((maxScore - excessGuessPenalty)/maxScore) * 100;

        print(playerPoints);

        playerScore = (int) playerPoints;

        return playerScore;
    }
    
    public void GameOver(int playerScore)
    {
        GameOverScreen.Setup(playerScore);
    }

    public void HelpButton()
    {
        HelpScreen.Setup();

    }

}
