using UnityEngine;
using System.Collections;
using FrameSynthesis.VR;
using System;
using UnityEngine.Video;

namespace ScriptExample
{
    public class YesNo : MonoBehaviour
    {
        //private IEnumerator DeactivateWindow;
        [SerializeField] private GameObject MessageObject;
        [SerializeField] private GameObject MessageWindow;
        [SerializeField] private GameObject Blur;
        [SerializeField] private GameObject VideoPlayerObject;

        public ChangeVideo ChangeVideoScript;

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
                StartCoroutine(DeactivateWindow(2.0f));
            }
        }

        void OnHeadshake()
        {
            if (scriptEngine.IsYesNoWaiting)
            {
              
                scriptEngine.AnswerNo();
                gestureSound.Play();
                StartCoroutine(DeactivateWindow(2.0f));
            }
        }
        private IEnumerator DeactivateWindow(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            VideoPlayerObject.GetComponent<VideoPlayer>().Play();
            MessageObject.GetComponent<MeshRenderer>().enabled = false;
            MessageWindow.GetComponent<MeshRenderer>().enabled = false;
            Blur.GetComponent<MeshRenderer>().enabled = false;
            ChangeVideoScript.PlayNewVideo();
            gameObject.SetActive(false);
        }
    }
}
