using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScene : MonoBehaviour {

    [SerializeField] private GameObject StartScreen;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Back;
    [SerializeField] private GameObject Audio;

    // How long to look at Menu Item before taking action
    public float timerDuration = 2f;
  // The loading circle bar
  public GameObject LoadingBar;

  public VideoController videoController;

  // This value will count down from the duration
  private float lookTimer = 0f;
  // Bool to know when a button has been clicked once
  private bool clickedOnce = false;

  private IEnumerator coroutine;

  // MonoBehaviour Start
  void Start() {

  }

  // MonoBehaviour Update
  void Update() {
      // Bit shift the index of the layer (8) to get a bit mask
      int layerMask = 1 << 8;

      // This would cast rays only against colliders in layer 8.
      // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
      layerMask = ~layerMask;

      RaycastHit hit;
      // Does the ray intersect any objects excluding the player layer
      if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
      {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            // If this button has been clicked once it can't be clicked again directly
            if (clickedOnce) {
              return;
          }

          lookTimer += Time.deltaTime;
          LoadingBar.GetComponent<Image>().fillAmount = lookTimer/timerDuration;
          // Debug.Log("Gaze progress: " + LoadingBar.GetComponent<Image>().fillAmount*100 + "%");

          if (lookTimer > timerDuration) {
                clickedOnce = true;
                LoadingBar.GetComponent<Image>().fillAmount = 0f;
                lookTimer = 0f;
                // Debug.Log("BUTTON HAS BEEN SELECTED!");

              

                if (hit.transform.tag == "SoundOnly")
                {
                    hit.transform.GetComponent<AudioSource>().Play(0);
                }
                else if (hit.transform.tag == "Play")
                {
                    SceneManager.LoadScene(1);
                }
                else if (hit.transform.tag == "Credits")
                {
                    StartScreen.SetActive(false);
                    Back.SetActive(true);
                    Credits.SetActive(true);
                    Audio.SetActive(false);
                }
                else if (hit.transform.tag == "Back")
                {
                    StartScreen.SetActive(true);
                    Back.SetActive(false);
                    Credits.SetActive(false);
                    Audio.SetActive(true);
                }
                else if (hit.transform.tag == "Options")
                {
                    Debug.Log("Options");
                    hit.transform.GetComponent<AudioSource>().Play();
                }

                else
                {
                    /*if(hit.transform.GetComponent<AudioSource>() != null)
                    {
                        hit.transform.GetComponent<AudioSource>().Play(0);
                    }
                    // Get scene index from clickable area
                    string areaName = hit.transform.name;
                    int sceneIndex = Int32.Parse(areaName.Substring(0, 1));

                    // Change video and scene
                    hit.transform.parent.gameObject.SetActive(false);
                    clickAreaController.switchScene(sceneIndex);
                    videoController.ChangeVideo(sceneIndex);
                    */
                }
          }
      }
      else
      {
          clickedOnce = false;
          LoadingBar.GetComponent<Image>().fillAmount = 0f;
          lookTimer = 0f;
          // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
          // Debug.Log("Did not Hit");
      }
  }

  private IEnumerator HitAnObject(float waitTime)
  {
      yield return new WaitForSeconds(waitTime);
      print("You looked at this object for 2 sec");
  }

}
