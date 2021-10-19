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
    string buildingName;
    string sceneToLoad;
    Button btn;
    GameObject city;

    void Start()
    {
        playerInRange = false;
    }

    public void Update()
    {

    }

	void TaskOnClick(){
        sceneToLoad = "Science World Scene";
        switch(buildingName){

            case "Fractions_1":
                sceneToLoad = "Math World Scene";
                break;

            case "Fractions_2":
                //sceneToLoad = "Math World Scene";
                break;

            case "Fractions_3":
                //sceneToLoad = "Math World Scene";
                break;

            case "Fractions_4":
                //sceneToLoad = "Math World Scene";
                break;

            case "Fractions_5":
                //sceneToLoad = "Math World Scene";
                break;

            case "Fractions_6":
                sceneToLoad = "Math World Scene";
                break;

            case "Fractions_7":
                //sceneToLoad = "Math World Scene";
                break;

            case "Fractions_8":
                //sceneToLoad = "Math World Scene";
                break;

            case "Fractions_9":
                //sceneToLoad = "Math World Scene";
                break;

            case "Fractions_10":
                //sceneToLoad = "Math World Scene";
                break;
        }
        SceneManager.LoadScene(sceneToLoad);
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
