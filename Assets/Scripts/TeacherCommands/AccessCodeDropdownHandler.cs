using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessCodeDropdownHandler : MonoBehaviour
{
    public TMPro.TMP_Dropdown worldDropdown;
    public TMPro.TMP_Dropdown countryDropdown;
    public TMPro.TMP_Dropdown classDropdown;
    public static string worldNameText;
    public static string countryNameText;
    // Start is called before the first frame update
    void Start()
    {
        worldNameText = "None";
        countryNameText = "None";

        worldDropdown = GameObject.Find("Dropdown-World").GetComponentInChildren<TMPro.TMP_Dropdown>();
        worldDropdown.options.Clear();
        List<string> worldItems = new List<string> {"None","Math", "Science"};
        worldDropdown.AddOptions(worldItems);
        DropdownItemSelected(worldDropdown);
        worldDropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(worldDropdown);});

        countryDropdown = GameObject.Find("Dropdown-Country").GetComponentInChildren<TMPro.TMP_Dropdown>();
        countryDropdown.options.Clear();
        List<string> countryItems = new List<string> {"None","WholeNumbers", "Geometry"};
        countryDropdown.AddOptions(countryItems);
        DropdownItemSelected(countryDropdown);
        countryDropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(countryDropdown);});

        classDropdown = GameObject.Find("Dropdown-Class").GetComponentInChildren<TMPro.TMP_Dropdown>();
        classDropdown.options.Clear();
        List<string> classItems = new List<string> {"None","Class 1", "Class 2"};
        classDropdown.AddOptions(classItems);
        DropdownItemSelected(classDropdown);
        classDropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(classDropdown);});
    }

    void Update()
    {
        if (worldNameText == "Math")
        {
            countryDropdown = GameObject.Find("Dropdown-Country").GetComponentInChildren<TMPro.TMP_Dropdown>();
            countryDropdown.options.Clear();
            List<string> items = new List<string> {"None","WholeNumbers", "Geometry"};
            countryDropdown.AddOptions(items);
        }
        else if (worldNameText == "Science")
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
        int index = dropdown.value;
        if (dropdown.name == "Dropdown-World")
        {
            worldNameText = dropdown.options[index].text;
        }
        else if (dropdown.name == "Dropdown-Country")
        {
            countryNameText = dropdown.options[index].text;
        }

        if (index == 0)
        {
            TextBox.text = "Please select an option";
        }
        else
        {
            TextBox.text = dropdown.options[index].text;
        }
    }
}


