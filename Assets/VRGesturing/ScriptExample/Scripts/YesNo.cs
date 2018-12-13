using UnityEngine;
using System.Collections;
using FrameSynthesis.VR;
using System;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

namespace ScriptExample
{
    public class YesNo : MonoBehaviour
    {
        //private IEnumerator DeactivateWindow;
        [SerializeField] private GameObject MessageObject;
        [SerializeField] private GameObject MessageWindow;
        [SerializeField] private GameObject Blur;
        [SerializeField] private GameObject DrinkMessage;
        //[SerializeField] private GameObject VideoPlayerObject;

        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private GameObject videoPlayerObject;
        public VideoClip[] videoClips;

        //public VideoController videoController;


        [SerializeField]
        VRGesture vrGesture;
        [SerializeField]
        ScriptEngine scriptEngine;
        [SerializeField]
        AudioSource gestureSound;


        void Start()
        {
            vrGesture.NodHandler += OnNod;
            vrGesture.HeadshakeHandler += OnHeadshake;
        }

        void OnNod()
        {
            if (scriptEngine.IsYesNoWaiting)
            {
                /*videoPlayer.Play();
                videoPlayerObject.SetActive(false);
                videoPlayerObject.GetComponent<ActivateOnVideoEnd>().enabled = false;

                videoPlayer.clip = videoClips[0];
                videoPlayer.Stop();
                videoPlayer.Play();
                */

                videoPlayer.clip = videoClips[0];
                videoPlayer.Play();

                scriptEngine.AnswerYes();
                gestureSound.Play();
                StartCoroutine(OnYes(0.0f));

                /*videoPlayer.clip = videoClips[0];
                videoPlayer.Stop();
                videoPlayer.Play();
                */
            }
        }

        void OnHeadshake()
        {
            if (scriptEngine.IsYesNoWaiting)
            {
                videoPlayer.clip = videoClips[1];
                videoPlayer.Play();
               

                scriptEngine.AnswerNo();
                gestureSound.Play();
                StartCoroutine(OnNo(0.0f));

              
            }
        }
        private IEnumerator OnYes(float waitTime)
        {
            MessageObject.GetComponent<MeshRenderer>().enabled = false;
            MessageWindow.GetComponent<MeshRenderer>().enabled = false;
            Blur.GetComponent<MeshRenderer>().enabled = false;
            videoPlayerObject.GetComponent<ActivateOnVideoEnd>().enabled = false;

            //videoPlayer.clip = videoClips[0];
            //videoPlayer.Stop();
            //videoPlayer.Play();


            //videoController.ChangeVideo(0);
            //gameObject.SetActive(false);G
            yield return new WaitForSeconds(5.0f);
            SceneManager.LoadScene(2);
        }

        private IEnumerator OnNo(float waitTime)
        {

            //videoPlayer.clip = videoClips[1];
            //videoPlayer.Stop();
            //videoPlayer.Play();
            //videoPlayer.Play();

            //videoPlayer.Play();
            //MessageObject.SetActive(false);
            //MessageWindow.SetActive(false);
            //Blur.SetActive(false);
            MessageObject.GetComponent<MeshRenderer>().enabled = false;
            MessageWindow.GetComponent<MeshRenderer>().enabled = false;
            Blur.GetComponent<MeshRenderer>().enabled = false;
            videoPlayerObject.GetComponent<ActivateOnVideoEnd>().enabled = false;
            //videoController.ChangeVideo(0);
            //gameObject.SetActive(false);
            yield return new WaitForSeconds(2.0f);
            //MessageObject.SetActive(true);
            //MessageWindow.SetActive(true);
            //Blur.SetActive(true);
            MessageObject.GetComponent<MeshRenderer>().enabled = true;
            MessageWindow.GetComponent<MeshRenderer>().enabled = true;
            Blur.GetComponent<MeshRenderer>().enabled = true;
            videoPlayerObject.GetComponent<ActivateOnVideoEnd>().enabled = true;


        }
    }
}
