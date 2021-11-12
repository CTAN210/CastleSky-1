using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardChooser : MonoBehaviour
{
    public GameObject Leaderboard_World;
    public GameObject Leaderboard_Country;
    public GameObject Leaderboard_Actual;
    public GameObject Player;

    public static User user;

    // Start is called before the first frame update
    public void OpenLeaderboard_World(){
        try
        {
            Leaderboard_World.transform.position = Player.transform.position;
        
            Leaderboard_World.transform.position = Leaderboard_World.transform.position;

            //animator.SetBool("IsOpen", true);
        
            Debug.Log(Leaderboard_World.transform.position);

            // string characterName = CityEntrance.Scenes.getParam("characterName");
            // Debug.Log("This is Math World Scene Character: " + characterName);
        }
        catch (System.Exception)
        {   
            throw;
        }
    }

    public void CloseLeaderboard_World(){
        Leaderboard_World.transform.position = Leaderboard_World.transform.position + new Vector3(3000,0,0);
    }

    public void OpenLeaderboard_Country(){
        try
        {
            Leaderboard_Country.transform.position = Player.transform.position;
        
            Leaderboard_Country.transform.position = Leaderboard_Country.transform.position;

            //animator.SetBool("IsOpen", true);
        
            Debug.Log(Leaderboard_Country.transform.position);
        }
        catch (System.Exception)
        {   
            throw;
        }
    }

    public void CloseLeaderboard_Country(){
        Leaderboard_Country.transform.position = Leaderboard_Country.transform.position + new Vector3(3000,0,0);
    }

    public void OpenLeaderboard_Actual(){
        try
        {
            Leaderboard_Actual.transform.position = Player.transform.position;
        
            Leaderboard_Actual.transform.position = Leaderboard_Actual.transform.position;

            //animator.SetBool("IsOpen", true);
        
            Debug.Log(Leaderboard_Actual.transform.position);
        }
        catch (System.Exception)
        {   
            throw;
        }
    }

    public void CloseLeaderboard_Actual(){
        Leaderboard_Actual.transform.position = Leaderboard_Actual.transform.position + new Vector3(3000,0,0);
    }




}
