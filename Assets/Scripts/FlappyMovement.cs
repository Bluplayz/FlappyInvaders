using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMovement : MonoBehaviour {

    public float forwardSpeed = 0.5f;
    public float flapPower = 5f;

    private bool didFlap = false;
    private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        myRigidbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // Temporarily save the current position
        Vector3 temp = transform.position;

        // Increase X by the (forwardSpeed * deltaTime) for constant movement to right
        temp.x = temp.x + forwardSpeed * Time.deltaTime;

        // Set new Position
        transform.position = temp;

        if (didFlap)
        {
            // If Button was pressed then flap
            myRigidbody.velocity = new Vector2(0, flapPower);
            
            didFlap = false;
        }
    }

    public void OnTouchClicked()
    {
        didFlap = true;
    }
}
