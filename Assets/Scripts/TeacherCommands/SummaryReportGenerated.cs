using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class SummaryReportGenerated
{
    public string UserName { get; set; }
    public int Score{ get; set; }

     public static async Task<SummaryReportGenerated[]> loadFromDB()
     {
        var url = "http://ec2-3-138-111-170.us-east-2.compute.amazonaws.com:3333/getSummaryReport/" + Window_Graph.selectedCountryFromSummary + "/" + SummaryDropdownHandler.summaryReportInputClass;

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
            var result = JsonConvert.DeserializeObject<SummaryReportGenerated[]>(jsonResponse);
            Debug.Log($"Success: {www.downloadHandler.text}");
            return result;
        } catch(Exception e) {
            Debug.LogError($"Could not parse response: {jsonResponse}. {e.Message}");
            return null;
        }
    }
}
