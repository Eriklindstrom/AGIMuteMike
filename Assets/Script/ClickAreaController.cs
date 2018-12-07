using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAreaController : MonoBehaviour {

	public GameObject[] sceneList;

	public void switchScene(int sceneIndex) {
			sceneList[sceneIndex].SetActive(true);
	}
}
