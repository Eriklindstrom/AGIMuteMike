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
        //[SerializeField] private GameObject VideoPlayerObject;

        [SerializeField] private VideoPlayer videoPlayer;
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

                scriptEngine.AnswerYes();
                gestureSound.Play();
                StartCoroutine(OnYes(0.0f));
            }
        }

        void OnHeadshake()
        {
            if (scriptEngine.IsYesNoWaiting)
            {

                scriptEngine.AnswerNo();
                gestureSound.Play();
                StartCoroutine(OnNo(0.0f));
            }
        }
        private IEnumerator OnYes(float waitTime)
        {
            videoPlayer.clip = videoClips[2];
            


            
            //videoPlayer.Play();
            MessageObject.GetComponent<MeshRenderer>().enabled = false;
            MessageWindow.GetComponent<MeshRenderer>().enabled = false;
            Blur.GetComponent<MeshRenderer>().enabled = false;
            //videoController.ChangeVideo(0);
            //gameObject.SetActive(false);
            yield return new WaitForSeconds(5.0f);
            SceneManager.LoadScene(2);
        }

        private IEnumerator OnNo(float waitTime)
        {

            videoPlayer.clip = videoClips[1];

            yield return new WaitForSeconds(waitTime);
            //videoPlayer.Play();
            MessageObject.GetComponent<MeshRenderer>().enabled = false;
            MessageWindow.GetComponent<MeshRenderer>().enabled = false;
            Blur.GetComponent<MeshRenderer>().enabled = false;
            //videoController.ChangeVideo(0);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(5.0f);
            MessageObject.GetComponent<MeshRenderer>().enabled = true;
            MessageWindow.GetComponent<MeshRenderer>().enabled = true;
            Blur.GetComponent<MeshRenderer>().enabled = true;

        }
    }
}
