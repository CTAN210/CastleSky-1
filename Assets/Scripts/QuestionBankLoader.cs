
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


public class QuestionBankLoader : MonoBehaviour
{
    [ContextMenu("Test Get")]
    public async void loadFromDb()
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
            Debug.Log(result[0].Questions);
            Debug.Log($"Success: {www.downloadHandler.text}");
        } catch(Exception e) {
            Debug.LogError($"{this} Could not parse response: {jsonResponse}. {e.Message}");
        }
    }
}