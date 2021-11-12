using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClassDropdown : MonoBehaviour
{
    public TMPro.TMP_Dropdown userClassDropdown;
    public static string selectedClass;
    // Start is called before the first frame update
    void Start()
    {
        userClassDropdown.ClearOptions();
        List<string> classItems = new List<string>{"3A", "3B", "3C", "3D", "3E"};
        userClassDropdown.AddOptions(classItems);
        DropDownItemSelected(userClassDropdown);
        userClassDropdown.onValueChanged.AddListener(delegate
        {
            DropDownItemSelected(userClassDropdown);
        });
    }
    void DropDownItemSelected(TMPro.TMP_Dropdown dropdown)
    {
        selectedClass = dropdown.options[dropdown.value].text;
    }
}
