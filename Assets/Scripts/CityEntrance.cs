using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class CityEntrance : MonoBehaviour
{
    [SerializeField] private GameObject entrancePopup;
    public GameObject entrance;
    public string sceneToLoad;
    public bool playerInRange;

    void Start()
    {
        //want to change to entrance but not working
        entrance = GameObject.Find("Player");
        playerInRange = false;
        entrancePopup.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange == true){
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Player has entered entrance");
        if (other.CompareTag("Player") && !other.isTrigger){
            playerInRange = true;
            entrancePopup.SetActive(true);
            entrancePopup.transform.position = entrance.transform.position + new Vector3(2,2,0);
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
