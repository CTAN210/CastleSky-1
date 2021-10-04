using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseMenu;

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
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void load_next_scene (string scene_name){
        SceneManager.LoadScene(scene_name);
        Time.timeScale = 1f;
    }
}
