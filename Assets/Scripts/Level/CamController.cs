using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    public Camera cam;
    public float speed = 10f;

    public int topBoundary;
    public int bottomBoundary;
    public int leftBoundary;
    public int rightBoundary;

    private float startPosZ;
    private float startPosX;

    // Use this for initialization
    void Start () {
        startPosZ = cam.transform.position.z;
        startPosX = cam.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        //  Move Up
        if (Input.GetKey(KeyCode.W))
        {
            if(cam.transform.position.z < startPosZ + topBoundary)
            {
                cam.transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;    
            }
        }

        //  Move Down
        if (Input.GetKey(KeyCode.S))
        {
            if (cam.transform.position.z > startPosZ - bottomBoundary)
            {
                cam.transform.position += new Vector3(0, 0, -1) * Time.deltaTime * speed;
            }
        }

        //  Move Left
        if (Input.GetKey(KeyCode.A))
        {
            if (cam.transform.position.x > startPosX - leftBoundary)
            {
                cam.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
        }

        //  Move Right
        if (Input.GetKey(KeyCode.D))
        {
            if (cam.transform.position.x < startPosX + rightBoundary)
            {
                cam.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
            }
        }
    }
}
