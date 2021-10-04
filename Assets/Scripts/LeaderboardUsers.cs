using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class LeaderboardUsers : MonoBehaviour
{
    public GameObject Users;
    public GameObject ImageBox;
    Image first_place_image;
    Image second_place_image;
    Image third_place_image;
    public Transform Parent;
    // Start is called before the first frame update
    void Start()
    {
        var rnd = new System.Random();

        var list = new List<KeyValuePair<string,int>>(){
            new KeyValuePair<string,int>("Colin", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin2", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin3", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin4", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin5", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin6", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin7", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin8", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin9", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin10", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin11", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin12", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin13", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin14", rnd.Next(1,100)),
            new KeyValuePair<string,int>("Colin15", rnd.Next(1,100)),

        };

        list.Sort((y,x) => x.Value.CompareTo(y.Value));

        

        for (int i = 0; i < list.Count; i ++)
        {

            GameObject b = Instantiate(ImageBox);
            b.transform.SetParent(Parent,false);
            b.name = i.ToString() + "(Image)";

            GameObject a = Instantiate(Users);
            a.transform.SetParent(b.transform, false);
            a.name = i.ToString() + "(Text)";

            TextMeshProUGUI myText = a.GetComponent<TextMeshProUGUI>();
            myText.text = list.ElementAt(i).ToString() + " " + (i+1) + " Place";
        
        }

        GameObject first_place = GameObject.Find("0(Image)");
        if (first_place != null){
            first_place.name = "First Place";
            first_place_image = first_place.GetComponent<Image>();
            first_place_image.color = new Color32(255,215,0,255);
        }

        GameObject second_place = GameObject.Find("1(Image)");
        if (second_place != null){
            second_place.name = "Second Place";
            second_place_image = second_place.GetComponent<Image>();
            second_place_image.color = new Color32(192,192,192,255);
        }

        GameObject third_place = GameObject.Find("2(Image)");
        if (third_place != null){
            third_place.name = "Third Place";
            third_place_image = third_place.GetComponent<Image>();
            third_place_image.color = new Color32(205,127,50,255);
        }

    }

    void Update(){}
}
