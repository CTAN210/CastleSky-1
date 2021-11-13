using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isGamePaused;
    public GameObject Player;
    [SerializeField] GameObject pauseMenu;

    void Start() {
        isGamePaused = false;
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        //if 'esc' pressed
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isGamePaused){
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseMenu.transform.position = Player.transform.position + new Vector3(3,3,0);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void load_next_scene (string scene_name){
        Time.timeScale = 1f;
        ResumeGame();
        SceneManager.LoadScene(scene_name);
    }

    
}
