using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioSource[] audioList;

	// List index legend
	// 1. Locked door
	// 2. Keys open door
	// 3. Open door
	// 4. Radio sound
	// 5. Bell

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void playSound(int audioIndex) {
			audioList[audioIndex].Play(0);
	}
}
