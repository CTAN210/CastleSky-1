using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardResults : MonoBehaviour
{
    public LeaderboardResultsGenerator[] leaderboardResults;
    public static List<string> studentDataForLeaderboard;
    public static List<int> scoreDataForLeaderboard;

    // Start is called before the first frame update
    async void Start()
    {
        leaderboardResults = await LeaderboardResultsGenerator.loadFromDB();
        studentDataForLeaderboard = new List<string>();
        scoreDataForLeaderboard = new List<int>();
        for (int i = 0; i< leaderboardResults.Length; i++)
        {
            studentDataForLeaderboard.Add(leaderboardResults[i].UserName);
            scoreDataForLeaderboard.Add(leaderboardResults[i].Score);
        }
    }

    async void Update()
    {
        leaderboardResults = await LeaderboardResultsGenerator.loadFromDB();
        studentDataForLeaderboard = new List<string>();
        scoreDataForLeaderboard = new List<int>();
        for (int i = 0; i< leaderboardResults.Length; i++)
        {
            studentDataForLeaderboard.Add(leaderboardResults[i].UserName);
            scoreDataForLeaderboard.Add(leaderboardResults[i].Score);
        }
    }
}
