using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LeaderboardResults : MonoBehaviour
{
    public LeaderboardResultsGenerator[] leaderboardResults;
    public static List<string> studentDataForLeaderboard;
    public static List<int> scoreDataForLeaderboard;
    public GameObject Users;
    public GameObject ImageBox;
    Image first_place_image;
    Image second_place_image;
    Image third_place_image;
    public Transform Parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public async void getLeaderboardResults()
    {
         LeaderboardResultsGenerator[] leaderboardResults =  await LeaderboardResultsGenerator.loadFromDB();
        studentDataForLeaderboard = new List<string>();
        scoreDataForLeaderboard = new List<int>();
        for (int i = 0; i< leaderboardResults.Length; i++)
        {
            studentDataForLeaderboard.Add(leaderboardResults[i].UserName);
            scoreDataForLeaderboard.Add(leaderboardResults[i].Score);
        }

        populateLeaderboard();
    }


    // Start is called before the first frame update

    public void populateLeaderboard()
    {
        var list = new List<KeyValuePair<string,int>>();

        if (LeaderboardResults.studentDataForLeaderboard != null && LeaderboardResults.scoreDataForLeaderboard != null)
        {
            for (int i = 0; i < LeaderboardResults.studentDataForLeaderboard.Count; i++)
            {
                list.Add(new KeyValuePair<string,int>(LeaderboardResults.studentDataForLeaderboard[i],LeaderboardResults.scoreDataForLeaderboard[i]));
            }
        }

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

    public void depopulateLeaderboard(GameObject specific)
    {
        for (int i = 0; i < Parent.childCount; i++) {

            string name = Parent.GetChild(i).name;
            Destroy(GameObject.Find(name));
        }
    }




}
