using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour {

    private IEnumerator coroutine;
    [SerializeField] private GameObject TestLight;

    private float hitTime;

    private void Update()
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
            coroutine = HitAnObject(0.2f);
            if (hitTime > 2.0f)
            {
                StartCoroutine(coroutine);
                //coroutineFlag = false;
            }
        }
        else
        {
            hitTime = 0.0f;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            TestLight.SetActive(true);
            Debug.Log("Did not Hit");
        }
    }
    private IEnumerator HitAnObject(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        TestLight.SetActive(false);
        print("You looked at this object for 2 sec");
    }
}
