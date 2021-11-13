using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Transform puzzleField;

    [SerializeField]
    public GameObject btn ;

    public GameObject levelHolder;

    private void Awake()
    {
        int numOfButtons;
        string level = CityEntrance.Scenes.getParam("level");

        switch (level)
        {
            case "1":
                numOfButtons = 8;
                break;
            case "2":
                numOfButtons = 12;
                break;            
            case "3":
                numOfButtons = 14;
                break;
            default:
                numOfButtons = 6;
                break;
        }

        for (int i = 0; i < numOfButtons; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false); // false - to not allow the world postion to stay 
        }
    }
}
