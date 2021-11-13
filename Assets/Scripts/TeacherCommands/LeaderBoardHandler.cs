using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardHandler : MonoBehaviour
{    
    public GameObject LeaderboardInput;
    public GameObject LeaderboardActual;
    public TMPro.TMP_Dropdown worldDropdown;
    public TMPro.TMP_Dropdown countryDropdown;
    public static string selectedWorldFromLeaderboard;
    public static string selectedCountryFromLeaderboard;
    public TMPro.TMP_Text TextBox;
    public LeaderboardResults result;

    private string[] worldData; 
    private string[] countryData;

    async void Start()
    {
        selectedWorldFromLeaderboard = "None";
        selectedCountryFromLeaderboard = "None";

        worldDropdown = GameObject.Find("Dropdown-World").GetComponentInChildren<TMPro.TMP_Dropdown>();
        worldDropdown.options.Clear();
        worldData = await AccessCodeWorldInput.loadFromDB();
        List<string> worldItems = new List<string>();
        foreach(var item in worldData)
        {
            worldItems.Add(item);
        }
        worldDropdown.AddOptions(worldItems);
        DropdownItemSelected(worldDropdown);
        worldDropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(worldDropdown);});
        worldDropdown.onValueChanged.AddListener(delegate {UpdateCountryDropdown(countryDropdown);});

        countryDropdown = GameObject.Find("Dropdown-Country").GetComponentInChildren<TMPro.TMP_Dropdown>();
        countryDropdown.options.Clear();
        countryData = await LeaderboardCountryInput.loadFromDB();
        List<string> countryItems = new List<string>();
        foreach(var item in countryData)
        {
            countryItems.Add(item);
        }
        countryDropdown.AddOptions(countryItems);
        DropdownItemSelected(countryDropdown);
        countryDropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(countryDropdown);});
    }

    void Update()
    {
         DropdownItemSelected(countryDropdown);
    }

    async void UpdateCountryDropdown(TMPro.TMP_Dropdown dropdown)
    {
        TextBox = dropdown.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        dropdown.options.Clear();
        string[] data = await LeaderboardCountryInput.loadFromDB();
        List<string> items = new List<string>();
        foreach(var item in data)
        {
            items.Add(item);
        };
        dropdown.AddOptions(items);
        TextBox.text = dropdown.options[dropdown.value].text;
    }

    void DropdownItemSelected(TMPro.TMP_Dropdown dropdown)
    {
        TextBox = dropdown.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (dropdown.name == "Dropdown-World")
        {
            selectedWorldFromLeaderboard = dropdown.options[dropdown.value].text;
        }
        else if (dropdown.name == "Dropdown-Country")
        {
            selectedCountryFromLeaderboard = dropdown.options[dropdown.value].text;
            // Debug.Log(dropdown.options[dropdown.value].text);
        }
        TextBox.text = dropdown.options[dropdown.value].text;
    }

    public void CloseLeaderboard(){
        LeaderboardInput.SetActive(false);
    }

    public void OpenLeaderboardActual(){
        LeaderboardInput.SetActive(false);
        LeaderboardActual.SetActive(true);
    }

    public void CloseLeaderboardActual(){
        LeaderboardActual.SetActive(false);
    }

    public void BackToLeaderboardInput(){
        LeaderboardActual.SetActive(false);
        LeaderboardInput.SetActive(true);
    }
}
