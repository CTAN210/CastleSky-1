using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class LeaderBoardEntry
{
    int cityId { get; set; }
    int userId { get; set; }
    string userName { get; set; }
    int userClass { get; set; }
    int score{ get; set; }

     public async static Task<LeaderBoardEntry[]> loadFromDB()
     {
        var url = "";

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
            var result = JsonConvert.DeserializeObject<LeaderBoardEntry[]>(jsonResponse);
            Debug.Log($"Success: {www.downloadHandler.text}");
            return result;
        } catch(Exception e) {
            Debug.LogError($"Could not parse response: {jsonResponse}. {e.Message}");
            return null;
        }
    }
}
