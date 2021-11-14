using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public static GameManager GUIinstance;

	public GameObject faderObj;
	public GameObject InstructionsPanel;
	public Image faderImg;
	public bool gameOver = false;
	public static int level;
	public static int finalLevel;
	public Text levelTxt;
	public float fadeSpeed = .02f;

	private Color fadeTransparency = new Color(0, 0, 0, .04f);
	private string currentScene;
	private AsyncOperation async;

	void Awake() {
		// Only 1 Game Manager can exist at a time
		finalLevel = 3;
		if (instance == null) {
			DontDestroyOnLoad(gameObject);
			if (CityEntrance.Scenes.getParam("level") == finalLevel.ToString()){
            	levelTxt.text = "Final Level" ; // Displays Final level 
			} else {
				levelTxt.text = "Level " + CityEntrance.Scenes.getParam("level"); // Displays level 
			}
			instance = GetComponent<GameManager>();
			SceneManager.sceneLoaded += OnLevelFinishedLoading;
		} else {
			Destroy(gameObject);
		}
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (CityEntrance.Scenes.getParam("level") == finalLevel.ToString()){
            	levelTxt.text = "Final Level" ; // Displays Final level 
			} else {
				levelTxt.text = "Level " + CityEntrance.Scenes.getParam("level"); // Displays level 
			}
			ReturnToMenu();
		}
	}

	// Load a scene with a specified string name
	public void LoadScene(string sceneName) {
		// level = Int32.Parse(sceneName.Split('-')[1]);
		level = Int32.Parse(CityEntrance.Scenes.getParam("level"));
		sceneName = sceneName.Split('-')[0];
		Debug.Log(level);
		Debug.Log(finalLevel);
		print(sceneName);
		instance.StartCoroutine(Load(sceneName));
		instance.StartCoroutine(FadeOut(instance.faderObj, instance.faderImg));
	}

	// Reload the current scene
	public void ReloadScene() {
		LoadScene(SceneManager.GetActiveScene().name.ToString()+"-"+level);
	}

	private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		currentScene = scene.name;
		instance.StartCoroutine(FadeIn(instance.faderObj, instance.faderImg));
	}

	//Iterate the fader transparency to 100%
	IEnumerator FadeOut(GameObject faderObject, Image fader) {
		faderObject.SetActive(true);
		while (fader.color.a < 1) {
			fader.color += fadeTransparency;
			yield return new WaitForSeconds(fadeSpeed);
		}
		ActivateScene(); //Activate the scene when the fade ends
	}

	// Iterate the fader transparency to 0%
	IEnumerator FadeIn(GameObject faderObject, Image fader) {
		while (fader.color.a > 0) {
			fader.color -= fadeTransparency;
			yield return new WaitForSeconds(fadeSpeed);
		}
		faderObject.SetActive(false);
	}

	// Begin loading a scene with a specified string asynchronously
	IEnumerator Load(string sceneName) {
		async = SceneManager.LoadSceneAsync(sceneName);
		async.allowSceneActivation = false;
		yield return async;
		isReturning = false;
    }

	// Allows the scene to change once it is loaded
	public void ActivateScene() {
		async.allowSceneActivation = true;
	}

	// Get the current scene name
	public string CurrentSceneName {
		get{
			return currentScene;
		}
	}

	public void ExitGame() {
		Vector3 playerPositionVector = new Vector3();
        playerPositionVector = CityEntrance.Scenes.getPosition("position");
        CityEntrance.Scenes.Load("Science World Scene","level","0","position",playerPositionVector);
	}

	private bool isReturning = false;
	public void ReturnToMenu() {
		SceneManager.LoadScene("MatchMeMenu");

	}



}
