using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SummaryDropdownHandler : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;
    public static GameObject reportPopup;
    public static string summaryReportInputClass;
    private string[] classData;

    // Start is called before the first frame update
    async void Start()
    {
        //var dropdown = transform.GetComponent<TMP_Dropdown>();
        var parentName = transform.parent.gameObject.name;
        dropdown = transform.parent.gameObject.GetComponentInChildren<TMPro.TMP_Dropdown>();
        Debug.Log(parentName);

        dropdown.options.Clear();
        dropdown.RefreshShownValue();

        classData = await SummaryReportClassInput.loadFromDB();

        List<string> items = new List<string>();
        foreach(var item in classData)
        {
            items.Add(item);
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
        TextBox.text = dropdown.options[index].text;
        summaryReportInputClass = dropdown.options[index].text;
    }
}

