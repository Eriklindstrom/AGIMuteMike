using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FusePointerCountDown : MonoBehaviour {

	// How long to look at Menu Item before taking action
  public float timerDuration = 2f;
  // UI text that change depending on button activated
  public Text textUI;
  // The loading circle bar
  public GameObject LoadingBar;

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
          //coroutineFlag = true;
          // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
          // Debug.Log("Did Hit");
          // lookTimer += Time.deltaTime;
          // coroutine = HitAnObject(0.2f);
          // if (lookTimer > 2.0f)
          // {
          //     StartCoroutine(coroutine);
          //     //coroutineFlag = false;
          // }

          // If this button has been clicked once it can't be clicked again directly
          if (clickedOnce) {
              return;
          }

          lookTimer += Time.deltaTime;
          LoadingBar.GetComponent<Image>().fillAmount = lookTimer/timerDuration;
          Debug.Log("Gaze progress: " + LoadingBar.GetComponent<Image>().fillAmount*100 + "%");

          if (lookTimer > timerDuration) {
              clickedOnce = true;
              LoadingBar.GetComponent<Image>().fillAmount = 0f;
              lookTimer = 0f;

              // Do something
              // Debug.Log("BUTTON HAS BEEN SELECTED!");
              Text activeButtonTxt = hit.transform.GetChild(0).GetComponent<Text>();
              textUI.text = "Button clicked: " + activeButtonTxt.text;
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
