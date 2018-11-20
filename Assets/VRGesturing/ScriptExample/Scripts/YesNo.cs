using UnityEngine;
using System.Collections;
using FrameSynthesis.VR;
using System;

namespace ScriptExample
{
    public class YesNo : MonoBehaviour
    {
        //private IEnumerator DeactivateWindow;
        [SerializeField] private GameObject MessageObject;

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
                StartCoroutine(DeactivateWindow(1.0f));
            }
        }
        private IEnumerator DeactivateWindow(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            MessageObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
