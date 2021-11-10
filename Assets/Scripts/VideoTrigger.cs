using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTrigger : MonoBehaviour
{
    public GameObject VideoBox;
    public GameObject VideoPlayer;
    public GameObject Player;

    public void OpenVideo(){
        try
        {
            //VideoBox.transform.position = new Vector3(0,0,0);

            VideoBox.transform.position = Player.transform.position;

            Debug.Log(VideoBox.transform.position);

            var videoPlayer = VideoPlayer.GetComponent<VideoPlayer>();

            videoPlayer.Play();


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
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}
