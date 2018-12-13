using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public VideoController videoController;
	public GameObject letterClickArea;
	public GameObject[] sceneList;

	private bool hasKey1 = false;
	private bool hasKey2 = false;
	private bool erikTalked = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Change video and scene
	public void switchScene(int sceneIndex) {
			if(sceneIndex==4 && !hasKey1) {
					foundKey(1);
			}
			else if(sceneIndex==5 && !hasKey2) {
					foundKey(2);
			}

			sceneList[sceneIndex].SetActive(true);
			videoController.ChangeVideo(sceneIndex);
	}

	public void switchScene(string sceneIndex) {
			// ADD: Special cases eg. cinematics
			
	}

	public void foundKey(int keyNum) {
			if(keyNum==1) {
					hasKey1 = true;
					// Change video in the video list to video without key
					videoController.ReplaceVideo(1, 0);
			}
			else {
					hasKey2 = true;
					// Change video in the video list to video without key
					videoController.ReplaceVideo(8, 5);
			}
	}

	public void erikTalk() {
			videoController.ReplaceVideo(4, 2);	// Replace room 2 video
			videoController.ReplaceVideo(0, 4);	// Replace room 1 video
			letterClickArea.GetComponent<BoxCollider>().enabled = true;
	}
}
