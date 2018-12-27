using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject flappy;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        MoveTheCamera();
	}

    void MoveTheCamera()
    {
        // Save Position from the Camera
        Vector3 temp = transform.position;

        // Save Position from the Flappy
        Vector3 flappyPos = flappy.transform.position;

        // Change Camera Position
        temp.x = flappyPos.x;

        // Set Camera Position
        transform.position = temp;
    }
}
