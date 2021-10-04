using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Loop_Over_Scenes : MonoBehaviour
{
    private void Awake(){
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Background Song");
        if (musicObj.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
