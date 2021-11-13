using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
	public GameObject instructionsImg;
    public GameObject level_1;
    public GameObject level_2;
    public GameObject level_3;
    public GameObject OkButton;
    // public Text levelTxt;

    // Start is called before the first frame update
    void Start()
    {
        // //instructionsImg = GameObject.Find("Instructions");
        // if (GameManager.level == GameManager.finalLevel){
        //     levelTxt.text = "Final Level" ; // Displays Final level 
        // } else {
        //     levelTxt.text = "Level " + GameManager.level; // Displays level 
        // }
    }

    // Update is called once per frame
    void Update()
    {
        //instructionsImg.gameObject.SetActive(true);      
    }

    public void OpenImage(){
        instructionsImg.gameObject.SetActive(true);
        OkButton.gameObject.SetActive(true);
    }

    public void OpenLevelImage(){
        switch (GameManager.level) {
            case 1:
                instructionsImg = level_1;
                break;
            case 2:
                instructionsImg = level_2;
                break;
            case 3:
                instructionsImg = level_3;
                break;
            default:
                instructionsImg = level_1;
                break;
        }
        GameObject.Find("GUIManagerCanvas").transform.Find("Level Label").gameObject.SetActive(false);
        instructionsImg.gameObject.SetActive(true);
        OkButton.gameObject.SetActive(true);
    }

    public void CloseImage(){
        instructionsImg.gameObject.SetActive(false);
        OkButton.gameObject.SetActive(false);
    }

    public void CloseLevelImage(){
        switch (GameManager.level) {
            case 1:
                instructionsImg = level_1;
                break;
            case 2:
                instructionsImg = level_2;
                break;
            case 3:
                instructionsImg = level_3;
                break;
            default:
                instructionsImg = level_1;
                break;
        }
        instructionsImg.gameObject.SetActive(false);
        OkButton.gameObject.SetActive(false);
        GameObject.Find("GUIManagerCanvas").transform.Find("Level Label").gameObject.SetActive(true);
    }

}
