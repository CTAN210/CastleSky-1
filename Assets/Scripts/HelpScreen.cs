using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public void Setup()
    {
        Debug.Log("help screen setup");
        gameObject.SetActive(true); // to show the screen
    }

    public void ReturnToGameButton()
    {
        gameObject.SetActive(false); // to show the screen
    }
}
