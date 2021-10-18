using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class CityEntrance : MonoBehaviour
{
    [SerializeField] private GameObject entrancePopup;
    public GameObject player;
    public bool playerInRange;
    string buildingName;
    string sceneToLoad;

    void Start()
    {
        player = GameObject.Find("Player");
        playerInRange = false;
        entrancePopup.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange == true){
            if (buildingName == "Fractions_1"){
                sceneToLoad = "Math World Scene";
            }
            else if (buildingName == "Fractions_2"){
                sceneToLoad = "Science World Scene";
            }
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Player has entered entrance");
        if (other.CompareTag("Player") && !other.isTrigger){
            playerInRange = true;
            entrancePopup.SetActive(true);
            entrancePopup.transform.position = player.transform.position + new Vector3(2,2,0);
            buildingName = this.gameObject.name;
            entrancePopup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = buildingName;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        Debug.Log("Player has left entrance");
        if (other.CompareTag("Player") && !other.isTrigger){
            entrancePopup.SetActive(false);
            playerInRange = false;
        }
    }
}
