using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandlers : MonoBehaviour
{
    public static GameObject summaryReport;
    public static GameObject accessCode;
    public static GameObject socialMediaPopup;
    public GameObject summaryReportCanvas;
    public static string accessCodeText;
    // Start is called before the first frame update
    void Start()
    {
        accessCodeText = "None";
        try{
            Debug.Log("Trying to set active summaryreport");
            var temp = CityEntrance.Scenes.getParam("object");
            if (temp == "summary"){
                Debug.Log("I received a summary temp yay");
                summaryReportCanvas.SetActive(true);
            }
        }
        catch{
            throw;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLeaderboard(GameObject leaderboardInput){ 
        leaderboardInput.SetActive(true);
    }

    public void viewSummaryReport(GameObject summaryReportPopup)
    {
        summaryReport = summaryReportPopup;
        summaryReportPopup.SetActive(true);
    }

    public void exportPNG()
    {
        ScreenCapture.CaptureScreenshot("UnityScreenshot.png");
    }

    public void generateButtonClicked(string scene_name)
    {
        
        SceneManager.LoadScene(scene_name);
    }

    public void backToCommandFromSummaryReport()
    {
        SceneManager.LoadScene("Teacher Commands Scene");
    }

    public void backToClassSelection() {
        Dictionary<string, string> details =  new Dictionary<string, string>{};
        details.Add("object", "summary");
        CityEntrance.Scenes.Load("Teacher Commands Scene", details);
    }

    public void generateAccessCode(GameObject accessCodePopup)
    {
        accessCode = accessCodePopup;
        accessCodePopup.SetActive(true);
    }

    public void generateButtonClicked(GameObject socialMedia)
    {
        accessCode.SetActive(false);
        socialMediaPopup = socialMedia;
        socialMedia.SetActive(true);
    }

    public void backToCommandFromAccessCode()
    {
        socialMediaPopup.SetActive(false);
    }

    public void shareWhatsapp(GameObject code)
    {
        accessCodeText = code.GetComponent<TMPro.TextMeshProUGUI>().text;
        var worldText = AccessCodeDropdownHandler.selectedWorldFromAccessCode;
        var countryText = AccessCodeDropdownHandler.selectedCountryFromAccessCode;
        if (countryText == "Whole Numbers"){
            Application.OpenURL(System.String.Format("https://wa.me/?text=Dear%20students,%20please%20use%20this%20code%20to%20access%20this%20world%20on%20CastleSky%0aWorld:%20{0}%0aCountry:%20{1}%20{2}%0aCode:%20{3}",worldText,countryText.Split(" "[0])[0],countryText.Split(" "[0])[1],accessCodeText));
        }
        else
        {
            Application.OpenURL(System.String.Format("https://wa.me/?text=Dear%20students,%20please%20use%20this%20code%20to%20access%20this%20world%20on%20CastleSky%0aWorld:%20{0}%0aCountry:%20{1}%0aCode:%20{2}",worldText,countryText,accessCodeText));
        }
    }

    public void openCanvas(GameObject specificCanvas){
        specificCanvas.SetActive(true);
    }

    public void closeCanvas(GameObject specificCanvas){
        specificCanvas.SetActive(false);
    }

}
