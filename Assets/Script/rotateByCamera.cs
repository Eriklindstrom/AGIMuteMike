using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateByCamera : MonoBehaviour
{
    [SerializeField] private GameObject mCam;
    [SerializeField] private GameObject myCan;
    float initZrotation;
    int currentRoom = 0;
    int videoNumber = 12; 
    Quaternion rot;
    List<mapPositionData> mapPostList;


    // Use this for initialization
    void Start()
    {
        //this is just hardcoded but should be picked from each scene?
        bool doneInitScenePos = false;
        mapPostList = new List<mapPositionData>();
        for (int a = 0; a < videoNumber;a++){
            mapPostList.Add(new mapPositionData(a));
        }

        mapPostList[0].updateData(new Vector3(3.0f, -3.0f, 258.75f));

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().localPosition = mapPostList[currentRoom].getPosition();
        //transform.position = new Vector3(newPos.x,newPos.y,0.0f);
        Vector3 rotation = transform.eulerAngles;
        rotation.z = mapPostList[currentRoom].getInitialRotation() - mCam.transform.eulerAngles.y;
        transform.eulerAngles = rotation;

    }
}
public class mapPositionData {
    int mapPositionName;
    Vector2 mapPosition;
    float initialRotation;
    public mapPositionData(int mapPositionInt){
        mapPositionName = mapPositionInt;
    }
    public void updateData(Vector3 inData){
        //this vector has 4 datapoints - it is:
        //X position
        mapPosition = new Vector2(inData.x, inData.y);
        initialRotation = inData.z;
    }
    public Vector2 getPosition(){
        return mapPosition;
    }
    public float getInitialRotation(){
        return initialRotation;
    }
}
