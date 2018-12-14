using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioSource[] audioList;

	// List index legend
	// 0. Locked door
	// 1. Keys open door
	// 2. Open door
	// 3. Radio sound
	// 4. Bell

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void playSound(int audioIndex) {
			audioList[audioIndex].Play(0);
	}

	public void changeVolume(int audioIndex, float newVolume) {
			audioList[audioIndex].volume = newVolume;
	}
}
