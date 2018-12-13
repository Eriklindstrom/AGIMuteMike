using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotateByCamera : MonoBehaviour
{
    [SerializeField] private GameObject mCam;
    [SerializeField] private GameObject myCan;
    float initZrotation;
    int currentRoom = 11;
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
        mapPostList[1].updateData(new Vector3(1.7f, -5.69f, 273.8f));
        mapPostList[2].updateData(new Vector3(2.15f, -5f, 10.4f));
        mapPostList[3].updateData(new Vector3(-1.36f, -2f, 142.2f));
        mapPostList[4].updateData(new Vector3(-2.02f, 4.83f, 69f));
        mapPostList[5].updateData(new Vector3(-1.59f, 6.17f, 127.2f));
        mapPostList[6].updateData(new Vector3(1.88f, 6.17f, 316.88f));
        mapPostList[7].updateData(new Vector3(-1.96f, 0.16f, 293.5f));
        mapPostList[8].updateData(new Vector3(1.8f, -3.23f, 230.2f));
        mapPostList[9].updateData(new Vector3(-4.99f, -1.23f, 138.2f));
        mapPostList[10].updateData(new Vector3(-6.28f, 0.08f, 183.49f));
        mapPostList[11].updateData(new Vector3(-3.96f, 1.53f, 86.4f));


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
    public void changeRooms(int newroom){
        currentRoom = newroom;
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
