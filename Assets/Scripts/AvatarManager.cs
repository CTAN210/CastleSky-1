using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{

    public GameObject Player;
    public Animator PlayerAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
    //  int userAvatarID = checkCharacterID();
     PlayerAnimator.SetInteger("AvatarID", User.);

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
