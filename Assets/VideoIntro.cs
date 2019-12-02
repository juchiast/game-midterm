using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoIntro : MonoBehaviour
{
    VideoPlayer Intro_Movie;
    int countFrame;
    // Start is called before the first frame update
    void Start()
    {
        Intro_Movie = GetComponent<VideoPlayer>();
        Intro_Movie.Play();
        countFrame = (int)Intro_Movie.frameCount;
        //Debug.Log("Count: " + countFrame.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("current: " + Intro_Movie.frame.ToString());
        if ((int)Intro_Movie.frame != countFrame - 5)
        {
            //onMovieEnded();
        }
        else
            onMovieEnded();
    }
    public void onMovieEnded()
    {
        //Debug.Log("Movie Ended!");
        SceneManager.LoadScene(1);
    }
}
