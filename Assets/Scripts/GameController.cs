using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject key1ClickZone;
	public GameObject key2ClickZone;
	public GameObject letterClickZone;
	public GameObject radioOnClickZone;
	public GameObject erikClickZone;
	public GameObject discussionClickZone;
	public GameObject UIkey1;
	public GameObject UIkey2;
    public GameObject pointer;

    public VideoController videoController;
	public AudioController audioController;
	public GameObject[] sceneList;

	private int lastScene;
	private bool hasKey1 = false;
	private bool hasKey2 = false;
	private bool erikAwake = false;
	private bool door1Locked = true;
	private bool door2Locked = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Change video and scene
	public void switchScene(int sceneIndex) {
			// Trying to enter a locked room
			if (sceneIndex==4 && !hasKey1 || sceneIndex==9 && !hasKey2) {
					Debug.Log("Locked!");
					audioController.playSound(0);
					sceneList[lastScene].SetActive(true);

			}
			else {
					// Different enter sounds depending on unlocking the door or not
					if ((sceneIndex==4 && door1Locked) || (sceneIndex==9 && door2Locked)) {
							if (sceneIndex==4) {
									door1Locked = false;
							}
							else if (sceneIndex==9) {
									door2Locked = false;
							}
							audioController.playSound(1);
					}
					else if (sceneIndex==4 || sceneIndex==9) {
							if (lastScene!=5) {
									audioController.playSound(2);
							}
					}

					// Radio sound volume based on distance from radio
					if (sceneIndex<3 || sceneIndex>7) {
							audioController.changeVolume(3, 0f);
					}
					else if (sceneIndex==3 || sceneIndex==7) {
							audioController.changeVolume(3, 0.1f);
					}
					else if (sceneIndex==4 || sceneIndex==6) {
							audioController.changeVolume(3, 0.4f);
					}
					else if (sceneIndex==5) {
							audioController.changeVolume(3, 1f);
					}

					// Debug.Log("Enter!");
					pointer.GetComponent<rotateByCamera>().changeRooms(sceneIndex);
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
					// Play key pick up sound
					key1ClickZone.GetComponent<AudioSource>().Play(0);
					// Key not clickable
					key1ClickZone.GetComponent<BoxCollider>().enabled = false;
					videoController.ChangeVideoNoFade(1);
					UIkey1.SetActive(true);
			}
			else if (sceneIndex == "Key 2" && !hasKey2) {
					Debug.Log("Found Key 2!");
					hasKey2 = true;
					// Change video in the video list to video without key
					videoController.ReplaceVideo(8, 5);
					// Play key pick up sound
					key2ClickZone.GetComponent<AudioSource>().Play(0);
					// Key not clickable
					key2ClickZone.GetComponent<BoxCollider>().enabled = false;
					videoController.ChangeVideoNoFade(8);
					UIkey2.SetActive(true);
			}
			else if (sceneIndex == "Radio On") {
					Debug.Log("Radio turned on!");
					audioController.playSound(3);
					videoController.ReplaceVideo(4, 1);	// Replace room 2 video
					radioOnClickZone.GetComponent<BoxCollider>().enabled = false;
					erikAwake = true;
			}
			else if (sceneIndex == "Erik") {
					if (erikAwake) {
							Debug.Log("Talked with Erik!");
							// ADD: Cinematic + deactivate click zone
							videoController.ReplaceVideo(4, 3);	// Replace room 2 video
							videoController.ReplaceVideo(0, 4);	// Replace room 1 video
							erikClickZone.GetComponent<BoxCollider>().enabled = false;
							letterClickZone.GetComponent<BoxCollider>().enabled = true;
							videoController.ChangeVideo(lastScene);
					}
					else {
							erikClickZone.GetComponent<AudioSource>().Play(0);
					}
			}
			else if (sceneIndex == "Discussion") {
					Debug.Log("Listened to the discussion!");
					// ADD: Cinematic + deactivate click zone
					audioController.playSound(4);
					discussionClickZone.GetComponent<BoxCollider>().enabled = false;
					videoController.ReplaceVideo(9, 7);	// Replace room 3 video
					videoController.ChangeVideo(lastScene);
			}
	}
}
