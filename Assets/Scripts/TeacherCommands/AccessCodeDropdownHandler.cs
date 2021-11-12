using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessCodeDropdownHandler : MonoBehaviour
{
    public TMPro.TMP_Dropdown worldDropdown;
    public TMPro.TMP_Dropdown countryDropdown;
    public TMPro.TMP_Dropdown classDropdown;
    public static string selectedWorldFromAccessCode;
    public static string selectedCountryFromAccessCode;
    public TMPro.TMP_Text TextBox;

    private string[] worldData; 
    private string[] countryData;

    // Start is called before the first frame update
    async void Start()
    {
        selectedWorldFromAccessCode = "None";
        selectedCountryFromAccessCode = "None";

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
        countryData = await AccessCodeCountryInput.loadFromDB();
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

    }

    async void UpdateCountryDropdown(TMPro.TMP_Dropdown dropdown)
    {
        TextBox = dropdown.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        dropdown.options.Clear();
        string[] data = await AccessCodeCountryInput.loadFromDB();
        List<string> items = new List<string>();
        foreach(var item in data)
        {
            items.Add(item);
        }
        dropdown.AddOptions(items);
        TextBox.text = dropdown.options[dropdown.value].text;
    }

    void DropdownItemSelected(TMPro.TMP_Dropdown dropdown)
    {
        TextBox = dropdown.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        int index = dropdown.value;
        if (dropdown.name == "Dropdown-World")
        {
            selectedWorldFromAccessCode = dropdown.options[index].text;
        }
        else if (dropdown.name == "Dropdown-Country")
        {
            selectedCountryFromAccessCode = dropdown.options[index].text;
        }
        TextBox.text = dropdown.options[index].text;
    }
}


