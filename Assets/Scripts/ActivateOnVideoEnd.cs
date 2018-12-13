using ScriptExample;        //For getting the componentScript YesNo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateOnVideoEnd : MonoBehaviour {


    [SerializeField] private GameObject GestureController;
    [SerializeField] private GameObject MessageObject;
    [SerializeField] private GameObject MessageWindow;
    [SerializeField] private GameObject Blur;

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject YesNoGO;
    public VideoClip[] videoClips;


    [SerializeField] private GameObject Image;

    private bool ActivateFirstClip = false;

  
	
	// Update is called once per frame
	void Update () {
        //Activate only once
        if(!ActivateFirstClip)
            StartCoroutine(WaitForFirstVideo());

        /*if ((ulong)videoPlayer.frame == videoPlayer.frameCount)
        {
            Debug.Log("end of video");
            //Image.SetActive(true);
            StartCoroutine(ActivateBlur());
            //Image.SetActive(false);
        }*/
    }

    private IEnumerator ActivateBlur()
    {
        yield return new WaitForSeconds(0.0f);
        //videoPlayer.Pause();
        videoPlayer.Stop();     //Can't unpause video for some reason
        MessageObject.GetComponent<MeshRenderer>().enabled = true;
        MessageWindow.GetComponent<MeshRenderer>().enabled = true;
        Blur.GetComponent<MeshRenderer>().enabled = true;
        GestureController.GetComponent<YesNo>().enabled = true;
        //GestureController.SetActive(true);
    }

    private IEnumerator WaitForFirstVideo()
    {
        yield return new WaitForSeconds(30.0f); //30.0f

        

        ActivateFirstClip = true;
        StartCoroutine(ActivateBlur());

        /*Debug.Log("testing");
        videoPlayer.clip = videoClips[0];
        videoPlayer.Play();*/
    }
}
