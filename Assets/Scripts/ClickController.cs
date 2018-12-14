using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickController : MonoBehaviour {

  public float timerDuration = 2f;  // How long to look at Menu Item before taking action
  public GameObject LoadingBar;     // The loading circle bar
  public GameController gameController;
    //this is not good code But i base everything around the pointer


  private float lookTimer = 0f;     // This value will count down from the duration
  private bool clickedOnce = false; // Bool to know when a button has been clicked once

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

              // Get scene index from clickable area
              string areaName = hit.transform.name;

                int sceneIndex;
                string specialScene;
                if (hit.transform.tag == "SoundOnly")
                {
                    hit.transform.GetComponent<AudioSource>().Play(0);
                }
                else if (hit.transform.tag == "Play")
                {
                    SceneManager.LoadScene(1);
                }
                else
                {
                    // if (hit.transform.GetComponent<AudioSource>() != null)
                    // {
                    //     hit.transform.GetComponent<AudioSource>().Play(0);
                    // }
                    // If special scene
                    if (areaName.Substring(0, 1).Equals("_"))
                    {
                        specialScene = areaName.Substring(1);
                    }
                    // If single number
                    else if (areaName.Substring(1, 1).Equals("."))
                    {
                        sceneIndex = Int32.Parse(areaName.Substring(0, 1));
                        hit.transform.parent.gameObject.SetActive(false);
                        gameController.switchScene(sceneIndex);

                    }
                    // If double number
                    else
                    {
                        sceneIndex = Int32.Parse(areaName.Substring(0, 2));
                        hit.transform.parent.gameObject.SetActive(false);
                        gameController.switchScene(sceneIndex);

                    }
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
}
