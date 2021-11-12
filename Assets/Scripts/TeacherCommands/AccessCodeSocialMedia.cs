using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCodeSocialMedia : MonoBehaviour
{
    public TMPro.TMP_Text generatedCodeObject;
    private string generatedCodeFromDB;
    // Start is called before the first frame update
    async void Start()
    {
        generatedCodeObject = GameObject.Find("Generated Code").GetComponent<TMPro.TextMeshProUGUI>();
        generatedCodeFromDB = await AccessCodeGenerated.loadFromDB();
        Debug.Log("code " + generatedCodeFromDB);
        generatedCodeObject.text = generatedCodeFromDB;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
