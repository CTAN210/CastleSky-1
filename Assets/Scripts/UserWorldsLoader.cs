using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UserWorldsLoader : MonoBehaviour
{
    public UserWorlds userWorlds;

    public GameObject mathWorld;
    public GameObject scienceWorld;
    public GameObject englishWorld;
    public GameObject helloText;
    static int actualuserclassId;
    static bool isMathActive;
    static bool isScienceActive;
    static bool isEnglishActive;

    void Start()
    {
        if (helloText != null){
            string userName = CityEntrance.Scenes.getParam("userName");
            var text = helloText.GetComponent<Text>();
            text.text = "Hello, " + userName + "!";
        }
    }

    public async void getStudentWorlds()
    {
        if (actualuserclassId.Equals(0))
        {
            actualuserclassId = Int32.Parse(CityEntrance.Scenes.getParam("userId"));
            Debug.Log("User's Class is : " + actualuserclassId);
            string[] userWorlds = await UserWorlds.loadUserWorlds(actualuserclassId);

            foreach(string world in userWorlds) {
                switch(world) {
                    case "Math":
                        isMathActive = true;
                        break;
                    case "Science":
                        isScienceActive = true;
                        break;
                    case "English":
                        isEnglishActive = true;
                        break;
                }
             }
        }
        if (isMathActive){
            mathWorld.SetActive(true);
        }
        if (isScienceActive){
            scienceWorld.SetActive(true);
        }
        if (isEnglishActive){
            englishWorld.SetActive(true);
        }
        
    }
    
}
