using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChangeVideo : MonoBehaviour {

    public VideoClip[] videoClips;

    private VideoPlayer videoPlayer;
    private int videoClipIndex;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Use this for initialization
    void Start()
    {
        videoPlayer.targetTexture.Release();
        videoPlayer.clip = videoClips[videoClipIndex];
    }

    public void PlayNewVideo()
    {
        videoClipIndex++;
        videoPlayer.clip = videoClips[videoClipIndex];
    }

}
