using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryDropdownHandler : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;
    public static GameObject reportPopup;
    // Start is called before the first frame update
    void Start()
    {
        //var dropdown = transform.GetComponent<TMP_Dropdown>();
        var parentName = transform.parent.gameObject.name;
        dropdown = transform.parent.gameObject.GetComponentInChildren<TMPro.TMP_Dropdown>();
        Debug.Log(parentName);

        dropdown.options.Clear();
        dropdown.RefreshShownValue();

        List<string> items = new List<string>();
        if (parentName == "Summary - Input")
        {
            items.Add("None");
            items.Add("Item 1");
            items.Add("Item 2");
        }
        else if (parentName == "Summary - Generate Report")
        {
            items.Add("None");
            items.Add("Choice 1");
            items.Add("Choice 2");
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

    public void generateButtonClicked(GameObject generateReport)
    {
        ButtonHandlers.summaryReport.SetActive(false);
        reportPopup = generateReport;
        generateReport.SetActive(true);
    }

    public void backToCommand()
    {
        reportPopup.SetActive(false);
    }
}

