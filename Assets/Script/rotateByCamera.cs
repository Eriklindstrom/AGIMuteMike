using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateByCamera : MonoBehaviour
{
    [SerializeField] private GameObject mCam;
    [SerializeField] private GameObject myCan;
    float initZrotation;
    float initXrotation;
    float initYrotation;
    Quaternion rot;

    // Use this for initialization
    void Start()
    {
        //this is how the init position is, lets look at it later
        initXrotation = 0;
        initYrotation = 0;
        initZrotation = 0;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 rotation = transform.eulerAngles;
        rotation.z = mCam.transform.eulerAngles.y;
        transform.eulerAngles = rotation;

    }
}
