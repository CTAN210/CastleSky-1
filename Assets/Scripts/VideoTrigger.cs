using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTrigger : MonoBehaviour
{
    public GameObject VideoBox;
    public GameObject VideoPlayer;
    public GameObject VideoNPC;
    public GameObject Player;
    //public GameObject decorations;

    public void OpenVideo(){
        try
        {
            //VideoBox.transform.position = new Vector3(0,0,0);

            VideoBox.transform.position = Player.transform.position;

            Debug.Log(VideoBox.transform.position);

            var videoPlayer = VideoPlayer.GetComponent<VideoPlayer>();

            videoPlayer.Play();

            Player.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            VideoNPC.SetActive(false);

            var decorations = GameObject.Find("Decoration");
            decorations.SetActive(false);

            Time.timeScale = 0;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void CloseVideo(){
        try
        {
            


             VideoBox.transform.position = VideoBox.transform.position + new Vector3(3000,0,0);

             var videoPlayer = VideoPlayer.GetComponent<VideoPlayer>();

             videoPlayer.Stop();

            Time.timeScale = 1;
             
            Player.GetComponent<SpriteRenderer>().sortingLayerName = "Player";

            VideoNPC.SetActive(true);

            var decorations = GameObject.Find("Grid").transform.Find("Decoration").gameObject;
            decorations.SetActive(true);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}
