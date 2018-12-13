using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject key1ClickZone;
	public GameObject key2ClickZone;
	public GameObject letterClickZone;
	public GameObject radioOnClickZone;

	public VideoController videoController;
	public GameObject[] sceneList;

	private int lastScene;
	private bool hasKey1 = false;
	private bool hasKey2 = false;
	private bool erikAwake = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Change video and scene
	public void switchScene(int sceneIndex) {
		// Trying to enter locked room 2
			if (sceneIndex==4 && !hasKey1) {
					Debug.Log("Locked!");
					sceneList[lastScene].SetActive(true);
					videoController.ChangeVideo(lastScene);
			}
			// Trying to enter locked room 3
			else if (sceneIndex==9 && !hasKey2) {
					sceneList[lastScene].SetActive(true);
					videoController.ChangeVideo(lastScene);
			}
			else {
					// Debug.Log("Enter!");
					sceneList[sceneIndex].SetActive(true);
					videoController.ChangeVideo(sceneIndex);
					lastScene = sceneIndex;
			}
	}

	// Special scenes (special cases)
	public void switchScene(string sceneIndex) {
			if (sceneIndex == "Key 1" && !hasKey1) {
					Debug.Log("Found Key 1!");
					hasKey1 = true;
					// Change video in the video list to video without key
					videoController.ReplaceVideo(1, 0);
					key1ClickZone.GetComponent<BoxCollider>().enabled = false;
			}
			else if (sceneIndex == "Key 2" && !hasKey2) {
					Debug.Log("Found Key 2!");
					hasKey2 = true;
					// Change video in the video list to video without key
					videoController.ReplaceVideo(8, 5);
					key2ClickZone.GetComponent<BoxCollider>().enabled = false;
			}
			else if (sceneIndex == "Radio On") {
					Debug.Log("Radio turned on!");
					videoController.ReplaceVideo(4, 1);	// Replace room 2 video
					radioOnClickZone.GetComponent<BoxCollider>().enabled = false;
					erikAwake = true;
			}
			else if (sceneIndex == "Erik" && erikAwake) {
					Debug.Log("Talked with Erik!");
					// ADD: Cinematic + deactivate click zone
					videoController.ReplaceVideo(4, 3);	// Replace room 2 video
					videoController.ReplaceVideo(0, 4);	// Replace room 1 video
					letterClickZone.GetComponent<BoxCollider>().enabled = true;
			}
			else if (sceneIndex == "Discussion") {
					Debug.Log("Listened to the discussion!");
					// ADD: Cinematic + deactivate click zone
					videoController.ReplaceVideo(9, 7);	// Replace room 3 video
			}

			videoController.ChangeVideo(lastScene);
	}
}
