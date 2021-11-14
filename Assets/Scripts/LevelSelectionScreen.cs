using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionScreen : MonoBehaviour
{

    public static class Scenes
    {

        private static Dictionary<string, string> parameters;

        public static void Load(string sceneName, Dictionary<string, string> parameters = null)
        {
            Scenes.parameters = parameters;
            SceneManager.LoadScene(sceneName);
        }

        public static void Load(string sceneName, string paramKey, string paramValue)
        {
            Scenes.parameters = new Dictionary<string, string>();
            Scenes.parameters.Add(paramKey, paramValue);
            SceneManager.LoadScene(sceneName);
        }

        public static Dictionary<string, string> getSceneParameters()
        {
            return parameters;
        }

        public static string getParam(string paramKey)
        {
            if (parameters == null) return "";
            return parameters[paramKey];
        }

        public static void setParam(string paramKey, string paramValue)
        {
            if (parameters == null)
                Scenes.parameters = new Dictionary<string, string>();
            Scenes.parameters.Add(paramKey, paramValue);
        }

    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LevelSelectorButton(Button button)
    {
        // print(button.name);
        Scenes.Load("MatchingPairGameScene", "level", button.name);

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
