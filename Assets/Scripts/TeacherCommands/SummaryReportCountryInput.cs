using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class SummaryReportCountryInput
{
    string userName { get; set; }
    int score{ get; set; }

     public static async Task<string[]> loadFromDB()
     {
        var url = "http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/getWorldCountries/" + Window_Graph.selectedWorldFromSummary;

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
            var result = JsonConvert.DeserializeObject<string[]>(jsonResponse);
            Debug.Log($"Success: {www.downloadHandler.text}");
            return result;
        } catch(Exception e) {
            Debug.LogError($"Could not parse response: {jsonResponse}. {e.Message}");
            return null;
        }
    }
}
