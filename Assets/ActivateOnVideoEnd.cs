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


    [SerializeField] private GameObject Image;

    //public VideoClip[] videoClips;

    // Use this for initialization
    void Start () {
        //GestureController.SetActive(true);
        //ActivateBlur(0.0f);

        /*videoPlayer.clip = videoClips[1];
        videoPlayer.Stop();
        videoPlayer.Play();
        */
    }
	
	// Update is called once per frame
	void Update () {

        //Really ugly
        //WaitForFirstVideo();
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
        videoPlayer.Pause();
        MessageObject.GetComponent<MeshRenderer>().enabled = true;
        MessageWindow.GetComponent<MeshRenderer>().enabled = true;
        Blur.GetComponent<MeshRenderer>().enabled = true;
        //Clue1.SetActive(false);
        GestureController.SetActive(true);
        //print("You looked at this object for 2 sec");
    }

    private IEnumerator WaitForFirstVideo()
    {
        yield return new WaitForSeconds(5.0f); //30.0f
        //StartCoroutine(ActivateBlur());
    }
}
