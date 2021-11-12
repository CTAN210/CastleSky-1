using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardHandler : MonoBehaviour
{    
    public GameObject LeaderboardInput;
    public GameObject LeaderboardActual;
    public TMPro.TMP_Dropdown worldDropdown;
    public TMPro.TMP_Dropdown countryDropdown;
    public string selectedWorld;
    public string selectedCountry;

    void Start()
    {
        selectedWorld = "None";
        selectedCountry = "None";

        worldDropdown = GameObject.Find("Dropdown-World").GetComponentInChildren<TMPro.TMP_Dropdown>();
        worldDropdown.options.Clear();
        List<string> worldItems = new List<string> {"None","Math", "Science"};
        worldDropdown.AddOptions(worldItems);
        DropdownItemSelected(worldDropdown);
        worldDropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(worldDropdown);});

        countryDropdown = GameObject.Find("Dropdown-Country").GetComponentInChildren<TMPro.TMP_Dropdown>();
        countryDropdown.options.Clear();
        List<string> countryItems = new List<string> {"None"};
        countryDropdown.AddOptions(countryItems);
        DropdownItemSelected(countryDropdown);
        countryDropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(countryDropdown);});
    }

    void Update()
    {
        if (selectedWorld == "Math")
        {
            countryDropdown = GameObject.Find("Dropdown-Country").GetComponentInChildren<TMPro.TMP_Dropdown>();
            countryDropdown.options.Clear();
            List<string> items = new List<string> {"None","WholeNumbers", "Geometry"};
            countryDropdown.AddOptions(items);
        }
        else if (selectedWorld == "Science")
        {
            countryDropdown = GameObject.Find("Dropdown-Country").GetComponentInChildren<TMPro.TMP_Dropdown>();
            countryDropdown.options.Clear();
            List<string> items = new List<string> {"None","Species", "Blood"};
            countryDropdown.AddOptions(items);
        }
    }

    void DropdownItemSelected(TMPro.TMP_Dropdown dropdown)
    {
        var TextBox = dropdown.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (dropdown.name == "Dropdown-World")
        {
            selectedWorld = dropdown.options[dropdown.value].text;
        }
        else if (dropdown.name == "Dropdown-Country")
        {
            selectedCountry = dropdown.options[dropdown.value].text;
        }

        if (dropdown.value == 0)
        {
            TextBox.text = "Please select an option";
        }
        else
        {
            TextBox.text = dropdown.options[dropdown.value].text;
        }
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
