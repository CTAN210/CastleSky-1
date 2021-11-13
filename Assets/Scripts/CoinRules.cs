using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CoinRules : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CoinSpawner();
    }
    public int correctCounter = 0;
    public bool islevelPassed = false;
    public bool islevelCompleted;
    int passingScore;
     void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.transform.tag == "Coin") {
            GameObject eatenCoin = collisionInfo.gameObject;
            var textobject = eatenCoin.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text;
            if (textobject == answer[questionCounter]) {
                correctCounter++;
            }
            questionCounter++;
            if (questionCounter == question.Length) {
               islevelCompleted = true;
               DestroyAllCoins();
               if (correctCounter == question.Length) {
                   islevelPassed = true;
               }
            } else {
                CoinSpawner();
            }
            
        }
    }

    
    public int noOfCoins;
    public GameObject CoinPrefab;
    public GameObject bounds;
    public GameObject questionHolder;
    public GameObject levelHolder;
    private float coinWidth, coinHeight;
    private int questionCounter = 0;
    private string raw;
    private string[] question;
    private string[] answer;
    public int level;

    public async void CoinSpawner()
    {   
        level = Int32.Parse(CityEntrance.Scenes.getParam("level"));
        Debug.Log("Level: "+ level);
        if (level == 10){
            levelHolder.GetComponent<TextMeshPro>().text = "Final Level" ; // Displays Final level 
			} else {
                levelHolder.GetComponent<TextMeshPro>().text = "Level " + level.ToString(); // Displays level 
			}
        // levelHolder.GetComponent<TextMeshPro>().text = "Level " + level.ToString();
        levelHolder.GetComponent<TextMeshPro>().color = new Color(0, 0, 120, 225);
        if (question == null) {
           raw = await loadFromDb(level);
           Debug.Log("Level: "+ level);
           question = raw.Split('-')[0].Split('|');
           answer = raw.Split('-')[1].Split('|');
           Time.timeScale = 1;
        }
        print(raw);
        coinWidth = CoinPrefab.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        coinHeight = CoinPrefab.transform.GetComponent<SpriteRenderer>().bounds.size.y;
        DestroyAllCoins();
        GameObject toSpawn, spawned;
        MeshCollider collider = bounds.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;
        for(int i = 0; i < noOfCoins; i++)
        {
            questionHolder.GetComponent<TextMeshPro>().text = question[questionCounter];
            questionHolder.GetComponent<TextMeshPro>().color = new Color(0, 0, 120, 255);

            toSpawn = CoinPrefab;
            screenX = UnityEngine.Random.Range(collider.bounds.min.x + (coinWidth / 2), collider.bounds.max.x - (coinWidth / 2));
            screenY = UnityEngine.Random.Range(collider.bounds.min.y + (coinHeight / 2), collider.bounds.max.y - (coinHeight / 2) - 1.5f);
            pos = new Vector2(screenX, screenY);
            spawned = Instantiate(toSpawn, pos, toSpawn.transform.rotation);

            if (i == 0) {
                spawned.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = answer[questionCounter];    
            } else {
                spawned.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = UnityEngine.Random.Range(1,20).ToString();
            }
            spawned.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().color = new Color(0, 0, 120, 255);
        }
    }

    private void DestroyAllCoins()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Coin")) {
            Destroy(o);
        }
    }

    public async Task<String> loadFromDb(int id)
    {
        //Load from DB
        var url = "ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/questions";

        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while(!operation.isDone) {
            await Task.Yield();
        }
        
        var jsonResponse = www.downloadHandler.text;

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log($"Failed: {www.error}");
        }

        try {
            var result = JsonConvert.DeserializeObject<Question[]>(jsonResponse);
            Debug.Log($"Success: {www.downloadHandler.text}");

            for (int i = 0; i < result.Length; i++) {
                if (result[i].id == id) {
                    return result[i].Questions + "-" + result[i].Answers;
                }
            }
            return null;
        } catch(Exception e) {
            Debug.LogError($"Could not parse response: {jsonResponse}. {e.Message}");
            return null;
        }
    }
}
