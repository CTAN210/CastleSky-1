using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarManager : MonoBehaviour
{

    public GameObject Player;
    public Animator PlayerAnimator;

    public GameObject usernameText;


    [SerializeField]
   public static int characterID;
    static string actualuserName;
    // Start is called before the first frame update
    void Start()
    {
        
        if (characterID.Equals(0) || characterID == 0) {
            string characterName =  CityEntrance.Scenes.getParam("characterName");
            string userName = CityEntrance.Scenes.getParam("userName");

            actualuserName = userName;

            Debug.Log("Avatar Manager is saying: " + characterName);
            Debug.Log("Username: " + userName);

            

           
            
            switch(characterName){
                case "Warrior": 
                    characterID = 1;
                    break;
                case "Knight": 
                    characterID = 2;
                    break;
                case "Artist": 
                    characterID = 3;
                    break;
                case "Astrologer": 
                    characterID = 4;
                    break;
                case "Citizen": 
                    characterID = 5;
                    break;
                case "Naked":
                    characterID = 6;
                    break;
                default:
                    characterID = 1;
                    break;
                }
        }

        Debug.Log("Avatar Manager is saying: " + characterID);
        PlayerAnimator.SetInteger("AvatarID", characterID);
        var text = usernameText.GetComponent<Text>();
        text.text = actualuserName ;

    //  int userAvatarID = checkCharacterID();
    //  PlayerAnimator.SetInteger("AvatarID", User.);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public int checkCharacterID(){
    //     if(true){
    //         return 1;
    //     }

    //     // if(true){
    //     //     return 2;
    //     // }
    //     // if(){
    //     //     return 3;
    //     // }
    //     // if(){
    //     //     return 4;
    //     // }
    //     // if(){
    //     //     return 5;
    //     // }
    //     // if(){
    //     //     return 6;
    //     // }
    // }
}
