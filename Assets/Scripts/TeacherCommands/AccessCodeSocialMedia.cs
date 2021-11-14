using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessCodeSocialMedia : MonoBehaviour
{
    public GameObject generatedCodeObject;
    private string[] generatedCodeFromDB;
    // Start is called before the first frame update
    async void Start()
    {
        generatedCodeObject = GameObject.Find("Generated Code");
        var text = generatedCodeObject.GetComponent<Text>();
        generatedCodeFromDB = await AccessCodeGenerated.loadFromDB();
        
        text.text = generatedCodeFromDB[0];
        // generatedCodeObject.text = generatedCodeFromDB[0];   
    }

    // Update is called once per frame
/*    async void Update()
     {
         generatedCodeFromDB = await AccessCodeGenerated.loadFromDB();
         var text = generatedCodeObject.GetComponent<Text>();
         text.text = generatedCodeFromDB[0];
    }*/

    public async void loadFromDB()
    {
        generatedCodeFromDB = await AccessCodeGenerated.loadFromDB();
        var text = generatedCodeObject.GetComponent<Text>();
        text.text = generatedCodeFromDB[0];
    }
}
