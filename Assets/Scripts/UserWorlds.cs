using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class UserWorlds
{
    public string userId { get; set; }
    public string Username { get; set; }
    public World[] Worlds { get; set; }

   public static async Task<string[]> loadUserWorlds(int userId)
    {
        //Load from DB
        var url = "http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/getStudentWorlds/" + userId;

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
            string[] result = JsonConvert.DeserializeObject<string[]>(jsonResponse);
            Debug.Log($"Success: {www.downloadHandler.text}");
            return result;
        } catch(Exception e) {
            Debug.LogError($"Could not parse response: {jsonResponse}. {e.Message}");
            return null;
        }
    }
}

public class World
{
    public int WorldId { get; set; }
    public string WorldName { get; set; }

}