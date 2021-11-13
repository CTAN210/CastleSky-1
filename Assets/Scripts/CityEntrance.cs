using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using UnityEngine.EventSystems;

public class CityEntrance : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField] private GameObject entrancePopup;
    //public GameObject player;
    public bool playerInRange;
    public GameObject Player;
    string buildingName;
    string sceneToLoad;
    string level;
    string cityName;
    Button btn;
    GameObject city;

    

    void Start()
    {

        playerInRange = false;
        // Debug.Log(Scenes.getPosition("position"));

        if (Scenes.getPosition("position") != Vector3.zero)
        {
            Player.transform.position = Scenes.getPosition("position");
        }
        else{
            Player.transform.position = new Vector3(13,10,0);
        }
        // if (GameOverScreen.Scenes.getPosition("position") != Vector3.zero){
        //     Player.transform.position = GameOverScreen.Scenes.getPosition("position");
        // }

    }

    public void Update()
    {

    }

    public static class Scenes
    {

        private static Dictionary<string, string> parameters;
        private static Dictionary<string, Vector3> position;

        public static void Load(string sceneName, Dictionary<string, string> parameters = null)
        {
            Scenes.parameters = parameters;
            SceneManager.LoadScene(sceneName);
        }        
        public static void Load(string sceneName, Dictionary<string, string> parameters , string positionKey , Vector3 positionValue)
        {
            Scenes.parameters = parameters;
            Scenes.position = new Dictionary<string, Vector3>();
            Scenes.position.Add(positionKey, positionValue);
            SceneManager.LoadScene(sceneName);
        }

        public static void Load(string sceneName, string paramKey, string paramValue, string positionKey, Vector3 positionValue)
        {
            Scenes.parameters = new Dictionary<string, string>();
            Scenes.parameters.Add(paramKey, paramValue);
            Scenes.position = new Dictionary<string, Vector3>();
            Scenes.position.Add(positionKey, positionValue);
            SceneManager.LoadScene(sceneName);
        }


        public static Dictionary<string, string> getSceneParameters()
        {
            return parameters;
        }

        public static Dictionary<string, Vector3> getPlayerPosition()
        {
            return position;
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

        public static Vector3 getPosition(string positionKey)
        {
            
            if (position == null) return Vector3.zero;
            return position[positionKey];
        }

        public static void setPosition(string positionKey, Vector3 positionValue)
        {
            if (position == null)
                Scenes.position = new Dictionary<string, Vector3>();
            Scenes.position.Add(positionKey, positionValue);
        }

    }

	void TaskOnClick(){
        switch(buildingName){

            case "Geometry_1":
                sceneToLoad = "MatchingPairGameScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "Geometry_2":
                sceneToLoad = "MatchingPairGameScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "Geometry_3":
                sceneToLoad = "MatchingPairGameScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "WholeNumbers_1":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "WholeNumbers_2":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;            
                
            case "WholeNumbers_3":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "WholeNumbers_4":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;            
                
            case "WholeNumbers_5":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "WholeNumbers_6":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;            
                
            case "WholeNumbers_7":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "WholeNumbers_8":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "WholeNumbers_9":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "WholeNumbers_10":
                sceneToLoad = "MathManiacScene";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "Species_1":
                sceneToLoad = "MatchMeMenu";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "Species_2":
                sceneToLoad = "MatchMeMenu";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

            case "Species_3":
                sceneToLoad = "MatchMeMenu";
                cityName = buildingName.Split('_')[0]; 
                level = buildingName.Split('_')[1];
                break;

        }
        // SceneManager.LoadScene(sceneToLoad);
        if (cityName == "WholeNumbers"){
            cityName = "Whole Numbers";
        }
        Vector3 myvector = Player.transform.position;
        Dictionary<string, string> userDetails = new Dictionary<string, string>{};
        userDetails.Add("userId", SceneSwitcher.userId);
        userDetails.Add("level", level);
        userDetails.Add("cityName",cityName);

        Scenes.Load(sceneToLoad, userDetails, "position", myvector);
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Player has entered entrance");
        if (other.CompareTag("Player") && !other.isTrigger){
            playerInRange = true;
            buildingName = this.gameObject.name;
            //entrancePopup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = buildingName;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        Debug.Log("Player has left entrance");
        if (other.CompareTag("Player") && !other.isTrigger){
            playerInRange = false;
            btn.onClick.RemoveListener(TaskOnClick);
        }
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (playerInRange){
            city = GameObject.Find(name);
            city.GetComponent<Image>().color = new Color(192/255f ,192/255f, 192/255f);
            btn = city.GetComponentInChildren<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (playerInRange){
            city.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }
}
