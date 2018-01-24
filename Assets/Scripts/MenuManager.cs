using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Interactive360
{
    public class MenuManager : MonoBehaviour
    {
        public VideoPlayer MainVideo;
        public GameObject Audio;
        public GameObject Play;
        public GameObject Pause;
        // on Start, bind all buttons to their respective scenes and call DontDestroyOnLoad to keep the Main Menu in every scene
        void Start()
        {
            if (Pause != null && Play != null)
            { 
                Pause.SetActive(false);
                Play.SetActive(false);
            }
        }

        //call the checkForInput method once per fram
        void Update()
        {
            CheckMainVideo();
            checkForInput();
        }

        public void CheckMainVideo()
        {
            if (MainVideo == null)
            {
                GameObject mv = GameObject.Find("MainVideo");
                if (mv != null)
                {
                    MainVideo = mv.GetComponent<VideoPlayer>();
                }
            }
        }
        
        //If we detect input, call the toggleMenu method 
        private void checkForInput()
        {
            //check for input from specified Oculus Touch button or the App button on Google Daydream Controller
            if (GvrControllerInput.AppButtonDown || Input.GetMouseButtonDown(0))
            {
                if (Pause != null && Play != null)
                {
                    toggleButton();
                }
            }
        }

        //Toggle between showing play and pause button when once is pressed
        public void toggleButton()
        {
            if (MainVideo != null) {
                if (MainVideo.isPlaying)
                {
                    // show pause sprite
                    PauseVideoClip();
                }
                else
                {
                    // show play sprite
                    PlayVideoClip();
                }
            }
        }

        void PauseButton()
        {
            if (Pause)
                Pause.SetActive(true);
            if (Play)
                Play.SetActive(false);
        }

        void PlayButton()
        {
            if (Pause)
                Pause.SetActive(false);
            if (Play)
                Play.SetActive(true);
        }

        public void Bounce()
        {
            Audio.GetComponent<AudioSource>().Play();
        }

        public void Whack()
        {
            Audio.GetComponent<AudioSource>().Play();
        }

        public void Projector()
        {
            Audio.GetComponent<AudioSource>().Play();
        }

        public void Skip()
        {
            if (MainVideo != null)
            {
                MainVideo.GetComponent<VideoPlayer>().time = 49;
                PlayVideoClip();
            }
            Audio.GetComponent<AudioSource>().Play();
        }

        public void PlayVideoClip()
        {
            if (MainVideo != null)
            {
                MainVideo.GetComponent<VideoPlayer>().Play();
                PlayButton();
            }
        }

        public void PauseVideoClip()
        {
            if (MainVideo != null)
            {
                MainVideo.GetComponent<VideoPlayer>().Pause();
                Debug.Log("pause video!");
                PauseButton();
            }
        }
    }
}

