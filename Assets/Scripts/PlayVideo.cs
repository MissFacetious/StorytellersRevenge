using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Interactive360;

public class PlayVideo : MonoBehaviour {

    public MenuManager MenuManager;
    public string MainURL = "";
    public string ClipURL = "";
    public AudioClip MainAudio;
    public AudioClip ClipAudio;

    // Use this for initialization
    void Start() {
        GetComponent<VideoPlayer>().url = MainURL;
        GetComponent<AudioSource>().clip = MainAudio;
        MenuManager = GameObject.Find("PlayPauseMenu").GetComponent<MenuManager>();
        GetComponent<VideoPlayer>().loopPointReached += EndReached;
        MenuManager.CheckMainVideo();
        PlayVideoClip();
    }

    public void PlayVideoClip()
    {
        MenuManager.PlayVideoClip();
    }

    public void PauseVideoClip()
    {
        MenuManager.PauseVideoClip();
    }


    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // remove any buttons you don't want
        GameObject.Find("Bounce").SetActive(false);
        GameObject.Find("Whack").SetActive(false);
        //GameObject.Find("Projector").SetActive(false);

        if (MenuManager.Pause != null && MenuManager.Play != null)
        {
            MenuManager.Pause.SetActive(false);
            MenuManager.Play.SetActive(false);
        }
        GameObject.Find("VideoManager").GetComponent<GameManager>().LoadCredits();
    }
    

    // Update is called once per frame
    void Update () {
        
    }
}
