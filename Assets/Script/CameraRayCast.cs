using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour {

    private IEnumerator coroutine;
    [SerializeField] private GameObject TestLight;
    [SerializeField] private GameObject MessageObject;
    [SerializeField] private GameObject MessageWindow;
    [SerializeField] private GameObject Clue1;

    private float hitTime;

    void Start()
    {
       MeshRenderer MessageRend = MessageObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
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
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            hitTime += Time.deltaTime;
            if (hitTime > 2.0f)
            {
                StartCoroutine(HitAnObject(0.2f));
                //coroutineFlag = false;
            }
        }
        else
        {
            hitTime = 0.0f;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            TestLight.SetActive(true);
            //MessageObject.SetActive(false);
            Debug.Log("Did not Hit");
        }
    }
    private IEnumerator HitAnObject(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        TestLight.SetActive(false);
        MessageObject.GetComponent<MeshRenderer>().enabled = true;
        MessageWindow.GetComponent<MeshRenderer>().enabled = true;
        Clue1.SetActive(false);
        print("You looked at this object for 2 sec");
    }
}
