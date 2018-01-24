using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Interactive360;

public class PlayVideo : MonoBehaviour {

    public MenuManager MenuManager;
    public VideoPlayer ProjectorVideo;
	// Use this for initialization
	void Start () {
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

    public void PlayProjectorClip()
    {
        StartCoroutine(ChooseSeperateClip());
    }

    IEnumerator ChooseSeperateClip()
    {
        bool wasPlaying = false;
        // pause background video
        if (GetComponent<VideoPlayer>().isPlaying)
        {
            wasPlaying = true;
            GetComponent<VideoPlayer>().Pause();
        }
        // play video on projector
        ProjectorVideo.GetComponent<VideoPlayer>().Play();
        // give us 8 seconds of playing this video, then go back to the main one
        ProjectorVideo.GetComponent<VideoPlayer>().Pause();
        yield return new WaitForSeconds(8f);
        if (wasPlaying)
        {
            GetComponent<VideoPlayer>().Play();
        }
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
