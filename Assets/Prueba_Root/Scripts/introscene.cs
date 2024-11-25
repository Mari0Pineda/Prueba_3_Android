using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class introscene : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoplayer;

    private void Start()
    {
        videoplayer.loopPointReached += VideoPlayer_loopPointReached;
        
    }

    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        SceneManager.LoadScene("menu");

    }
}
