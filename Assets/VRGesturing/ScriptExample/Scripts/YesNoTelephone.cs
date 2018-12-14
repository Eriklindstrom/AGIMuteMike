using UnityEngine;
using System.Collections;
using FrameSynthesis.VR;
using System;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

namespace ScriptExample
{
    public class YesNoTelephone : MonoBehaviour
    {
        //private IEnumerator DeactivateWindow;
        [SerializeField] private GameObject MessageObject;
        [SerializeField] private GameObject MessageWindow;
        [SerializeField] private GameObject Blur;
        [SerializeField] private GameObject DrinkMessage;
        //[SerializeField] private GameObject VideoPlayerObject;
        [SerializeField] private GameObject OnOurWay;

        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private GameObject videoPlayerObject;
        [SerializeField] private GameController sceneSwitchGO;
        //public VideoClip[] videoClips;

        //public VideoController videoController;


        [SerializeField]
        VRGesture vrGesture;
        [SerializeField]
        ScriptEngine scriptEngine;
        //[SerializeField]
        //AudioSource gestureSound;


        void Start()
        {
            vrGesture.NodHandler += OnNod;
            vrGesture.HeadshakeHandler += OnHeadshake;

            StartCoroutine(WaitForSeconds());
            //MessageObject.SetActive(true);
            //MessageWindow.SetActive(true);

            MessageObject.GetComponent<MeshRenderer>().enabled = true;
            MessageWindow.GetComponent<MeshRenderer>().enabled = true;
        }

        void OnNod()
        {
            //OnOurWay.SetActive(true);
            //videoPlayer.clip = videoClips[0];
            //videoPlayer.Play();
            if (scriptEngine.IsYesNoWaiting)
            {
                OnOurWay.SetActive(true);
                StartCoroutine(OnYes());
            }
        }

        void OnHeadshake()
        {
            if (scriptEngine.IsYesNoWaiting)
            {
                //videoPlayer.clip = videoClips[0];
                //videoPlayer.Play();


                scriptEngine.AnswerNo();
                //gestureSound.Play();
                StartCoroutine(OnNo(0.0f));


            }
        }

        private IEnumerator WaitForSeconds()
        {
            yield return new WaitForSeconds(4.0f);
        }
        private IEnumerator OnYes()
        {
            MessageObject.SetActive(false);
            MessageWindow.SetActive(false);
            //Blur.SetActive(false);
            MessageObject.GetComponent<MeshRenderer>().enabled = false;
            MessageWindow.GetComponent<MeshRenderer>().enabled = false;
            Blur.GetComponent<MeshRenderer>().enabled = false;
            //videoPlayerObject.GetComponent<ActivateOnVideoEnd>().enabled = false;

            yield return new WaitForSeconds(4.0f);
            SceneManager.LoadScene("4. Epilogue");
        }

        private IEnumerator OnNo(float waitTime)
        {
            this.transform.parent.gameObject.SetActive(false);
            sceneSwitchGO.switchScene(11);
            //videoPlayer.clip = videoClips[1];
            //videoPlayer.Stop();
            //videoPlayer.Play();
            //videoPlayer.Play();

            //videoPlayer.Play();
            //MessageObject.SetActive(false);
            //MessageWindow.SetActive(false);
            //Blur.SetActive(false);
            //MessageObject.GetComponent<MeshRenderer>().enabled = false;
            //MessageWindow.GetComponent<MeshRenderer>().enabled = false;
            //Blur.GetComponent<MeshRenderer>().enabled = false;
            //videoPlayerObject.GetComponent<ActivateOnVideoEnd>().enabled = false;
            //videoController.ChangeVideo(0);
            //gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            //MessageObject.SetActive(true);
            //MessageWindow.SetActive(true);
            //Blur.SetActive(true);
            //MessageObject.GetComponent<MeshRenderer>().enabled = true;
            //MessageWindow.GetComponent<MeshRenderer>().enabled = true;
            //Blur.GetComponent<MeshRenderer>().enabled = true;
            //videoPlayerObject.GetComponent<ActivateOnVideoEnd>().enabled = true;


        }
    }
}
