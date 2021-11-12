using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneSwitcher : MonoBehaviour
{
    static string btn_clicked;
    public static string role;



    public void go_to_role_main_menu(){
        if ((role == "Student")){
            SceneManager.LoadScene("Student Choose World Scene");
        }
        else if ((role == "Teacher")){
            SceneManager.LoadScene("Teacher Commands Scene");
        }

    }

    public void load_next_scene (string scene_name){
        string characterName = CityEntrance.Scenes.getParam("characterName");
        Debug.Log("Hello this is the character: " + characterName);
        
        CityEntrance.Scenes.Load(scene_name, "characterName", characterName, "position", new Vector3(0,0,0));
    }

    public void which_role(){
        if (btn_clicked == "StudentButton"){
            role = "Student";
           Debug.Log(role);
        }
        if (btn_clicked == "TeacherButton"){
            role = "Teacher";
            Debug.Log(role);
        }
    } 

    public void which_btn_clicked(Button btn){
        btn_clicked = btn.name;
        //Debug.Log(btn.name);
    } 

}
