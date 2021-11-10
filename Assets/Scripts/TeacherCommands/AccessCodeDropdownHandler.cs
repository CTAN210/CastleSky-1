using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessCodeDropdownHandler : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;
    public static GameObject socialMediaPopup;
    // Start is called before the first frame update
    void Start()
    {
        //var dropdown = transform.GetComponent<TMP_Dropdown>();
        var componentName = this.gameObject.name;
        dropdown = this.gameObject.GetComponentInChildren<TMPro.TMP_Dropdown>();
        Debug.Log(componentName);

        dropdown.options.Clear();

        List<string> items = new List<string>();
        if (componentName == "Dropdown-World")
        {
            items.Add("None");
            items.Add("World 1");
            items.Add("World 2");
        }
        else if (componentName == "Dropdown-Country")
        {
            items.Add("None");
            items.Add("Country 1");
            items.Add("Country 2");
        }
        else if (componentName == "Dropdown-Class")
        {
            items.Add("None");
            items.Add("Class 1");
            items.Add("Class 2");
        }

        //Fill dropdown with items
        foreach(var item in items)
        {
            dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData() {text = item});
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});
    }

    void DropdownItemSelected(TMPro.TMP_Dropdown dropdown)
    {
        var TextBox = dropdown.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        int index = dropdown.value;
        if (index == 0)
        {
            TextBox.text = "Please select an option";
        }
        else
        {
            TextBox.text = dropdown.options[index].text;
        }
    }

    public void generateButtonClicked(GameObject socialMedia)
    {
        ButtonHandlers.accessCode.SetActive(false);
        socialMediaPopup = socialMedia;
        socialMedia.SetActive(true);
    }

    public void backToCommand()
    {
        socialMediaPopup.SetActive(false);
    }
}


