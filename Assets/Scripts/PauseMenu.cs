using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUi;
    public GameObject InstructionUi;
    public GameObject Snake;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void LoadMenu()
    {
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenInstruction()
    {
        Debug.Log("Open Instruction");
        pauseMenuUi.SetActive(false);
        InstructionUi.SetActive(true);
        InstuctionMenu.setPreviousUi(pauseMenuUi);
    }
}
