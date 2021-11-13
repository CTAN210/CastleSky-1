using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public static GUIManager instance;

	public GameObject gameOverPanel;
	public Text yourScoreTxt;
	public Text highScoreTxt;

	public Text levelTxt;

	public Text scoreTxt;
	public Text moveCounterTxt;

	private int score;
	private int moveCounter;

	public int Score {
    get {
        return score;
    }

		set {
			score = value;
			scoreTxt.text = score.ToString();
			
		}
	}

	public int MoveCounter {
			get {
					return moveCounter;
			}

			set {
					moveCounter = value;
					if (moveCounter <= 0) {
						moveCounter = 0;
						StartCoroutine(WaitForShifting());
					}

					moveCounterTxt.text = moveCounter.ToString();
			}
	}

	
	void Awake() {
		moveCounter = 10; // change this number to set how many moves the player can make
		moveCounterTxt.text = moveCounter.ToString();
		if (GameManager.level == GameManager.finalLevel){
            levelTxt.text = "Final Level" ; // Displays Final level 
        } else {
            levelTxt.text = "Level " + GameManager.level; // Displays level 
        }
		instance = GetComponent<GUIManager>();
	}

	// Show the game over panel
	public void GameOver() {
		GameManager.instance.gameOver = true;
		// BoardManager.SetActive(false);
		gameOverPanel.SetActive(true);

		if (score > PlayerPrefs.GetInt("HighScore")) {
			PlayerPrefs.SetInt("HighScore", score);
			highScoreTxt.text = "New Best: " + PlayerPrefs.GetInt("HighScore").ToString();
		} else {
			highScoreTxt.text = "Best: " + PlayerPrefs.GetInt("HighScore").ToString();
		}

		yourScoreTxt.text = score.ToString();

		// Send score to DB if final level
		if (GameManager.level == GameManager.finalLevel){
            Debug.Log("Final Level- Player Score: " + score);
        }
	}

	private IEnumerator WaitForShifting() {
    yield return new WaitUntil(()=> !BoardManager.instance.IsShifting);
    yield return new WaitForSeconds(.25f);
    GameOver();
	}


}
