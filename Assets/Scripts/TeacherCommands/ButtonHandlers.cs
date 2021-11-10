using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlers : MonoBehaviour
{
    public static GameObject summaryReport;
    public static GameObject accessCode;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewSummaryReport(GameObject summaryReportPopup)
    {
        summaryReport = summaryReportPopup;
        summaryReportPopup.SetActive(true);
    }

    public void generateAccessCode(GameObject accessCodePopup)
    {
        accessCode = accessCodePopup;
        accessCodePopup.SetActive(true);
    }
}
